namespace LinkIT_
{
    partial class UCExplorarEventos
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
            textBoxBucar = new TextBox();
            label1 = new Label();
            labelSubtitulo = new Label();
            panelEventos = new Panel();
            button1 = new Button();
            SuspendLayout();
            // 
            // textBoxBucar
            // 
            textBoxBucar.Font = new Font("Segoe UI", 10F);
            textBoxBucar.ForeColor = SystemColors.ActiveCaptionText;
            textBoxBucar.Location = new Point(23, 90);
            textBoxBucar.Name = "textBoxBucar";
            textBoxBucar.Size = new Size(1054, 25);
            textBoxBucar.TabIndex = 6;
            textBoxBucar.TextChanged += bBuscador_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(20, 20);
            label1.Name = "label1";
            label1.Size = new Size(206, 32);
            label1.TabIndex = 6;
            label1.Text = "Explorar Eventos";
            // 
            // labelSubtitulo
            // 
            labelSubtitulo.AutoSize = true;
            labelSubtitulo.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelSubtitulo.ForeColor = SystemColors.ActiveCaptionText;
            labelSubtitulo.Location = new Point(23, 55);
            labelSubtitulo.Name = "labelSubtitulo";
            labelSubtitulo.Size = new Size(380, 17);
            labelSubtitulo.TabIndex = 8;
            labelSubtitulo.Text = "Descubre los eventos disponibles y unete a los que te interesen";
            // 
            // panelEventos
            // 
            panelEventos.AutoScroll = true;
            panelEventos.Location = new Point(23, 121);
            panelEventos.Name = "panelEventos";
            panelEventos.Size = new Size(1118, 551);
            panelEventos.TabIndex = 9;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.Window;
            button1.Enabled = false;
            button1.FlatStyle = FlatStyle.Popup;
            button1.ForeColor = SystemColors.ControlText;
            button1.Location = new Point(1083, 90);
            button1.Margin = new Padding(0);
            button1.Name = "button1";
            button1.Size = new Size(46, 25);
            button1.TabIndex = 10;
            button1.TabStop = false;
            button1.Text = "🔍";
            button1.UseVisualStyleBackColor = false;
            // 
            // UCExplorarEventos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button1);
            Controls.Add(panelEventos);
            Controls.Add(labelSubtitulo);
            Controls.Add(label1);
            Controls.Add(textBoxBucar);
            Name = "UCExplorarEventos";
            Size = new Size(1173, 697);
            Load += UCExplorarEventos_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBoxBucar;
        private Label label1;
        private Label labelSubtitulo;
        private Panel panelEventos;
        private Button button1;
    }
}
