using Microsoft.Data.SqlClient;
using Microsoft.Win32;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
namespace LinkIT_
{
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }

        private void bVolver_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void bGuardar_Click(object sender, EventArgs e)
        {
            String nombre = textNombre.Text.Trim();
            string dni = textDNI.Text.Trim();
            string correo = textCorreo.Text.Trim();
            string clave = textClave.Text.Trim();

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(clave) || string.IsNullOrEmpty(dni))
            {
                MessageBox.Show("Complete todos los campos");
                return;
            }

            try
            {
                Conexion con = new Conexion();

                SqlCommand cmd = new SqlCommand(@"
                INSERT INTO Usuario (nombre, dni, correo, contraseña, id_rol, activo)
                VALUES (@nombre, @dni, @correo, @clave, 3, 0)
                ", con.AbrirConexion());

                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@dni", dni);
                cmd.Parameters.AddWithValue("@correo", correo);
                cmd.Parameters.AddWithValue("@clave", HashPassword(clave));

                cmd.ExecuteNonQuery();
                con.CerrarConexion();

                MessageBox.Show("Usuario registrado. Quedará pendiente de aprobación.");

                Login login = new Login();
                login.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();

                foreach (byte b in bytes)
                    builder.Append(b.ToString("x2"));

                return builder.ToString();
            }
        }

        private void bLimpiar_Click(object sender, EventArgs e)
        {
            textNombre.Clear();
            textDNI.Clear();
            textCorreo.Clear();
            textClave.Clear();
        }
    }
}
