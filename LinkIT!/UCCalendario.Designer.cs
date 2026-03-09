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
            CalendarioEvento = new MonthCalendar();
            panelEventos = new Panel();
            labelPrincipal = new Label();
            labelSubtitulo = new Label();
            panel2 = new Panel();
            labelEventosDia = new Label();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // CalendarioEvento
            // 
            CalendarioEvento.CalendarDimensions = new Size(3, 4);
            CalendarioEvento.Location = new Point(9, 85);
            CalendarioEvento.MaxDate = new DateTime(2026, 12, 31, 0, 0, 0, 0);
            CalendarioEvento.MinDate = new DateTime(2026, 1, 1, 0, 0, 0, 0);
            CalendarioEvento.Name = "CalendarioEvento";
            CalendarioEvento.ShowToday = false;
            CalendarioEvento.TabIndex = 0;
            CalendarioEvento.DateChanged += monthCalendar1_DateChanged;
            // 
            // panelEventos
            // 
            panelEventos.AutoScroll = true;
            panelEventos.Location = new Point(0, 50);
            panelEventos.Name = "panelEventos";
            panelEventos.Size = new Size(410, 497);
            panelEventos.TabIndex = 2;
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
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(labelEventosDia);
            panel2.Controls.Add(panelEventos);
            panel2.Location = new Point(710, 118);
            panel2.Name = "panel2";
            panel2.Size = new Size(408, 544);
            panel2.TabIndex = 5;
            // 
            // labelEventosDia
            // 
            labelEventosDia.AutoSize = true;
            labelEventosDia.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelEventosDia.ForeColor = SystemColors.ActiveCaptionText;
            labelEventosDia.Location = new Point(14, 17);
            labelEventosDia.Name = "labelEventosDia";
            labelEventosDia.Size = new Size(89, 20);
            labelEventosDia.TabIndex = 6;
            labelEventosDia.Text = "Eventos del";
            // 
            // UCCalendario
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.Ivory;
            Controls.Add(panel2);
            Controls.Add(labelSubtitulo);
            Controls.Add(labelPrincipal);
            Controls.Add(CalendarioEvento);
            Name = "UCCalendario";
            Size = new Size(1173, 697);
            Load += UCCalendario_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MonthCalendar CalendarioEvento;
        private ListBox listEventos;
        private Panel panel1;
        private Label labelPrincipal;
        private Label labelSubtitulo;
        private Panel panelEventos;
        private Panel panel2;
        private Label labelEventosDia;
    }
}
