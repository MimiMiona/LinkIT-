using Microsoft.Data.SqlClient;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace LinkIT_
{
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();  // Inicializa los componentes del formulario
        }

        // Evento que se dispara cuando se hace clic en el botón "Volver"
        private void bVolver_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();  // Abre el formulario de Login
            this.Close();  // Cierra el formulario de Registro
        }

        // Evento que se dispara cuando se hace clic en el botón "Guardar"
        private void bGuardar_Click(object sender, EventArgs e)
        {
            string nombre = textNombre.Text.Trim();
            string dni = textDNI.Text.Trim();
            string correo = textCorreo.Text.Trim();
            string clave = textClave.Text.Trim();

            // VALIDAR CAMPOS VACÍOS
            if (string.IsNullOrWhiteSpace(nombre) ||
                string.IsNullOrWhiteSpace(dni) ||
                string.IsNullOrWhiteSpace(correo) ||
                string.IsNullOrWhiteSpace(clave))
            {
                MessageBox.Show("Debe completar todos los campos");
                return;
            }

            // VALIDAR DNI (solo números)
            if (!Regex.IsMatch(dni, @"^\d{7,8}$"))
            {
                MessageBox.Show("El DNI debe contener 7 u 8 números");
                return;
            }

            // VALIDAR EMAIL
            if (!Regex.IsMatch(correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Ingrese un correo válido");
                return;
            }

            // VALIDAR CONTRASEÑA
            if (clave.Length < 4)
            {
                MessageBox.Show("La contraseña debe tener al menos 4 caracteres");
                return;
            }

            try
            {
                Conexion con = new Conexion();
                SqlConnection conexion = con.AbrirConexion();

                // VERIFICAR SI YA EXISTE USUARIO
                SqlCommand verificarUsuario = new SqlCommand(
                "SELECT COUNT(*) FROM Usuario WHERE correo=@correo OR DNI=@dni",
                conexion);

                verificarUsuario.Parameters.AddWithValue("@correo", correo);
                verificarUsuario.Parameters.AddWithValue("@dni", dni);

                int existeUsuario = (int)verificarUsuario.ExecuteScalar();

                if (existeUsuario > 0)
                {
                    MessageBox.Show("Ya existe un usuario con ese correo o DNI");
                    con.CerrarConexion();
                    return;
                }

                // VERIFICAR SI YA HAY SOLICITUD
                SqlCommand verificarSolicitud = new SqlCommand(
                "SELECT COUNT(*) FROM Solicitud WHERE correo=@correo OR DNI=@dni",
                conexion);

                verificarSolicitud.Parameters.AddWithValue("@correo", correo);
                verificarSolicitud.Parameters.AddWithValue("@dni", dni);

                int existeSolicitud = (int)verificarSolicitud.ExecuteScalar();

                if (existeSolicitud > 0)
                {
                    MessageBox.Show("Ya existe una solicitud con ese correo o DNI");
                    con.CerrarConexion();
                    return;
                }

                // INSERTAR SOLICITUD
                SqlCommand cmd = new SqlCommand(@"
                INSERT INTO Solicitud
                (nombre, correo, DNI, contraseña, fecha_solicitud, estado)
                VALUES
                (@nombre, @correo, @dni, @clave, GETDATE(), 'pendiente')
                ", conexion);

                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@correo", correo);
                cmd.Parameters.AddWithValue("@dni", dni);
                cmd.Parameters.AddWithValue("@clave", HashPassword(clave));

                cmd.ExecuteNonQuery();
                con.CerrarConexion();

                MessageBox.Show("Solicitud enviada. Debe ser aprobada por un administrador.");

                Login login = new Login();
                login.Show();  // Abre el formulario de Login
                this.Close();  // Cierra el formulario de Registro
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // Método para hashear la contraseña con SHA256
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();

                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("X2"));
                }

                return builder.ToString();
            }
        }

        // Evento que se dispara cuando se hace clic en el botón "Limpiar"
        private void bLimpiar_Click(object sender, EventArgs e)
        {
            textNombre.Clear();
            textDNI.Clear();
            textCorreo.Clear();
            textClave.Clear();
        }
    }
}