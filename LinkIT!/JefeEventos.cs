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
        public JefeEventos()
        {
            InitializeComponent();
        }

        private void LoadUserControl(UserControl uc)
        {
            panelJefeEvento.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelJefeEvento.Controls.Add(uc);

        }

        private void FormJefeEventos_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            LoadUserControl(new UCMisEventos());
        }

        private void BotonMisEventos_MouseEnter(object sender, EventArgs e)
        {
            BotonMisEventos.BackColor = Color.SeaGreen;
        }

        private void BotonMisEventos_MouseLeave(object sender, EventArgs e)
        {
            BotonMisEventos.BackColor = Color.MediumSeaGreen;
        }

        private void buttonInscriptos_MouseEnter(object sender, EventArgs e)
        {
            buttonInscriptos.BackColor = Color.SeaGreen;
        }

        private void buttonInscriptos_MouseLeave(object sender, EventArgs e)
        {
            buttonInscriptos.BackColor = Color.MediumSeaGreen;
        }

        private void buttonCalendario_MouseEnter(object sender, EventArgs e)
        {
            //aca se cambia el color de fondo del boton del calendario cuando el mouse entra en el area del boton, para dar un efecto hover.
            buttonCalendario.BackColor = Color.SeaGreen;
        }

        private void buttonCalendario_MouseLeave(object sender, EventArgs e)
        {
            //aca se cambia el color de fondo del boton del calendario cuando el mouse sale del area del boton, para dar un efecto hover.
            buttonCalendario.BackColor = Color.MediumSeaGreen;
        }

        private void BotonMisEventos_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UCMisEventos());
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonInscriptos_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UCInscriptos());
        }

        private void buttonCalendario_Click(object sender, EventArgs e)
        { // aca se carga el UserControl del calendario, que es el que muestra el calendario con los eventos y las fechas.
            LoadUserControl(new UCCalendario());
        }
    }
}
