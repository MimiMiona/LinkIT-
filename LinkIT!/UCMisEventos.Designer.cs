namespace LinkIT_
{
    partial class UCMisEventos
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelEventos;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelEventos = new Panel();
            labelSubtitulo = new Label();
            labelTitulo = new Label();
            BotonCrearEvento = new Button();
            button1 = new Button();
            textBoxBuscar = new TextBox();
            SuspendLayout();
            // 
            // panelEventos
            // 
            panelEventos.AutoScroll = true;
            panelEventos.BackColor = Color.White;
            panelEventos.Location = new Point(0, 132);
            panelEventos.Name = "panelEventos";
            panelEventos.Size = new Size(1170, 565);
            panelEventos.TabIndex = 0;
            // 
            // labelSubtitulo
            // 
            labelSubtitulo.AutoSize = true;
            labelSubtitulo.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelSubtitulo.ForeColor = SystemColors.ActiveCaptionText;
            labelSubtitulo.Location = new Point(23, 55);
            labelSubtitulo.Name = "labelSubtitulo";
            labelSubtitulo.Size = new Size(380, 17);
            labelSubtitulo.TabIndex = 10;
            labelSubtitulo.Text = "Descubre los eventos disponibles y unete a los que te interesen";
            // 
            // labelTitulo
            // 
            labelTitulo.AutoSize = true;
            labelTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTitulo.Location = new Point(20, 20);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new Size(151, 32);
            labelTitulo.TabIndex = 9;
            labelTitulo.Text = "Mis Eventos";
            // 
            // BotonCrearEvento
            // 
            BotonCrearEvento.BackColor = Color.MediumSeaGreen;
            BotonCrearEvento.FlatAppearance.BorderSize = 0;
            BotonCrearEvento.FlatStyle = FlatStyle.Flat;
            BotonCrearEvento.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BotonCrearEvento.ForeColor = Color.White;
            BotonCrearEvento.Location = new Point(1030, 39);
            BotonCrearEvento.Name = "BotonCrearEvento";
            BotonCrearEvento.Size = new Size(112, 33);
            BotonCrearEvento.TabIndex = 11;
            BotonCrearEvento.Text = "+ Crear Evento";
            BotonCrearEvento.UseVisualStyleBackColor = true;
            BotonCrearEvento.Click += BotonCrearEvento_Click;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.Window;
            button1.Enabled = false;
            button1.FlatStyle = FlatStyle.Popup;
            button1.ForeColor = SystemColors.ControlText;
            button1.Location = new Point(1083, 101);
            button1.Margin = new Padding(0);
            button1.Name = "button1";
            button1.Size = new Size(46, 25);
            button1.TabIndex = 12;
            button1.TabStop = false;
            button1.Text = "🔍";
            button1.UseVisualStyleBackColor = false;
            // 
            // textBoxBuscar
            // 
            textBoxBuscar.Font = new Font("Segoe UI", 10F);
            textBoxBuscar.ForeColor = SystemColors.ActiveCaptionText;
            textBoxBuscar.Location = new Point(20, 101);
            textBoxBuscar.Name = "textBoxBuscar";
            textBoxBuscar.Size = new Size(1054, 25);
            textBoxBuscar.TabIndex = 11;
            textBoxBuscar.TextChanged += textBoxBuscar_TextChanged;
            // 
            // UCMisEventos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Ivory;
            Controls.Add(button1);
            Controls.Add(BotonCrearEvento);
            Controls.Add(textBoxBuscar);
            Controls.Add(labelSubtitulo);
            Controls.Add(labelTitulo);
            Controls.Add(panelEventos);
            Name = "UCMisEventos";
            Size = new Size(1173, 697);
            Load += UCMisEventos_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private Label labelSubtitulo;
        private Label labelTitulo;
        private Button BotonCrearEvento;
        private Button button1;
        private TextBox textBoxBuscar;
    }
}