namespace LinkIT_
{
    partial class Usuario
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            buttonCalendario = new Button();
            buttonInscriptos = new Button();
            label2 = new Label();
            buttonCerrarSesion = new Button();
            BotonMisEventos = new Button();
            panel2 = new Panel();
            Nombre = new Label();
            pictureBox1 = new PictureBox();
            panelUsuario = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.MintCream;
            panel1.Controls.Add(buttonCalendario);
            panel1.Controls.Add(buttonInscriptos);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(buttonCerrarSesion);
            panel1.Controls.Add(BotonMisEventos);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(1, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(208, 694);
            panel1.TabIndex = 1;
            // 
            // buttonCalendario
            // 
            buttonCalendario.BackColor = Color.MediumSeaGreen;
            buttonCalendario.FlatAppearance.BorderSize = 0;
            buttonCalendario.FlatStyle = FlatStyle.Flat;
            buttonCalendario.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonCalendario.ForeColor = Color.White;
            buttonCalendario.Location = new Point(11, 175);
            buttonCalendario.Name = "buttonCalendario";
            buttonCalendario.Size = new Size(169, 33);
            buttonCalendario.TabIndex = 8;
            buttonCalendario.Text = "🗓️ Calendario";
            buttonCalendario.UseVisualStyleBackColor = false;
            // 
            // buttonInscriptos
            // 
            buttonInscriptos.BackColor = Color.MediumSeaGreen;
            buttonInscriptos.FlatAppearance.BorderSize = 0;
            buttonInscriptos.FlatStyle = FlatStyle.Flat;
            buttonInscriptos.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonInscriptos.ForeColor = Color.White;
            buttonInscriptos.Location = new Point(11, 136);
            buttonInscriptos.Name = "buttonInscriptos";
            buttonInscriptos.Size = new Size(169, 33);
            buttonInscriptos.TabIndex = 7;
            buttonInscriptos.Text = "❤️ Mis Eventos";
            buttonInscriptos.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 624);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 0;
            label2.Text = "label2";
            // 
            // buttonCerrarSesion
            // 
            buttonCerrarSesion.BackColor = Color.Transparent;
            buttonCerrarSesion.FlatStyle = FlatStyle.Flat;
            buttonCerrarSesion.ForeColor = Color.Black;
            buttonCerrarSesion.Location = new Point(11, 652);
            buttonCerrarSesion.Name = "buttonCerrarSesion";
            buttonCerrarSesion.Size = new Size(169, 33);
            buttonCerrarSesion.TabIndex = 5;
            buttonCerrarSesion.Text = "Cerrar Sesion ";
            buttonCerrarSesion.UseVisualStyleBackColor = false;
            // 
            // BotonMisEventos
            // 
            BotonMisEventos.BackColor = Color.MediumSeaGreen;
            BotonMisEventos.FlatAppearance.BorderSize = 0;
            BotonMisEventos.FlatStyle = FlatStyle.Flat;
            BotonMisEventos.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BotonMisEventos.ForeColor = Color.White;
            BotonMisEventos.Location = new Point(11, 97);
            BotonMisEventos.Name = "BotonMisEventos";
            BotonMisEventos.Size = new Size(169, 33);
            BotonMisEventos.TabIndex = 0;
            BotonMisEventos.Text = "🔍 Explorar Eventos ";
            BotonMisEventos.UseVisualStyleBackColor = true;
            BotonMisEventos.Click += BotonMisEventos_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Honeydew;
            panel2.Controls.Add(Nombre);
            panel2.Controls.Add(pictureBox1);
            panel2.Location = new Point(0, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(197, 65);
            panel2.TabIndex = 1;
            // 
            // Nombre
            // 
            Nombre.AutoSize = true;
            Nombre.Font = new Font("Segoe UI", 11F);
            Nombre.Location = new Point(64, 24);
            Nombre.Name = "Nombre";
            Nombre.Size = new Size(52, 20);
            Nombre.TabIndex = 1;
            Nombre.Text = "Link it!";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.LogoLinkIT2;
            pictureBox1.Location = new Point(11, 11);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(47, 42);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panelUsuario
            // 
            panelUsuario.Location = new Point(204, 0);
            panelUsuario.Name = "panelUsuario";
            panelUsuario.Size = new Size(1173, 697);
            panelUsuario.TabIndex = 2;
            // 
            // FormUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1208, 692);
            Controls.Add(panelUsuario);
            Controls.Add(panel1);
            Name = "FormUsuario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormUsuario";
            WindowState = FormWindowState.Maximized;
            Load += FormUsuario_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button buttonCalendario;
        private Button buttonInscriptos;
        private Label label2;
        private Button buttonCerrarSesion;
        private Button BotonMisEventos;
        private Panel panel2;
        private Label Nombre;
        private PictureBox pictureBox1;
        private Panel panelUsuario;
    }
}