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
            "SELECT IdUsuario, Perfil FROM Usuarios WHERE Usuario=@user AND Clave=@pass",
            con.AbrirConexion());

            cmd.Parameters.AddWithValue("@user", txtUsuario.Text);
            cmd.Parameters.AddWithValue("@pass", txtClave.Text);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                int id = Convert.ToInt32(reader["IdUsuario"]);
                string perfil = reader["Perfil"]?.ToString() ?? "";

                Form formDestino = null;

                if (id == 1) 
                {
                    formDestino = new Administrador();
                }
                else
                {
                    switch (perfil)
                    {
                        case "Organizadores":
                            formDestino = new JefeEventos();
                            break;

                        case "Usuarios":
                            formDestino = new Usuario();
                            break;

                        default:
                            MessageBox.Show("Perfil no reconocido");
                            return;
                    }
                }

                formDestino.Show();
                this.Hide();
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
