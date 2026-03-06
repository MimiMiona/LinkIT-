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
            labelPrincipal = new Label();
            labelSubtitulo = new Label();
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
            listBox1.Location = new Point(10, 0);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(397, 544);
            listBox1.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Controls.Add(listBox1);
            panel1.Location = new Point(730, 115);
            panel1.Name = "panel1";
            panel1.Size = new Size(407, 544);
            panel1.TabIndex = 2;
            // 
            // labelPrincipal
            // 
            labelPrincipal.AutoSize = true;
            labelPrincipal.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelPrincipal.Location = new Point(20, 20);
            labelPrincipal.Name = "labelPrincipal";
            labelPrincipal.Size = new Size(137, 32);
            labelPrincipal.TabIndex = 3;
            labelPrincipal.Text = "Calendario";
            // 
            // labelSubtitulo
            // 
            labelSubtitulo.AutoSize = true;
            labelSubtitulo.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelSubtitulo.ForeColor = SystemColors.ActiveCaptionText;
            labelSubtitulo.Location = new Point(23, 55);
            labelSubtitulo.Name = "labelSubtitulo";
            labelSubtitulo.Size = new Size(224, 17);
            labelSubtitulo.TabIndex = 4;
            labelSubtitulo.Text = "Vista anual de eventos programados";
            // 
            // UCCalendario
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.Ivory;
            Controls.Add(labelSubtitulo);
            Controls.Add(labelPrincipal);
            Controls.Add(panel1);
            Controls.Add(monthCalendar1);
            Name = "UCCalendario";
            Size = new Size(1173, 697);
            Load += UCCalendario_Load;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MonthCalendar monthCalendar1;
        private ListBox listBox1;
        private Panel panel1;
        private Label labelPrincipal;
        private Label labelSubtitulo;
    }
}
