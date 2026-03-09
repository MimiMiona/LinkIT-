using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LinkIT_
{
    public partial class Usuario : Form
    {
        // Constructor del formulario
        public Usuario()
        {
            InitializeComponent(); // Inicializa los componentes del formulario
        }

        // Método que carga un UserControl dentro del panel del formulario
        private void LoadUserControl(UserControl uc)
        {
            panelUsuario.Controls.Clear(); // Limpia cualquier UserControl previamente cargado
            uc.Dock = DockStyle.Fill; // Hace que el UserControl ocupe todo el espacio disponible en el panel
            panelUsuario.Controls.Add(uc); // Añade el nuevo UserControl al panel
        }

        // Evento que se dispara cuando el formulario se carga
        private void FormUsuario_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom; // Ajusta la imagen del PictureBox para que se ajuste correctamente al tamaño
            lblUsuario.Text = "Usuario: " + Login.Sesion.Nombre; // Muestra el nombre del usuario logueado
            LoadUserControl(new UCExplorarEventos()); // Carga el UserControl UCExplorarEventos al cargar el formulario
        }

        // Evento que se dispara cuando se hace clic en el botón "Explorar Eventos"
        private void BotonExplorarEventos_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UCExplorarEventos()); // Carga el UserControl UCExplorarEventos
        }

        // Evento que se dispara cuando se hace clic en el botón "Mis Eventos"
        private void BotonMisEventos_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UCMisEventos("Usuario")); // Carga el UserControl UCMisEventos con el rol "Usuario"
        }

        // Evento que se dispara cuando se hace clic en el botón "Cerrar Sesión"
        private void buttonCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra el formulario actual, cerrando la sesión del usuario
        }

        // Evento que se dispara cuando se hace clic en el botón "Consultas"
        private void bConsultas_Click(object sender, EventArgs e)
        {
            FormConsulta consulta = new FormConsulta(); // Crea una nueva instancia del formulario de consultas
            consulta.ShowDialog(); // Muestra el formulario de consultas como un cuadro de diálogo modal
        }

        // Evento que se dispara cuando se hace clic en el botón "Calendario"
        private void buttonCalendario_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UCCalendario("Usuario", Login.Sesion.IdUsuario)); // Carga el UserControl UCCalendario con los datos del usuario
        }
    }
}