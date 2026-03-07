using System;
using System.Windows.Forms;

namespace LinkIT_
{
    public partial class FormularioEvento : Form
    {
        private UCMisEventos.Evento eventoActual; // null si es nuevo

        public FormularioEvento(UCMisEventos.Evento evento = null)
        {
            InitializeComponent();
            eventoActual = evento;

            InicializarComboEstado();
            ConfigurarEstadoVisible();
            CargarDatosEvento();

        }

        private void InicializarComboEstado()
        {
            comboBoxEstado.Items.Clear();
            comboBoxEstado.Items.AddRange(new string[] { "Activo", "Cancelado", "Finalizado" });

            // Evitar que el usuario escriba
            comboBoxEstado.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void ConfigurarEstadoVisible()
        {
            // Si es nuevo, ocultamos el label y comboBox de estado
            label7.Visible = eventoActual != null;
            comboBoxEstado.Visible = eventoActual != null;
        }

        private void CargarDatosEvento()
        {
            if (eventoActual != null)
            {
                // Editando evento
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
                // Creando evento
                txtTitulo.Clear();
                txtDescripcion.Clear();
                txtHorarioInicio.Clear();
                txtHorarioFin.Clear();
                txtCapacidad.Clear();
                dateTimeFechaEvento.Value = DateTime.Today;
                if (comboBoxEstado.Items.Count > 0)
                    comboBoxEstado.SelectedIndex = 0;
            }
        }

        private void GuardarNuevoEvento(UCMisEventos.Evento e)
        {
            Conexion con = new Conexion();
            var cmd = new Microsoft.Data.SqlClient.SqlCommand(
                @"INSERT INTO Evento (titulo, descripcion, fecha_evento, horario_inicio, horario_fin, capacidad_maxima, estado, id_usuario)
                      VALUES (@titulo,@desc,@fecha,@hinicio,@hfin,@capacidad,@estado,@idusuario)", con.AbrirConexion());

            cmd.Parameters.AddWithValue("@titulo", e.Titulo);
            cmd.Parameters.AddWithValue("@desc", e.Descripcion);
            cmd.Parameters.AddWithValue("@fecha", e.Fecha);
            cmd.Parameters.AddWithValue("@hinicio", e.Fecha.Date + e.HoraInicio);
            cmd.Parameters.AddWithValue("@hfin", e.Fecha.Date + e.HoraFin);
            cmd.Parameters.AddWithValue("@capacidad", e.Capacidad);
            cmd.Parameters.AddWithValue("@estado", e.Estado);
            cmd.Parameters.AddWithValue("@idusuario", Login.Sesion.IdUsuario);

            cmd.ExecuteNonQuery();
            con.CerrarConexion();
        }

        private void ActualizarEvento(UCMisEventos.Evento e)
        {
            Conexion con = new Conexion();
            var cmd = new Microsoft.Data.SqlClient.SqlCommand(
                @"UPDATE Evento SET titulo=@titulo, descripcion=@desc, fecha_evento=@fecha, horario_inicio=@hinicio,
                  horario_fin=@hfin, capacidad_maxima=@capacidad, estado=@estado WHERE id_evento=@id", con.AbrirConexion());

            cmd.Parameters.AddWithValue("@titulo", e.Titulo);
            cmd.Parameters.AddWithValue("@desc", e.Descripcion);
            cmd.Parameters.AddWithValue("@fecha", e.Fecha);
            cmd.Parameters.AddWithValue("@hinicio", e.Fecha.Date + e.HoraInicio);
            cmd.Parameters.AddWithValue("@hfin", e.Fecha.Date + e.HoraFin);
            cmd.Parameters.AddWithValue("@capacidad", e.Capacidad);
            cmd.Parameters.AddWithValue("@estado", e.Estado);
            cmd.Parameters.AddWithValue("@id", e.IdEvento);

            cmd.ExecuteNonQuery();
            con.CerrarConexion();
        }

        private void bAceptar_Click(object sender, EventArgs e)
        {

            // Validaciones
            string titulo = txtTitulo.Text.Trim();
            string descripcion = txtDescripcion.Text.Trim();
            if (!TimeSpan.TryParse(txtHorarioInicio.Text, out TimeSpan horaInicio) ||
                !TimeSpan.TryParse(txtHorarioFin.Text, out TimeSpan horaFin))
            {
                MessageBox.Show("Formato de hora inválido (HH:mm).");
                return;
            }
            if (horaFin <= horaInicio)
            {
                MessageBox.Show("Hora de fin no puede ser anterior a la de inicio.");
                return;
            }
            if (!int.TryParse(txtCapacidad.Text, out int capacidad) || capacidad <= 0)
            {
                MessageBox.Show("Capacidad debe ser mayor a 0.");
                return;
            }
            DateTime fechaEvento = dateTimeFechaEvento.Value.Date;
            if (fechaEvento < DateTime.Today)
            {
                MessageBox.Show("La fecha del evento no puede ser anterior a hoy.");
                return;
            }

            string estado = comboBoxEstado.SelectedItem != null ? comboBoxEstado.SelectedItem.ToString() : "Activo";

            // Crear objeto evento
            if (eventoActual == null)
                eventoActual = new UCMisEventos.Evento(); // Nuevo evento

            eventoActual.Titulo = titulo;
            eventoActual.Descripcion = descripcion;
            eventoActual.HoraInicio = horaInicio;
            eventoActual.HoraFin = horaFin;
            eventoActual.Capacidad = capacidad;
            eventoActual.Fecha = fechaEvento;
            eventoActual.Estado = estado;

            // Guardar en la base de datos
            if (eventoActual.IdEvento == 0)
            {
                GuardarNuevoEvento(eventoActual);
            }
            else
            {
                ActualizarEvento(eventoActual);
            }

            MessageBox.Show("Evento guardado correctamente.");

            // Cerrar formulario después de guardar
            this.Close();
        }

        private void BCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}