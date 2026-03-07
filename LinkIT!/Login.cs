using Microsoft.Data.SqlClient;
using Microsoft.Win32;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace LinkIT_
{
    public partial class Login : Form
    {
        public static class Sesion
        {
            public static int IdUsuario { get; set; }
            public static string Nombre { get; set; }
            public static string Rol { get; set; }
        }

        public Login()
        {
            InitializeComponent();
        }

        public static void CerrarSesion()
        {
            Sesion.IdUsuario = 0;
            Sesion.Nombre = null;
            Sesion.Rol = null;
        }

        public string HashPassword(string password)
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

        private void bIngresar_Click(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text.Trim();
            string contraseña = txtClave.Text.Trim();

            if (string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(contraseña))
            {
                MessageBox.Show("Por favor ingrese correo y contraseña.");
                return;
            }

            try
            {
                Conexion con = new Conexion();

                SqlCommand cmd = new SqlCommand(@"
                SELECT 
                    u.id_usuario,
                    u.nombre,
                    u.contraseña,
                    r.nombre AS rol
                FROM Usuario u
                INNER JOIN Rol r ON u.id_rol = r.id_rol
                WHERE u.correo = @correo AND u.activo = 1
                ", con.AbrirConexion());

                cmd.Parameters.AddWithValue("@correo", correo);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    int idUsuario = Convert.ToInt32(reader["id_usuario"]);
                    string nombre = reader["nombre"].ToString();
                    string contraseñaHash = reader["contraseña"].ToString().ToLower();
                    string rol = reader["rol"].ToString();

                    if (contraseñaHash == HashPassword(contraseña))
                    {
                        Sesion.IdUsuario = idUsuario;
                        Sesion.Nombre = nombre;
                        Sesion.Rol = rol;

                        MessageBox.Show($"Bienvenido {nombre}");

                        Form formDestino = null;

                        switch (rol)
                        {
                            case "Administrador":
                                formDestino = new Administrador();
                                break;

                            case "Jefe de Eventos":
                                formDestino = new JefeEventos();
                                break;

                            case "Usuario":
                                formDestino = new Usuario();
                                break;

                            default:
                                MessageBox.Show("Rol no reconocido");
                                return;
                        }

                        formDestino.FormClosed += (s, args) =>
                        {
                            this.Show();
                            txtCorreo.Clear();
                            txtClave.Clear();
                        };

                        formDestino.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Contraseña incorrecta");
                    }
                }
                else
                {
                    MessageBox.Show("Usuario no encontrado o inactivo");
                }

                con.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión: " + ex.Message);
            }
        }

        private void bEliminar_Click(object sender, EventArgs e)
        {
            txtCorreo.Clear();
            txtClave.Clear();
        }

        private void bSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bRegistro_Click(object sender, EventArgs e)
        {
            Registro registro = new Registro();
            registro.Show();

            this.Hide();
        }
    }
}
