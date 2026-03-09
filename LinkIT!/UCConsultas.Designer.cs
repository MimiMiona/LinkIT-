namespace LinkIT_
{
    partial class UCConsultas
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            labelSubtitulo = new Label();
            labelTitulo = new Label();
            panelSinSolicitudes = new Panel();
            labelSinConsultas = new Label();
            bMostrar = new Button();
            button1 = new Button();
            textBoxBuscar = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panelSinSolicitudes.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(19, 123);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Size = new Size(1126, 553);
            dataGridView1.TabIndex = 0;
            // 
            // labelSubtitulo
            // 
            labelSubtitulo.AutoSize = true;
            labelSubtitulo.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelSubtitulo.ForeColor = SystemColors.ActiveCaptionText;
            labelSubtitulo.Location = new Point(23, 55);
            labelSubtitulo.Name = "labelSubtitulo";
            labelSubtitulo.Size = new Size(367, 17);
            labelSubtitulo.TabIndex = 12;
            labelSubtitulo.Text = "Descubre las distintas problematicas o dudas de los usuarios";
            // 
            // labelTitulo
            // 
            labelTitulo.AutoSize = true;
            labelTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTitulo.Location = new Point(20, 20);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new Size(317, 32);
            labelTitulo.TabIndex = 11;
            labelTitulo.Text = "Visualizacion de Consultas";
            // 
            // panelSinSolicitudes
            // 
            panelSinSolicitudes.BorderStyle = BorderStyle.FixedSingle;
            panelSinSolicitudes.Controls.Add(labelSinConsultas);
            panelSinSolicitudes.Location = new Point(19, 123);
            panelSinSolicitudes.Name = "panelSinSolicitudes";
            panelSinSolicitudes.Size = new Size(1126, 553);
            panelSinSolicitudes.TabIndex = 14;
            // 
            // labelSinConsultas
            // 
            labelSinConsultas.AutoSize = true;
            labelSinConsultas.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelSinConsultas.ForeColor = SystemColors.ControlDarkDark;
            labelSinConsultas.Location = new Point(420, 187);
            labelSinConsultas.Name = "labelSinConsultas";
            labelSinConsultas.Size = new Size(281, 30);
            labelSinConsultas.TabIndex = 1;
            labelSinConsultas.Text = "No hay consultas pendientes";
            labelSinConsultas.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // bMostrar
            // 
            bMostrar.BackColor = Color.PaleGoldenrod;
            bMostrar.FlatStyle = FlatStyle.Popup;
            bMostrar.Location = new Point(982, 22);
            bMostrar.Name = "bMostrar";
            bMostrar.Size = new Size(142, 50);
            bMostrar.TabIndex = 15;
            bMostrar.Text = "Mostrar Atendidas";
            bMostrar.UseVisualStyleBackColor = false;
            bMostrar.Click += bMostrar_Click;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.Window;
            button1.Enabled = false;
            button1.FlatStyle = FlatStyle.Popup;
            button1.ForeColor = SystemColors.ControlText;
            button1.Location = new Point(1102, 92);
            button1.Margin = new Padding(0);
            button1.Name = "button1";
            button1.Size = new Size(43, 28);
            button1.TabIndex = 17;
            button1.TabStop = false;
            button1.Text = "🔍";
            button1.UseVisualStyleBackColor = false;
            // 
            // textBoxBuscar
            // 
            textBoxBuscar.Font = new Font("Segoe UI", 10F);
            textBoxBuscar.ForeColor = SystemColors.ActiveCaptionText;
            textBoxBuscar.Location = new Point(19, 92);
            textBoxBuscar.Name = "textBoxBuscar";
            textBoxBuscar.Size = new Size(1057, 25);
            textBoxBuscar.TabIndex = 16;
            textBoxBuscar.TextChanged += textBoxBuscar_TextChanged;
            // 
            // UCConsultas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button1);
            Controls.Add(textBoxBuscar);
            Controls.Add(bMostrar);
            Controls.Add(labelSubtitulo);
            Controls.Add(labelTitulo);
            Controls.Add(dataGridView1);
            Controls.Add(panelSinSolicitudes);
            Name = "UCConsultas";
            Size = new Size(1173, 697);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panelSinSolicitudes.ResumeLayout(false);
            panelSinSolicitudes.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label labelSubtitulo;
        private Label labelTitulo;
        private Panel panelSinSolicitudes;
        private Label labelSinSolicitudes;
        private Button bMostrar;
        private Label labelSinConsultas;
        private Button button1;
        private TextBox textBoxBuscar;
    }
}
