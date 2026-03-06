using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace LinkIT_
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private int idSeleccionado = 0;

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
        }

        private void bGuardar_Click(object sender, EventArgs e)
        {
            if (textNombre.Text == "" || textApellido.Text == "" || textDNI.Text == "")
            {
                MessageBox.Show("Debe completar los campos obligatorios");
                return;
            }

            Conexion con = new Conexion();

            // 🔎 Verificar si ya existe el DNI
            SqlCommand verificar = new SqlCommand(
                "SELECT COUNT(*) FROM Organizadores WHERE DNI=@dni",
                con.AbrirConexion());

            verificar.Parameters.AddWithValue("@dni", textDNI.Text);

            int existe = (int)verificar.ExecuteScalar();

            if (existe > 0)
            {
                MessageBox.Show("Ya existe un organizador con ese DNI");
                con.CerrarConexion();
                return;
            }

            SqlCommand cmd = new SqlCommand(
                "INSERT INTO Organizadores (Nombre, Apellido, DNI, Telefono) VALUES (@nom,@ape,@dni,@tel)",
                con.AbrirConexion());

            cmd.Parameters.AddWithValue("@nom", textNombre.Text);
            cmd.Parameters.AddWithValue("@ape", textApellido.Text);
            cmd.Parameters.AddWithValue("@dni", textDNI.Text);
            cmd.Parameters.AddWithValue("@tel", textTelefono.Text);

            cmd.ExecuteNonQuery();
            con.CerrarConexion();

            MessageBox.Show("Organizador guardado correctamente");
        }

        private void bMostrar_Click(object sender, EventArgs e)
        {
            Conexion con = new Conexion();
            SqlDataAdapter da = new SqlDataAdapter(
                "SELECT * FROM Organizadores",
                con.AbrirConexion());

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            con.CerrarConexion();
        }

        private void bEliminar_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show(
                            "¿Seguro que desea eliminar?",
                            "Confirmar",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

            if (r == DialogResult.Yes)
            {
                Conexion con = new Conexion();
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM Organizadores WHERE DNI=@dni",
                    con.AbrirConexion());

                cmd.Parameters.AddWithValue("@dni", textDNI.Text);
                cmd.ExecuteNonQuery();
                con.CerrarConexion();

                MessageBox.Show("Eliminado correctamente");
            }
        }

        private void bModificar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un registro");
                return;
            }

            Conexion con = new Conexion();

            SqlCommand cmd = new SqlCommand(
                "UPDATE Organizadores SET Nombre=@nom, Apellido=@ape, DNI=@dni, Telefono=@tel WHERE IdOrganizador=@id",
                con.AbrirConexion());

            cmd.Parameters.AddWithValue("@nom", textNombre.Text);
            cmd.Parameters.AddWithValue("@ape", textApellido.Text);
            cmd.Parameters.AddWithValue("@dni", textDNI.Text);
            cmd.Parameters.AddWithValue("@tel", textTelefono.Text);
            cmd.Parameters.AddWithValue("@id", idSeleccionado);

            cmd.ExecuteNonQuery();
            con.CerrarConexion();

            MessageBox.Show("Modificado correctamente");
            LimpiarCampos();
            MostrarDatos();
            idSeleccionado = 0;
        }
        private void MostrarDatos()
        {
            Conexion con = new Conexion();

            SqlDataAdapter da = new SqlDataAdapter(
                "SELECT * FROM Organizadores",
                con.AbrirConexion());

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            con.CerrarConexion();
        }

        private void bLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            textNombre.Clear();
            textApellido.Clear();
            textDNI.Clear();
            textTelefono.Clear();
        }

    }
}
