using Microsoft.Data.SqlClient;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace LinkIT_
{
    public partial class UCRevisionUsuarios : UserControl
    {
        public int idUsuario;

        public UCRevisionUsuarios(int idUsuarioLogueado)
        {
            InitializeComponent();

            idUsuario = idUsuarioLogueado;

            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("colNombre", "Nombre");
            dataGridView1.Columns.Add("colCorreo", "Correo");
            dataGridView1.Columns.Add("colFecha", "Fecha Solicitud");

            DataGridViewButtonColumn aprobar = new DataGridViewButtonColumn();
            aprobar.Name = "colAprobar";
            aprobar.HeaderText = "Aprobar";
            aprobar.Text = "Aprobar";
            aprobar.UseColumnTextForButtonValue = true;

            DataGridViewButtonColumn rechazar = new DataGridViewButtonColumn();
            rechazar.Name = "colRechazar";
            rechazar.HeaderText = "Rechazar";
            rechazar.Text = "Rechazar";
            rechazar.UseColumnTextForButtonValue = true;

            dataGridView1.Columns.Add(aprobar);
            dataGridView1.Columns.Add(rechazar);

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.CellContentClick += dataGridView1_CellContentClick;

            CargarUsuariosPendientes();
        }

        private void CargarUsuariosPendientes()
        {
            dataGridView1.Rows.Clear();

            Conexion con = new Conexion();

            SqlCommand cmd = new SqlCommand(@"
            SELECT id_solicitud, nombre, correo, fecha_solicitud
            FROM Solicitud
            WHERE estado = 'pendiente'
            ORDER BY fecha_solicitud DESC
            ", con.AbrirConexion());

            SqlDataReader reader = cmd.ExecuteReader();

            bool haySolicitudes = false;

            while (reader.Read())
            {
                haySolicitudes = true;

                int fila = dataGridView1.Rows.Add(
                    reader["nombre"].ToString(),
                    reader["correo"].ToString(),
                    Convert.ToDateTime(reader["fecha_solicitud"]).ToString("dd/MM/yyyy HH:mm")
                );

                dataGridView1.Rows[fila].Tag = Convert.ToInt32(reader["id_solicitud"]);
            }

            reader.Close();
            con.CerrarConexion();

            if (!haySolicitudes)
            {
                panelSinSolicitudes.Visible = true;
                dataGridView1.Visible = false;
            }
            else
            {
                panelSinSolicitudes.Visible = false;
                dataGridView1.Visible = true;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // PROTECCIONES PARA EVITAR EL ERROR
            if (e.RowIndex < 0) return;
            if (e.RowIndex >= dataGridView1.Rows.Count) return;
            if (e.ColumnIndex < 0) return;

            var fila = dataGridView1.Rows[e.RowIndex];

            if (fila.Tag == null) return;

            int idSolicitud = Convert.ToInt32(fila.Tag);
            string accion = dataGridView1.Columns[e.ColumnIndex].Name;

            if (accion == "colAprobar")
            {
                AprobarUsuario(idSolicitud);
            }
            else if (accion == "colRechazar")
            {
                RechazarUsuario(idSolicitud);
            }

            // recarga segura
            CargarUsuariosPendientes();
        }

        private void AprobarUsuario(int idSolicitud)
        {
            Conexion con = new Conexion();
            SqlConnection conexion = con.AbrirConexion();

            SqlCommand cmd = new SqlCommand(@"
            INSERT INTO Usuario (id_rol,nombre,correo,contraseña,DNI,fecha_registro,activo)
            SELECT 3, nombre, correo, contraseña, DNI, GETDATE(), 1
            FROM Solicitud
            WHERE id_solicitud = @id;

            UPDATE Solicitud
            SET estado = 'aprobado',
                id_usuario = @idusuario
            WHERE id_solicitud = @id
            ", conexion);

            cmd.Parameters.AddWithValue("@id", idSolicitud);
            cmd.Parameters.AddWithValue("@idusuario", idUsuario);

            cmd.ExecuteNonQuery();
            con.CerrarConexion();
        }

        private void RechazarUsuario(int idSolicitud)
        {
            Conexion con = new Conexion();

            SqlCommand cmd = new SqlCommand(@"
            UPDATE Solicitud
            SET estado = 'rechazado',
                id_usuario = @idusuario
            WHERE id_solicitud = @id
            ", con.AbrirConexion());

            cmd.Parameters.AddWithValue("@id", idSolicitud);
            cmd.Parameters.AddWithValue("@idusuario", idUsuario);

            cmd.ExecuteNonQuery();
            con.CerrarConexion();
        }
    }
}