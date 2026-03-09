using Microsoft.Data.SqlClient;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace LinkIT_
{
    public partial class UCRevisionUsuarios : UserControl
    {
        public UCRevisionUsuarios()
        {
            InitializeComponent();

            // Crear columnas del DataGridView
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("colNombre", "Nombre");
            dataGridView1.Columns.Add("colCorreo", "Correo");

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

            // Evitar error del Designer
            if (!LicenseManager.UsageMode.Equals(LicenseUsageMode.Designtime))
            {
                CargarUsuariosPendientes();
            }
        }

        private void CargarUsuariosPendientes()
        {
            dataGridView1.Rows.Clear();

            Conexion con = new Conexion();

            SqlCommand cmd = new SqlCommand(@"
                SELECT id_usuario, nombre, correo
                FROM Usuario
                WHERE activo = 0", con.AbrirConexion());

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int fila = dataGridView1.Rows.Add(
                    reader["nombre"].ToString(),
                    reader["correo"].ToString()
                );

                dataGridView1.Rows[fila].Tag = Convert.ToInt32(reader["id_usuario"]);
            }

            reader.Close();
            con.CerrarConexion();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int idUsuario = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Tag);
            string accion = dataGridView1.Columns[e.ColumnIndex].Name;

            if (accion == "colAprobar")
            {
                AprobarUsuario(idUsuario);
            }
            else if (accion == "colRechazar")
            {
                RechazarUsuario(idUsuario);
            }

            CargarUsuariosPendientes();
        }

        private void AprobarUsuario(int idUsuario)
        {
            Conexion con = new Conexion();

            SqlCommand cmd = new SqlCommand(
                "UPDATE Usuario SET activo = 1 WHERE id_usuario = @id",
                con.AbrirConexion());

            cmd.Parameters.AddWithValue("@id", idUsuario);

            cmd.ExecuteNonQuery();
            con.CerrarConexion();
        }

        private void RechazarUsuario(int idUsuario)
        {
            Conexion con = new Conexion();

            SqlCommand cmd = new SqlCommand(
                "DELETE FROM Usuario WHERE id_usuario = @id",
                con.AbrirConexion());

            cmd.Parameters.AddWithValue("@id", idUsuario);

            cmd.ExecuteNonQuery();
            con.CerrarConexion();
        }
    }
}