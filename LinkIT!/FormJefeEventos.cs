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
    public partial class FormJefeEventos : Form
    {
        public FormJefeEventos()
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
            buttonCalendario.BackColor = Color.SeaGreen;
        }

        private void buttonCalendario_MouseLeave(object sender, EventArgs e)
        {
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
        {
            LoadUserControl(new UCCalendario());
        }
    }
}
