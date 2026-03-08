namespace LinkIT_
{
    partial class UCEventoAdministrador
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
            labelSubtitulo = new Label();
            labelTitulo = new Label();
            panelEventos = new Panel();
            SuspendLayout();
            // 
            // labelSubtitulo
            // 
            labelSubtitulo.AutoSize = true;
            labelSubtitulo.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelSubtitulo.ForeColor = SystemColors.ActiveCaptionText;
            labelSubtitulo.Location = new Point(23, 55);
            labelSubtitulo.Name = "labelSubtitulo";
            labelSubtitulo.Size = new Size(291, 17);
            labelSubtitulo.TabIndex = 12;
            labelSubtitulo.Text = "Vista completa de todos los eventos del sistema";
            // 
            // labelTitulo
            // 
            labelTitulo.AutoSize = true;
            labelTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTitulo.Location = new Point(20, 20);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new Size(218, 32);
            labelTitulo.TabIndex = 11;
            labelTitulo.Text = "Todos los Eventos";
            // 
            // panelEventos
            // 
            panelEventos.AutoScroll = true;
            panelEventos.BackColor = Color.White;
            panelEventos.Location = new Point(0, 101);
            panelEventos.Name = "panelEventos";
            panelEventos.Size = new Size(1173, 593);
            panelEventos.TabIndex = 13;
            // 
            // UCEventoAdministrador
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(panelEventos);
            Controls.Add(labelSubtitulo);
            Controls.Add(labelTitulo);
            Name = "UCEventoAdministrador";
            Size = new Size(1173, 697);
            Load += UCEventoAdministrador_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelSubtitulo;
        private Label labelTitulo;
        private Panel panelEventos;
    }
}
