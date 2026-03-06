using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LinkIT_
{
    public partial class Administrador : Form
    {
        public Administrador()
        {
            InitializeComponent();
        }

        private void LoadUserControl(UserControl uc)
        {
            panelAdministrador.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelAdministrador.Controls.Add(uc);

        }

        private void CargarUC(UserControl uc)
        {
            panelAdministrador.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelAdministrador.Controls.Add(uc);
        }
        private void FormAdministrador_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            LoadUserControl(new UCDashboard());
        }

        private void bDashboard_Click(object sender, EventArgs e)
        {
            UCDashboard uc = new UCDashboard();
            CargarUC(uc);
        }

        private void bEventos_Click(object sender, EventArgs e)
        {
            UCMisEventos uc = new UCMisEventos();
            CargarUC(uc);
        }

        private void bUsuarios_Click(object sender, EventArgs e)
        {
            UCInscriptos uc = new UCInscriptos();
            CargarUC(uc);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserControl1 uc = new UserControl1();
            CargarUC(uc);
        }
    }
}
