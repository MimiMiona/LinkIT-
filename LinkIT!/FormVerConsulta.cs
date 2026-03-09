using Microsoft.Data.SqlClient;
using System;
using System.Windows.Forms;

namespace LinkIT_
{
    public partial class FormVerConsulta : Form
    {
        int idConsulta;  // ID de la consulta
        string estadoConsulta;  // Estado actual de la consulta (Ej. "Pendiente" o "Atendida")

        // Constructor del formulario
        public FormVerConsulta()
        {
            InitializeComponent();  // Inicializa los componentes del formulario
        }

        // Constructor sobrecargado para recibir datos específicos de la consulta
        public FormVerConsulta(int id, string descripcion, string nombre, string correo, string estado)
        {
            InitializeComponent();  // Inicializa los componentes del formulario

            idConsulta = id;  // Asigna el ID de la consulta
            estadoConsulta = estado;  // Asigna el estado de la consulta

            // Carga los datos de la consulta en los controles del formulario
            labelTitulo.Text = "Consulta #" + id;  // Muestra el título con el ID de la consulta
            labelNombre.Text = "Nombre: " + nombre;  // Muestra el nombre del usuario que hizo la consulta
            labelCorreo.Text = "Correo: " + correo;  // Muestra el correo del usuario que hizo la consulta

            textDescripcion.Text = descripcion;  // Muestra la descripción de la consulta
            textDescripcion.DeselectAll();  // Deselect all text to avoid pre-selection

            // Cambia el texto del botón según el estado de la consulta
            if (estadoConsulta.ToLower() == "atendida")  // Si la consulta ya está atendida, cambia el texto del botón
            {
                bAtendida.Text = "Cerrar";  // El botón se convierte en "Cerrar"
            }
        }

        // Evento que ocurre cuando se hace clic en el botón "Atendida"
        private void bAtendida_Click(object sender, EventArgs e)
        {
            // Si la consulta ya está atendida, solo cierra el formulario
            if (estadoConsulta.ToLower() == "atendida")
            {
                this.Close();  // Cierra el formulario sin hacer nada
                return;  // Sale de la función
            }

            // Si la consulta no está atendida, actualiza su estado a "Atendida" en la base de datos
            Conexion con = new Conexion();  // Crea una nueva conexión con la base de datos

            // Prepara la consulta SQL para actualizar el estado de la consulta
            SqlCommand cmd = new SqlCommand(
                "UPDATE Consulta SET estado='atendida' WHERE id_consulta=@id",  // Consulta para actualizar el estado
                con.AbrirConexion());  // Abre la conexión con la base de datos

            cmd.Parameters.AddWithValue("@id", idConsulta);  // Asocia el ID de la consulta con el parámetro

            // Ejecuta la consulta para actualizar el estado de la consulta
            cmd.ExecuteNonQuery();
            con.CerrarConexion();  // Cierra la conexión a la base de datos

            MessageBox.Show("Consulta marcada como atendida.");  // Muestra un mensaje de éxito

            this.Close();  // Cierra el formulario después de marcar la consulta como atendida
        }
    }
}