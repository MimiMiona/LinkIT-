using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace LinkIT_
{
    // Control de usuario para gestionar los inscriptos en un evento
    public partial class UCInscriptos : UserControl
    {
        private UCMisEventos.Evento eventoActual; // Evento actual
        private DataTable inscriptosDT; // Tabla para almacenar los datos de los inscriptos

        // Constructor que recibe un evento y carga la información si existe
        public UCInscriptos(UCMisEventos.Evento evento = null)
        {
            InitializeComponent(); // Inicializa los componentes del control
            eventoActual = evento; // Asigna el evento actual

            // Si el evento es válido, carga los datos
            if (eventoActual != null)
            {
                CargarEncabezado();  // Carga la información del encabezado
                CargarInscriptos();  // Carga los inscriptos
            }

            // Evento para volver atrás
            btnAtras.Click += BtnAtras_Click;
            // Evento para gestionar el clic sobre una celda del DataGridView
            dataGridView1.CellClick += DataGridView1_CellClick;
        }

        // Método que actualiza la cantidad de inscriptos para el evento actual
        private void ActualizarDatosEvento()
        {
            Conexion con = new Conexion();

            // Consulta SQL para contar los inscriptos en el evento
            SqlCommand cmd = new SqlCommand(
                @"SELECT COUNT(*) 
                FROM Inscripcion 
                WHERE id_evento = @idEvento AND estado = 'Inscripto'",
                con.AbrirConexion()
            );

            cmd.Parameters.AddWithValue("@idEvento", eventoActual.IdEvento); // Parámetro para el evento

            // Asigna la cantidad de inscriptos al evento actual
            eventoActual.Inscriptos = (int)cmd.ExecuteScalar();

            con.CerrarConexion(); // Cierra la conexión
        }

        // Configura el encabezado de la interfaz con la información del evento
        private void CargarEncabezado()
        {
            ActualizarDatosEvento(); // Actualiza la cantidad de inscriptos
            labelTitulo.Text = eventoActual.Titulo; // Asigna el título del evento
            labelInfo.Text = $"{eventoActual.Fecha:yyyy-MM-dd} {eventoActual.HoraInicio:hh\\:mm} - {eventoActual.HoraFin:hh\\:mm}"; // Asigna la fecha y hora
            labelOcupacion.Text = $"{eventoActual.Inscriptos} inscriptos • {eventoActual.PorcentajeOcupacion}% ocupación"; // Muestra la ocupación
            progressBar1.Value = Math.Min(eventoActual.PorcentajeOcupacion, 100); // Actualiza la barra de progreso
        }

        // Carga los inscriptos en el DataGridView
        private void CargarInscriptos()
        {
            dataGridView1.Rows.Clear(); // Limpia las filas previas

            // Crea un DataTable para almacenar los datos de los inscriptos
            inscriptosDT = new DataTable();
            inscriptosDT.Columns.Add("Participante", typeof(string));
            inscriptosDT.Columns.Add("Correo", typeof(string));
            inscriptosDT.Columns.Add("Fecha", typeof(string));
            inscriptosDT.Columns.Add("idUsuario", typeof(int));

            Conexion con = new Conexion();

            // Consulta SQL para obtener los inscriptos en el evento
            SqlCommand cmd = new SqlCommand(@"
                SELECT i.id_usuario, u.nombre AS participante, u.correo, i.fecha_inscripcion, i.estado
                FROM Inscripcion i
                INNER JOIN Usuario u ON i.id_usuario = u.id_usuario
                WHERE i.id_evento = @idEvento AND i.estado = 'Inscripto'", con.AbrirConexion());
            cmd.Parameters.AddWithValue("@idEvento", eventoActual.IdEvento); // Parámetro para el evento

            SqlDataReader reader = cmd.ExecuteReader(); // Ejecuta la consulta

            // Recorre los resultados de los inscriptos
            while (reader.Read())
            {
                string participante = reader["participante"].ToString();
                string correo = reader["correo"].ToString();
                string fecha = Convert.ToDateTime(reader["fecha_inscripcion"]).ToString("yyyy-MM-dd");
                int idUsuario = Convert.ToInt32(reader["id_usuario"]);

                // Añade los datos al DataGridView
                int filaIndex = dataGridView1.Rows.Add(
                    participante,
                    correo,
                    fecha,
                    "Dar de Baja" // Agrega un botón "Dar de Baja"
                );

                // Guarda el id_usuario en la fila para usarlo después
                dataGridView1.Rows[filaIndex].Tag = idUsuario;

                // Guarda también los datos en el DataTable para poder filtrar después
                inscriptosDT.Rows.Add(participante, correo, fecha, idUsuario);
            }

            reader.Close(); // Cierra el lector
            con.CerrarConexion(); // Cierra la conexión
        }

        // Evento que filtra los inscriptos en el DataGridView según el texto del buscador
        private void textBoxBuscar_TextChanged(object sender, EventArgs e)
        {
            if (inscriptosDT == null) return;

            string filtro = textBoxBuscar.Text.Trim().ToLower(); // Obtiene el texto del filtro

            dataGridView1.Rows.Clear(); // Limpia las filas

            // Filtra los inscriptos y los muestra si el filtro coincide
            foreach (DataRow row in inscriptosDT.Rows)
            {
                string participante = row["Participante"].ToString().ToLower();
                string correo = row["Correo"].ToString().ToLower();
                string fecha = row["Fecha"].ToString().ToLower();

                if (participante.Contains(filtro) || correo.Contains(filtro) || fecha.Contains(filtro))
                {
                    int filaIndex = dataGridView1.Rows.Add(
                        row["Participante"],
                        row["Correo"],
                        row["Fecha"],
                        "Dar de Baja"
                    );

                    dataGridView1.Rows[filaIndex].Tag = (int)row["idUsuario"]; // Guarda el idUsuario en la fila
                }
            }
        }

        // Evento que maneja el clic en el botón "Dar de Baja"
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 3) // Si se hace clic en la columna "Dar de Baja"
            {
                // Verificar si el evento ya ha finalizado
                DateTime finEvento = eventoActual.Fecha.Date + eventoActual.HoraFin;

                if (DateTime.Now > finEvento) // Si el evento ya terminó
                {
                    MessageBox.Show(
                        "No se pueden modificar inscripciones porque el evento ya finalizó.",
                        "Evento finalizado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    return; // No permite dar de baja si el evento ya terminó
                }

                // Obtiene la fila seleccionada
                DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];
                int idUsuario = (int)fila.Tag; // Obtiene el idUsuario

                // Confirma la acción de dar de baja al inscripto
                DialogResult result = MessageBox.Show(
                    $"¿Deseás dar de baja a {fila.Cells[0].Value}?", // Muestra el nombre del participante
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                // Si el usuario confirma la baja
                if (result == DialogResult.Yes)
                {
                    Conexion con = new Conexion();
                    // Actualiza el estado de la inscripción a 'Cancelado'
                    SqlCommand cmd = new SqlCommand(
                        "UPDATE Inscripcion SET estado = 'Cancelado' WHERE id_usuario = @idUsuario AND id_evento = @idEvento",
                        con.AbrirConexion()
                    );

                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                    cmd.Parameters.AddWithValue("@idEvento", eventoActual.IdEvento);

                    cmd.ExecuteNonQuery(); // Ejecuta la actualización
                    con.CerrarConexion(); // Cierra la conexión

                    CargarEncabezado(); // Recarga la información del encabezado
                    CargarInscriptos(); // Recarga la lista de inscriptos
                }
            }
        }

        // Evento para manejar el clic en el botón de retroceso (volver a "Mis Eventos")
        private void BtnAtras_Click(object sender, EventArgs e)
        {
            JefeEventos form = (JefeEventos)this.FindForm(); // Encuentra el formulario principal
            form.LoadUserControl(new UCMisEventos("Jefe de Eventos")); // Carga el control "Mis Eventos"
        }
    }
}