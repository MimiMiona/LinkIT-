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
        public Usuario()
        {
            InitializeComponent();
        }

        private void LoadUserControl(UserControl uc)
        {
            panelUsuario.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelUsuario.Controls.Add(uc);

        }

        private void FormUsuario_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            lblUsuario.Text = "Usuario: " + Login.Sesion.Nombre;
            LoadUserControl(new UCExplorarEventos());
        }

        private void BotonExplorarEventos_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UCExplorarEventos());
        }

        private void BotonMisEventos_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UCMisEventos("Usuario"));
        }

        private void buttonCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bConsultas_Click(object sender, EventArgs e)
        {
            FormConsulta consulta = new FormConsulta();
            consulta.ShowDialog();
        }

        private void buttonCalendario_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UCCalendario("Usuario", Login.Sesion.IdUsuario));
        }
    }
}
