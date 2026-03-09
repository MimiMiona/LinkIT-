using System;
using System.Windows.Forms;

namespace LinkIT_
{
    public partial class FormularioEvento : Form
    {
        private UCMisEventos.Evento eventoActual; // null si es nuevo

        // Constructor del formulario
        public FormularioEvento(UCMisEventos.Evento evento = null)
        {
            InitializeComponent();  // Inicializa los componentes del formulario
            eventoActual = evento;  // Asigna el evento actual (si es que se pasa uno)

            InicializarComboEstado();  // Inicializa el ComboBox de estados
            ConfigurarEstadoVisible();  // Configura la visibilidad del ComboBox de estado según si es un evento nuevo o existente
            CargarDatosEvento();  // Carga los datos del evento si existe
        }

        // Inicializa el ComboBox de estado
        private void InicializarComboEstado()
        {
            comboBoxEstado.Items.Clear();  // Limpia los elementos previos del ComboBox
            comboBoxEstado.Items.AddRange(new string[] { "Activo", "Cancelado" });  // Agrega las opciones de estado al ComboBox

            // Evitar que el usuario escriba en el ComboBox
            comboBoxEstado.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        // Configura la visibilidad de los controles de estado según si es un evento nuevo o uno existente
        private void ConfigurarEstadoVisible()
        {
            // Si es un evento existente, se muestra el ComboBox y el label de estado
            label7.Visible = eventoActual != null;
            comboBoxEstado.Visible = eventoActual != null;
        }

        // Carga los datos del evento si está editando uno existente
        private void CargarDatosEvento()
        {
            if (eventoActual != null)
            {
                // Si está editando un evento existente, carga sus datos en los controles
                txtTitulo.Text = eventoActual.Titulo;
                txtDescripcion.Text = eventoActual.Descripcion;
                txtHorarioInicio.Text = eventoActual.HoraInicio.ToString(@"hh\:mm");
                txtHorarioFin.Text = eventoActual.HoraFin.ToString(@"hh\:mm");
                txtCapacidad.Text = eventoActual.Capacidad.ToString();
                dateTimeFechaEvento.Value = eventoActual.Fecha;
                comboBoxEstado.SelectedItem = eventoActual.Estado;
            }
            else
            {
                // Si es un evento nuevo, limpia los controles para permitir la inserción de nuevos datos
                txtTitulo.Clear();
                txtDescripcion.Clear();
                txtHorarioInicio.Clear();
                txtHorarioFin.Clear();
                txtCapacidad.Clear();
                dateTimeFechaEvento.Value = DateTime.Today;  // Establece la fecha predeterminada al día de hoy
                if (comboBoxEstado.Items.Count > 0)
                    comboBoxEstado.SelectedIndex = 0;  // Establece el estado predeterminado
            }
        }

        // Guarda un nuevo evento en la base de datos
        private void GuardarNuevoEvento(UCMisEventos.Evento e)
        {
            Conexion con = new Conexion();
            var cmd = new Microsoft.Data.SqlClient.SqlCommand(
                @"INSERT INTO Evento (titulo, descripcion, fecha_evento, horario_inicio, horario_fin, capacidad_maxima, estado, id_usuario)
                      VALUES (@titulo,@desc,@fecha,@hinicio,@hfin,@capacidad,@estado,@idusuario)", con.AbrirConexion());

            // Asocia los parámetros con los valores del evento
            cmd.Parameters.AddWithValue("@titulo", e.Titulo);
            cmd.Parameters.AddWithValue("@desc", e.Descripcion);
            cmd.Parameters.AddWithValue("@fecha", e.Fecha);
            cmd.Parameters.AddWithValue("@hinicio", e.Fecha.Date + e.HoraInicio);
            cmd.Parameters.AddWithValue("@hfin", e.Fecha.Date + e.HoraFin);
            cmd.Parameters.AddWithValue("@capacidad", e.Capacidad);
            cmd.Parameters.AddWithValue("@estado", e.Estado);
            cmd.Parameters.AddWithValue("@idusuario", Login.Sesion.IdUsuario);

            // Ejecuta la consulta de inserción
            cmd.ExecuteNonQuery();
            con.CerrarConexion();  // Cierra la conexión a la base de datos
        }

        // Actualiza los datos de un evento existente en la base de datos
        private void ActualizarEvento(UCMisEventos.Evento e)
        {
            Conexion con = new Conexion();
            var cmd = new Microsoft.Data.SqlClient.SqlCommand(
                @"UPDATE Evento SET titulo=@titulo, descripcion=@desc, fecha_evento=@fecha, horario_inicio=@hinicio,
                  horario_fin=@hfin, capacidad_maxima=@capacidad, estado=@estado WHERE id_evento=@id", con.AbrirConexion());

            // Asocia los parámetros con los valores del evento
            cmd.Parameters.AddWithValue("@titulo", e.Titulo);
            cmd.Parameters.AddWithValue("@desc", e.Descripcion);
            cmd.Parameters.AddWithValue("@fecha", e.Fecha);
            cmd.Parameters.AddWithValue("@hinicio", e.Fecha.Date + e.HoraInicio);
            cmd.Parameters.AddWithValue("@hfin", e.Fecha.Date + e.HoraFin);
            cmd.Parameters.AddWithValue("@capacidad", e.Capacidad);
            cmd.Parameters.AddWithValue("@estado", e.Estado);
            cmd.Parameters.AddWithValue("@id", e.IdEvento);

            // Ejecuta la consulta de actualización
            cmd.ExecuteNonQuery();
            con.CerrarConexion();  // Cierra la conexión a la base de datos
        }

        // Evento que ocurre cuando se hace clic en el botón "Aceptar"
        private void bAceptar_Click(object sender, EventArgs e)
        {
            // Validaciones de los campos ingresados
            string titulo = txtTitulo.Text.Trim();
            string descripcion = txtDescripcion.Text.Trim();
            if (!TimeSpan.TryParse(txtHorarioInicio.Text, out TimeSpan horaInicio) ||
                !TimeSpan.TryParse(txtHorarioFin.Text, out TimeSpan horaFin))
            {
                MessageBox.Show("Formato de hora inválido (HH:mm).");
                return;  // Sale si el formato de las horas es inválido
            }
            if (horaFin <= horaInicio)
            {
                MessageBox.Show("Hora de fin no puede ser anterior a la de inicio.");
                return;  // Sale si la hora de fin es anterior a la de inicio
            }
            if (!int.TryParse(txtCapacidad.Text, out int capacidad) || capacidad <= 0)
            {
                MessageBox.Show("Capacidad debe ser mayor a 0.");
                return;  // Sale si la capacidad no es válida
            }
            DateTime fechaEvento = dateTimeFechaEvento.Value.Date;
            if (fechaEvento < DateTime.Today)
            {
                MessageBox.Show("La fecha del evento no puede ser anterior a hoy.");
                return;  // Sale si la fecha del evento es anterior a hoy
            }

            // Establece el estado del evento (si no se selecciona, se establece como "Activo")
            string estado = comboBoxEstado.SelectedItem != null ? comboBoxEstado.SelectedItem.ToString() : "Activo";

            // Crea un nuevo objeto Evento
            if (eventoActual == null)
                eventoActual = new UCMisEventos.Evento();  // Si es un evento nuevo

            // Asigna los valores de los controles al objeto Evento
            eventoActual.Titulo = titulo;
            eventoActual.Descripcion = descripcion;
            eventoActual.HoraInicio = horaInicio;
            eventoActual.HoraFin = horaFin;
            eventoActual.Capacidad = capacidad;
            eventoActual.Fecha = fechaEvento;
            eventoActual.Estado = estado;

            // Guarda o actualiza el evento en la base de datos
            if (eventoActual.IdEvento == 0)
            {
                GuardarNuevoEvento(eventoActual);  // Guarda si es un evento nuevo
            }
            else
            {
                ActualizarEvento(eventoActual);  // Actualiza si ya existe
            }

            MessageBox.Show("Evento guardado correctamente.");  // Muestra mensaje de éxito

            // Cierra el formulario después de guardar
            this.Close();
        }

        // Evento que ocurre cuando se hace clic en el botón "Cancelar"
        private void BCancelar_Click(object sender, EventArgs e)
        {
            this.Close();  // Cierra el formulario sin guardar
        }
    }
}