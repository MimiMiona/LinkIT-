namespace LinkIT_
{
    partial class UCCalendario
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            monthCalendar1 = new MonthCalendar();
            listBox1 = new ListBox();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // monthCalendar1
            // 
            monthCalendar1.CalendarDimensions = new Size(3, 4);
            monthCalendar1.Location = new Point(9, 85);
            monthCalendar1.MaxDate = new DateTime(2026, 12, 31, 0, 0, 0, 0);
            monthCalendar1.MinDate = new DateTime(2026, 1, 1, 0, 0, 0, 0);
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.ShowToday = false;
            monthCalendar1.TabIndex = 0;
            monthCalendar1.DateChanged += monthCalendar1_DateChanged;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(26, 51);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(260, 514);
            listBox1.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Controls.Add(listBox1);
            panel1.Location = new Point(710, 85);
            panel1.Name = "panel1";
            panel1.Size = new Size(323, 611);
            panel1.TabIndex = 2;
            // 
            // UCCalendario
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            Controls.Add(panel1);
            Controls.Add(monthCalendar1);
            Name = "UCCalendario";
            Size = new Size(1143, 759);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private MonthCalendar monthCalendar1;
        private ListBox listBox1;
        private Panel panel1;
    }
}
