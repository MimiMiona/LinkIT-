using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LinkIT_
{
    public partial class UCCalendario : UserControl
    {
        private Color colorGrisTexto = Color.FromArgb(100, 100, 100);
        public UCCalendario()
        {
            InitializeComponent();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void UCCalendario_Load(object sender, EventArgs e)
        {
            labelSubtitulo.ForeColor = colorGrisTexto;
        }
    }
}
