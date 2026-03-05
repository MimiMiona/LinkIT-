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
            flowEventos = new FlowLayoutPanel();
            label1 = new Label();
            labelSubtitulo = new Label();
            SuspendLayout();
            // 
            // textBoxBucar
            // 
            textBoxBucar.Font = new Font("Segoe UI", 10F);
            textBoxBucar.ForeColor = SystemColors.AppWorkspace;
            textBoxBucar.Location = new Point(23, 90);
            textBoxBucar.Name = "textBoxBucar";
            textBoxBucar.Size = new Size(1118, 25);
            textBoxBucar.TabIndex = 6;
            textBoxBucar.Text = "🔍 Buscar eventos por titulos o descripcion...";
            // 
            // flowEventos
            // 
            flowEventos.AutoScroll = true;
            flowEventos.BackColor = Color.White;
            flowEventos.FlowDirection = FlowDirection.TopDown;
            flowEventos.Location = new Point(0, 120);
            flowEventos.Name = "flowEventos";
            flowEventos.Size = new Size(1173, 697);
            flowEventos.TabIndex = 7;
            flowEventos.WrapContents = false;
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
            // UCExplorarEventos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(labelSubtitulo);
            Controls.Add(label1);
            Controls.Add(flowEventos);
            Controls.Add(textBoxBucar);
            Name = "UCExplorarEventos";
            Size = new Size(1173, 697);
            Load += UCExplorarEventos_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBoxBucar;
        private FlowLayoutPanel flowEventos;
        private Label label1;
        private Label labelSubtitulo;
    }
}
