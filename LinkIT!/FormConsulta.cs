using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LinkIT_
{
    public partial class FormConsulta : Form
    {
        // Constructor del formulario
        public FormConsulta()
        {
            InitializeComponent();  // Inicializa los componentes del formulario
        }

        // Evento que ocurre cuando se hace clic en el botón "Enviar"
        private void bEnviar_Click(object sender, EventArgs e)
        {
            string descripcion = textDescripcion.Text.Trim();  // Obtiene el texto ingresado en el campo de descripción y lo limpia de espacios

            if (descripcion == "")  // Verifica si la descripción está vacía
            {
                MessageBox.Show("Escriba una descripción del problema.");  // Muestra un mensaje de advertencia si no se ingresa descripción
                return;  // Sale del método si la descripción está vacía
            }

            try
            {
                Conexion con = new Conexion();  // Crea una nueva instancia de la clase Conexion para interactuar con la base de datos

                // Prepara la consulta SQL para insertar la nueva consulta en la base de datos
                SqlCommand cmd = new SqlCommand(
                "INSERT INTO Consulta (id_usuario, descripcion, estado) VALUES (@usuario,@desc,'Pendiente')",
                con.AbrirConexion());  // Establece la conexión y la consulta SQL

                // Asocia los parámetros de la consulta con los valores correspondientes
                cmd.Parameters.AddWithValue("@usuario", Login.Sesion.IdUsuario);  // Asocia el ID de usuario de la sesión
                cmd.Parameters.AddWithValue("@desc", descripcion);  // Asocia la descripción del problema

                // Ejecuta la consulta SQL para insertar la nueva consulta
                cmd.ExecuteNonQuery();  // Ejecuta la consulta sin devolver resultados

                con.CerrarConexion();  // Cierra la conexión con la base de datos

                MessageBox.Show("Consulta enviada correctamente.");  // Muestra un mensaje indicando que la consulta fue enviada exitosamente

                this.Close();  // Cierra el formulario
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);  // Muestra un mensaje de error si algo falla
            }
        }

        // Evento que ocurre cuando se hace clic en el botón "Cancelar"
        private void bCancelar_Click(object sender, EventArgs e)
        {
            this.Close();  // Cierra el formulario
        }
    }
}