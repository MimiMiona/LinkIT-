namespace LinkIT_
{
    partial class UCRevisionUsuarios
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            labelSubtitulo = new Label();
            labelTitulo = new Label();
            panelSinSolicitudes = new Panel();
            labelSinSolicitudes = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panelSinSolicitudes.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(19, 95);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1126, 581);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // labelSubtitulo
            // 
            labelSubtitulo.AutoSize = true;
            labelSubtitulo.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelSubtitulo.ForeColor = SystemColors.ActiveCaptionText;
            labelSubtitulo.Location = new Point(23, 55);
            labelSubtitulo.Name = "labelSubtitulo";
            labelSubtitulo.Size = new Size(332, 17);
            labelSubtitulo.TabIndex = 12;
            labelSubtitulo.Text = "Acepte o deniegue la solicitudes de registro de usuario";
            // 
            // labelTitulo
            // 
            labelTitulo.AutoSize = true;
            labelTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTitulo.Location = new Point(20, 20);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new Size(275, 32);
            labelTitulo.TabIndex = 11;
            labelTitulo.Text = "Solicitudes de Registro";
            // 
            // panelSinSolicitudes
            // 
            panelSinSolicitudes.BorderStyle = BorderStyle.FixedSingle;
            panelSinSolicitudes.Controls.Add(labelSinSolicitudes);
            panelSinSolicitudes.Location = new Point(19, 95);
            panelSinSolicitudes.Name = "panelSinSolicitudes";
            panelSinSolicitudes.Size = new Size(1126, 581);
            panelSinSolicitudes.TabIndex = 13;
            // 
            // labelSinSolicitudes
            // 
            labelSinSolicitudes.AutoSize = true;
            labelSinSolicitudes.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelSinSolicitudes.ForeColor = SystemColors.ControlDarkDark;
            labelSinSolicitudes.Location = new Point(420, 187);
            labelSinSolicitudes.Name = "labelSinSolicitudes";
            labelSinSolicitudes.Size = new Size(291, 30);
            labelSinSolicitudes.TabIndex = 1;
            labelSinSolicitudes.Text = "No hay solicitudes pendientes";
            labelSinSolicitudes.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UCRevisionUsuarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dataGridView1);
            Controls.Add(labelSubtitulo);
            Controls.Add(labelTitulo);
            Controls.Add(panelSinSolicitudes);
            Name = "UCRevisionUsuarios";
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
    }
}