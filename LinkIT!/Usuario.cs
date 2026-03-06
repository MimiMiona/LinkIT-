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
            LoadUserControl(new UCExplorarEventos());
        }

        private void BotonMisEventos_Click(object sender, EventArgs e)
        {
            LoadUserControl(new UCExplorarEventos());
        }

        
    }
}
