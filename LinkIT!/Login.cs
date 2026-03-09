using Microsoft.Data.SqlClient;
using Microsoft.Win32;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions; // Importante para la validación del correo
using System.Windows.Forms;

namespace LinkIT_
{
    public partial class Login : Form
    {
        // Clase estática para almacenar los datos de sesión del usuario
        public static class Sesion
        {
            public static int IdUsuario { get; set; }
            public static string Nombre { get; set; }
            public static string Rol { get; set; }
        }

        // Constructor del formulario Login
        public Login()
        {
            InitializeComponent();  // Inicializa los componentes del formulario
        }

        // Método para cerrar la sesión del usuario
        public static void CerrarSesion()
        {
            Sesion.IdUsuario = 0;
            Sesion.Nombre = null;
            Sesion.Rol = null;
        }

        // Método para hashear la contraseña con SHA256
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

        // Método para validar el formato del correo
        private bool EsCorreoValido(string correo)
        {
            // Expresión regular para validar el formato del correo
            var regex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
            return regex.IsMatch(correo);
        }

        // Evento que se dispara al hacer clic en el botón "Ingresar"
        private void bIngresar_Click(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text.Trim();
            string contraseña = txtClave.Text.Trim();

            // Validación de campos vacíos
            if (string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(contraseña))
            {
                MessageBox.Show("Por favor ingrese correo y contraseña.");
                return;
            }

            // Validación del formato del correo
            if (!EsCorreoValido(correo))
            {
                MessageBox.Show("El formato del correo es inválido.");
                return;
            }

            try
            {
                Conexion con = new Conexion();

                // Consulta SQL para verificar el correo y obtener los datos del usuario
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

                    if (contraseñaHash == HashPassword(contraseña))  // Compara la contraseña ingresada con el hash en la base de datos
                    {
                        // Establece los datos de la sesión
                        Sesion.IdUsuario = idUsuario;
                        Sesion.Nombre = nombre;
                        Sesion.Rol = rol;

                        MessageBox.Show($"Bienvenido {nombre}");

                        Form formDestino = null;

                        // Determina a qué formulario redirigir según el rol del usuario
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

                        // Evento que ocurre cuando el formulario destino se cierra
                        formDestino.FormClosed += (s, args) =>
                        {
                            this.Show();
                            txtCorreo.Clear();
                            txtClave.Clear();
                        };

                        formDestino.Show();  // Muestra el formulario correspondiente
                        this.Hide();  // Oculta el formulario de Login
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

                con.CerrarConexion();  // Cierra la conexión
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión: " + ex.Message);
            }
        }

        // Evento para limpiar los campos de texto (correo y contraseña)
        private void bEliminar_Click(object sender, EventArgs e)
        {
            txtCorreo.Clear();
            txtClave.Clear();
        }

        // Evento que cierra la aplicación cuando el usuario hace clic en "Salir"
        private void bSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Evento que abre el formulario de registro
        private void bRegistro_Click(object sender, EventArgs e)
        {
            Registro registro = new Registro();
            registro.Show();

            this.Hide();  // Oculta el formulario de login
        }
    }
}