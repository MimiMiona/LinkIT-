using System;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace LinkIT_
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void bIngresar_Click(object sender, EventArgs e)
        {
            Conexion con = new Conexion();
            SqlCommand cmd = new SqlCommand(
                "SELECT Perfil FROM Usuarios WHERE Usuario=@user AND Clave=@pass",
                con.AbrirConexion());

            cmd.Parameters.AddWithValue("@user", txtUsuario.Text);
            cmd.Parameters.AddWithValue("@pass", txtClave.Text);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                string perfil = reader["Perfil"]?.ToString() ?? "";
                MessageBox.Show("Bienvenido - Perfil: " + perfil);
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
            }

            con.CerrarConexion();

        }

        private void bEliminar_Click(object sender, EventArgs e)
        {
            txtUsuario.Clear();
            txtClave.Clear();
        }

        private void bSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
