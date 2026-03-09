using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace LinkIT_
{
    public partial class Backup : Form
    {
        public bool ContraseñaValida { get; private set; } = false;  // Propiedad para indicar si la contraseña es válida

        // Constructor de la clase Backup
        public Backup()
        {
            InitializeComponent();  // Inicializa los componentes del formulario
        }

        // Método para hacer el hash de la contraseña utilizando SHA256
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())  // Utiliza el algoritmo SHA256 para crear el hash
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));  // Convierte la contraseña en un array de bytes y genera el hash
                StringBuilder builder = new StringBuilder();

                foreach (byte b in bytes)  // Convierte cada byte en una cadena hexadecimal
                    builder.Append(b.ToString("X2"));

                return builder.ToString();  // Retorna el hash en formato hexadecimal
            }
        }

        // Evento que ocurre cuando se hace clic en el botón "Cancelar"
        private void bCancelar_Click(object sender, EventArgs e)
        {
            this.Close();  // Cierra el formulario
        }

        // Evento que ocurre cuando se hace clic en el botón "Aceptar"
        private void bAceptar_Click(object sender, EventArgs e)
        {
            string contraseñaIngresada = txtClave.Text.Trim();  // Obtiene la contraseña ingresada por el usuario y la limpia de espacios al principio y al final

            if (string.IsNullOrEmpty(contraseñaIngresada))  // Verifica si la contraseña está vacía
            {
                MessageBox.Show("Ingrese su contraseña.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);  // Muestra un mensaje de advertencia si la contraseña está vacía
                return;
            }

            try
            {
                Conexion con = new Conexion();  // Crea una nueva instancia de la clase Conexion para interactuar con la base de datos

                SqlCommand cmd = new SqlCommand(
                    "SELECT contraseña FROM Usuario WHERE id_usuario = @id",  // Consulta para obtener la contraseña de la base de datos
                    con.AbrirConexion());  // Abre la conexión con la base de datos

                cmd.Parameters.AddWithValue("@id", Login.Sesion.IdUsuario);  // Agrega el parámetro del ID de usuario

                object result = cmd.ExecuteScalar();  // Ejecuta la consulta y obtiene el resultado (la contraseña almacenada en la base de datos)

                if (result != null)  // Si se encontró un resultado
                {
                    string contraseñaHashBDD = result.ToString();  // Obtiene la contraseña de la base de datos
                    string contraseñaHashIngresada = HashPassword(contraseñaIngresada);  // Hashea la contraseña ingresada por el usuario

                    if (contraseñaHashBDD == contraseñaHashIngresada)  // Compara la contraseña hasheada de la base de datos con la ingresada
                    {
                        ContraseñaValida = true;  // Si las contraseñas coinciden, la contraseña es válida
                        this.DialogResult = DialogResult.OK;  // Establece el resultado del diálogo como OK
                        this.Close();  // Cierra el formulario
                    }
                    else
                    {
                        MessageBox.Show("Contraseña incorrecta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);  // Muestra un mensaje de error si la contraseña es incorrecta
                        txtClave.Clear();  // Limpia el campo de la contraseña
                        txtClave.Focus();  // Pone el foco en el campo de la contraseña
                    }
                }
                else
                {
                    MessageBox.Show("No se encontró el usuario actual.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);  // Muestra un mensaje de error si no se encuentra el usuario en la base de datos
                }

                con.CerrarConexion();  // Cierra la conexión con la base de datos
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar la contraseña: " + ex.Message);  // Muestra un mensaje de error si ocurre una excepción
            }
        }
    }
}