using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace LinkIT_
{
    /*
     Este Formulario funciona de una manera distinta ya que tenemos un conjunto de paneles para el 
    titulo y el logo y el menu lateral, y un panel central donde se van a cargar los UserControl dependiendo de la opcion que elija el usuario.
    Esto nos permite tener una interfaz mas limpia y organizada, ya que no tenemos que abrir nuevas ventanas para cada funcionalidad, sino que 
    simplemente cambiamos el contenido del panel central.
    Esto se hace con UserControl que son controles personalizados que podemos diseñar como queramos y luego cargar en el panel central segun la opcion que el usuario elija en el menu lateral.
    esto se van invocando al apretar el boton.

    tambien se le agrego un efecto hover a los botones del menu lateral para mejorar la experiencia del usuario, cambiando el color de fondo del boton cuando el mouse entra y sale del area del boton.
     */
    public partial class JefeEventos : Form
    {
        // Constructor del formulario JefeEventos
        public JefeEventos()
        {
            InitializeComponent();  // Inicializa los componentes del formulario
        }

        // Método que carga un UserControl dentro del panel principal (panelJefeEvento)
        public void LoadUserControl(UserControl uc)
        {
            panelJefeEvento.Controls.Clear();  // Limpia el contenido actual del panel
            uc.Dock = DockStyle.Fill;  // Ajusta el UserControl al tamaño del panel
            panelJefeEvento.Controls.Add(uc);  // Agrega el UserControl al panel
        }

        // Evento que ocurre cuando se carga el formulario
        private void FormJefeEventos_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = "Usuario: " + Login.Sesion.Nombre;  // Muestra el nombre del usuario actual en el label
            LoadUserControl(new UCDashboardJefeEvento(Login.Sesion.IdUsuario));  // Carga el UserControl del dashboard
        }

        // Efecto hover sobre el botón "Mis Eventos" (cuando el mouse entra)
        private void BotonMisEventos_MouseEnter(object sender, EventArgs e)
        {
            BotonMisEventos.BackColor = Color.SeaGreen;  // Cambia el color de fondo al pasar el mouse
        }

        // Efecto hover sobre el botón "Mis Eventos" (cuando el mouse sale)
        private void BotonMisEventos_MouseLeave(object sender, EventArgs e)
        {
            BotonMisEventos.BackColor = Color.MediumSeaGreen;  // Vuelve al color original cuando el mouse sale
        }

        // Efecto hover sobre el botón "Calendario" (cuando el mouse entra)
        private void buttonCalendario_MouseEnter(object sender, EventArgs e)
        {
            buttonCalendario.BackColor = Color.SeaGreen;  // Cambia el color de fondo al pasar el mouse
        }

        // Efecto hover sobre el botón "Calendario" (cuando el mouse sale)
        private void buttonCalendario_MouseLeave(object sender, EventArgs e)
        {
            buttonCalendario.BackColor = Color.MediumSeaGreen;  // Vuelve al color original cuando el mouse sale
        }

        // Evento que ocurre cuando se hace clic en el botón "Mis Eventos"
        private void BotonMisEventos_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UCMisEventos("Jefe de Eventos"));  // Carga el UserControl que muestra los eventos
        }

        // Evento que ocurre cuando se hace clic en el botón "Calendario"
        private void buttonCalendario_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UCCalendario("Jefe de Eventos", Login.Sesion.IdUsuario));  // Carga el UserControl del calendario
        }

        // Evento que ocurre cuando se hace clic en el botón "Cerrar sesión"
        private void buttonCerrarSesion_Click(object sender, EventArgs e)
        {
            // Muestra un mensaje de confirmación antes de cerrar sesión
            DialogResult result = MessageBox.Show(
                "¿Seguro que desea cerrar sesión?",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                this.Close();  // Cierra el formulario si el usuario confirma
            }
        }

        // Evento que ocurre cuando se hace clic en el botón "Usuarios"
        private void bUsuarios_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UCRevisionUsuarios(Login.Sesion.IdUsuario));  // Carga el UserControl para revisar usuarios
        }

        // Evento que ocurre cuando se hace clic en el botón "Consultas"
        private void bConsultas_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UCConsultas());  // Carga el UserControl de consultas
        }

        // Evento que ocurre cuando se hace clic en el botón "Dashboard"
        private void bDashboard_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UCDashboardJefeEvento(Login.Sesion.IdUsuario));  // Carga el UserControl del dashboard
        }
    }
}