namespace LinkIT_
{
    partial class JefeEventos
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
            button1 = new Button();
            bUsuarios = new Button();
            buttonCalendario = new Button();
            buttonInscriptos = new Button();
            buttonCerrarSesion = new Button();
            BotonMisEventos = new Button();
            panel2 = new Panel();
            Nombre = new Label();
            pictureBox1 = new PictureBox();
            panelJefeEvento = new Panel();
            panel3 = new Panel();
            label1 = new Label();
            lblUsuario = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.MintCream;
            panel1.Controls.Add(button1);
            panel1.Controls.Add(bUsuarios);
            panel1.Controls.Add(buttonCalendario);
            panel1.Controls.Add(buttonInscriptos);
            panel1.Controls.Add(buttonCerrarSesion);
            panel1.Controls.Add(BotonMisEventos);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(1, -2);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 697);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // button1
            // 
            button1.BackColor = Color.MediumSeaGreen;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(11, 253);
            button1.Name = "button1";
            button1.Size = new Size(169, 33);
            button1.TabIndex = 10;
            button1.Text = "Consultas";
            button1.UseVisualStyleBackColor = false;
            // 
            // bUsuarios
            // 
            bUsuarios.BackColor = Color.MediumSeaGreen;
            bUsuarios.FlatAppearance.BorderSize = 0;
            bUsuarios.FlatStyle = FlatStyle.Flat;
            bUsuarios.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bUsuarios.ForeColor = Color.White;
            bUsuarios.Location = new Point(11, 214);
            bUsuarios.Name = "bUsuarios";
            bUsuarios.Size = new Size(169, 33);
            bUsuarios.TabIndex = 9;
            bUsuarios.Text = "Solicitudes de Registro";
            bUsuarios.UseVisualStyleBackColor = false;
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
            buttonCalendario.Text = "Calendario";
            buttonCalendario.UseVisualStyleBackColor = false;
            buttonCalendario.Click += buttonCalendario_Click;
            buttonCalendario.MouseEnter += buttonCalendario_MouseEnter;
            buttonCalendario.MouseLeave += buttonCalendario_MouseLeave;
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
            buttonInscriptos.Text = "Inscriptos";
            buttonInscriptos.UseVisualStyleBackColor = false;
            buttonInscriptos.Click += buttonInscriptos_Click;
            buttonInscriptos.MouseEnter += buttonInscriptos_MouseEnter;
            buttonInscriptos.MouseLeave += buttonInscriptos_MouseLeave;
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
            BotonMisEventos.Text = "Mis Eventos";
            BotonMisEventos.UseVisualStyleBackColor = true;
            BotonMisEventos.Click += BotonMisEventos_Click;
            BotonMisEventos.MouseEnter += BotonMisEventos_MouseEnter;
            BotonMisEventos.MouseLeave += BotonMisEventos_MouseLeave;
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
            // panelJefeEvento
            // 
            panelJefeEvento.Location = new Point(198, -2);
            panelJefeEvento.Name = "panelJefeEvento";
            panelJefeEvento.Size = new Size(1173, 697);
            panelJefeEvento.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Honeydew;
            panel3.Controls.Add(lblUsuario);
            panel3.Controls.Add(label1);
            panel3.Location = new Point(1, 579);
            panel3.Name = "panel3";
            panel3.Size = new Size(200, 65);
            panel3.TabIndex = 12;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.WindowFrame;
            label1.Location = new Point(20, 39);
            label1.Name = "label1";
            label1.Size = new Size(87, 15);
            label1.TabIndex = 13;
            label1.Text = "Jefe de Eventos";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblUsuario.Location = new Point(20, 13);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(40, 15);
            lblUsuario.TabIndex = 14;
            lblUsuario.Text = "label2";
            // 
            // JefeEventos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1370, 692);
            Controls.Add(panel3);
            Controls.Add(panelJefeEvento);
            Controls.Add(panel1);
            Name = "JefeEventos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Link it!";
            WindowState = FormWindowState.Maximized;
            Load += FormJefeEventos_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private PictureBox pictureBox1;
        private Panel panelJefeEvento;
        private Label Nombre;
        private Button buttonCerrarSesion;
        private Button BotonMisEventos;
        private Button buttonCalendario;
        private Button buttonInscriptos;
        private Button button1;
        private Button bUsuarios;
        private Panel panel3;
        private Label label1;
        private Label lblUsuario;
    }
}