using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace LinkIT_
{
    public partial class UCInscriptos : UserControl
    {
        private UCMisEventos.Evento eventoActual; // Evento actual
        private DataTable inscriptosDT;
        public UCInscriptos(UCMisEventos.Evento evento = null)
        {
            InitializeComponent();
            eventoActual = evento;
            if (eventoActual != null)
            {
                CargarEncabezado();
                CargarInscriptos();
            }

            btnAtras.Click += BtnAtras_Click;
            dataGridView1.CellClick += DataGridView1_CellClick;
        }


        private void ActualizarDatosEvento()
        {
            Conexion con = new Conexion();

            SqlCommand cmd = new SqlCommand(
                @"SELECT COUNT(*) 
          FROM Inscripcion 
          WHERE id_evento = @idEvento AND estado = 'Inscripto'",
                con.AbrirConexion()
            );

            cmd.Parameters.AddWithValue("@idEvento", eventoActual.IdEvento);

            eventoActual.Inscriptos = (int)cmd.ExecuteScalar();

            con.CerrarConexion();
        }

        // Configura el encabezado con info del evento
        private void CargarEncabezado()
        {
            ActualizarDatosEvento();
            labelTitulo.Text = eventoActual.Titulo;
            labelInfo.Text = $"{eventoActual.Fecha:yyyy-MM-dd} {eventoActual.HoraInicio:hh\\:mm} - {eventoActual.HoraFin:hh\\:mm}";
            labelOcupacion.Text = $"{eventoActual.Inscriptos} inscriptos • {eventoActual.PorcentajeOcupacion}% ocupación";
            progressBar1.Value = Math.Min(eventoActual.PorcentajeOcupacion, 100);
        }

        // Carga los inscriptos en la tabla
        private void CargarInscriptos()
        {
            dataGridView1.Rows.Clear();

            // Creamos el DataTable para guardar los datos y filtrar
            inscriptosDT = new DataTable();
            inscriptosDT.Columns.Add("Participante", typeof(string));
            inscriptosDT.Columns.Add("Correo", typeof(string));
            inscriptosDT.Columns.Add("Fecha", typeof(string));
            inscriptosDT.Columns.Add("idUsuario", typeof(int));

            Conexion con = new Conexion();
            SqlCommand cmd = new SqlCommand(@"
        SELECT i.id_usuario, u.nombre AS participante, u.correo, i.fecha_inscripcion, i.estado
        FROM Inscripcion i
        INNER JOIN Usuario u ON i.id_usuario = u.id_usuario
        WHERE i.id_evento = @idEvento AND i.estado = 'Inscripto'", con.AbrirConexion());
            cmd.Parameters.AddWithValue("@idEvento", eventoActual.IdEvento);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string participante = reader["participante"].ToString();
                string correo = reader["correo"].ToString();
                string fecha = Convert.ToDateTime(reader["fecha_inscripcion"]).ToString("yyyy-MM-dd");
                int idUsuario = Convert.ToInt32(reader["id_usuario"]);

                // Agregamos al DataGridView
                int filaIndex = dataGridView1.Rows.Add(
                    participante,
                    correo,
                    fecha,
                    "Dar de Baja" // Botón
                );

                // Guardamos el id_usuario en la fila para usarlo después
                dataGridView1.Rows[filaIndex].Tag = idUsuario;

                // Guardamos también en el DataTable para poder filtrar después
                inscriptosDT.Rows.Add(participante, correo, fecha, idUsuario);
            }

            reader.Close();
            con.CerrarConexion();
        }

        private void textBoxBuscar_TextChanged(object sender, EventArgs e)
        {
            if (inscriptosDT == null) return;

            string filtro = textBoxBuscar.Text.Trim().ToLower();

            dataGridView1.Rows.Clear();

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

                    dataGridView1.Rows[filaIndex].Tag = (int)row["idUsuario"];
                }
            }
        }

        // Evento al hacer click en botón Dar de Baja
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 3) // columna Dar de Baja
            {
                // 🔹 verificar si el evento ya finalizó
                DateTime finEvento = eventoActual.Fecha.Date + eventoActual.HoraFin;

                if (DateTime.Now > finEvento)
                {
                    MessageBox.Show(
                        "No se pueden modificar inscripciones porque el evento ya finalizó.",
                        "Evento finalizado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    return;
                }

                DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];
                int idUsuario = (int)fila.Tag;

                DialogResult result = MessageBox.Show(
                    $"¿Deseás dar de baja a {fila.Cells[0].Value}?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    Conexion con = new Conexion();
                    SqlCommand cmd = new SqlCommand(
                        "UPDATE Inscripcion SET estado = 'Cancelado' WHERE id_usuario = @idUsuario AND id_evento = @idEvento",
                        con.AbrirConexion()
                    );

                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                    cmd.Parameters.AddWithValue("@idEvento", eventoActual.IdEvento);

                    cmd.ExecuteNonQuery();
                    con.CerrarConexion();

                    CargarEncabezado();
                    CargarInscriptos();
                }
            }
        }

        // Botón volver a Mis Eventos
        private void BtnAtras_Click(object sender, EventArgs e)
        {
            JefeEventos form = (JefeEventos)this.FindForm();
            form.LoadUserControl(new UCMisEventos("Jefe de Eventos"));
        }
    }
}