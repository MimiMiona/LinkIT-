using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LinkIT_
{
    public partial class UCDashboard : UserControl
    {
        private Color colorGrisTexto = Color.FromArgb(100, 100, 100);
        public UCDashboard()
        {
            InitializeComponent();
        }

        private void UCDashboard_Load(object sender, EventArgs e)
        {
            labelSubtitulo.ForeColor = colorGrisTexto;
        }
    }
}
