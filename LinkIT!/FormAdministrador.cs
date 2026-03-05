using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LinkIT_
{
    public partial class FormAdministrador : Form
    {
        public FormAdministrador()
        {
            InitializeComponent();
        }

        private void LoadUserControl(UserControl uc)
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
    }
}
