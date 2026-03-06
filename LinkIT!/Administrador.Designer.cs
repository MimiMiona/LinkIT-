namespace LinkIT_
{
    partial class Administrador
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
            bJefeEventos = new Button();
            bUsuarios = new Button();
            bEventos = new Button();
            label2 = new Label();
            buttonCerrarSesion = new Button();
            bDashboard = new Button();
            panel2 = new Panel();
            Nombre = new Label();
            pictureBox1 = new PictureBox();
            panelAdministrador = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.MintCream;
            panel1.Controls.Add(button1);
            panel1.Controls.Add(bJefeEventos);
            panel1.Controls.Add(bUsuarios);
            panel1.Controls.Add(bEventos);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(buttonCerrarSesion);
            panel1.Controls.Add(bDashboard);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(208, 694);
            panel1.TabIndex = 2;
            // 
            // button1
            // 
            button1.BackColor = Color.MediumSeaGreen;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(12, 450);
            button1.Name = "button1";
            button1.Size = new Size(169, 33);
            button1.TabIndex = 10;
            button1.Text = "Usuarios Total";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // bJefeEventos
            // 
            bJefeEventos.BackColor = Color.MediumSeaGreen;
            bJefeEventos.FlatAppearance.BorderSize = 0;
            bJefeEventos.FlatStyle = FlatStyle.Flat;
            bJefeEventos.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bJefeEventos.ForeColor = Color.White;
            bJefeEventos.Location = new Point(12, 214);
            bJefeEventos.Name = "bJefeEventos";
            bJefeEventos.Size = new Size(169, 33);
            bJefeEventos.TabIndex = 9;
            bJefeEventos.Text = "\U0001f91d Jefe de Eventos";
            bJefeEventos.UseVisualStyleBackColor = true;
            // 
            // bUsuarios
            // 
            bUsuarios.BackColor = Color.MediumSeaGreen;
            bUsuarios.FlatAppearance.BorderSize = 0;
            bUsuarios.FlatStyle = FlatStyle.Flat;
            bUsuarios.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bUsuarios.ForeColor = Color.White;
            bUsuarios.Location = new Point(11, 175);
            bUsuarios.Name = "bUsuarios";
            bUsuarios.Size = new Size(169, 33);
            bUsuarios.TabIndex = 8;
            bUsuarios.Text = "👤 Usuarios Inscriptos";
            bUsuarios.UseVisualStyleBackColor = false;
            bUsuarios.Click += bUsuarios_Click;
            // 
            // bEventos
            // 
            bEventos.BackColor = Color.MediumSeaGreen;
            bEventos.FlatAppearance.BorderSize = 0;
            bEventos.FlatStyle = FlatStyle.Flat;
            bEventos.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bEventos.ForeColor = Color.White;
            bEventos.Location = new Point(11, 136);
            bEventos.Name = "bEventos";
            bEventos.Size = new Size(169, 33);
            bEventos.TabIndex = 7;
            bEventos.Text = "🗓️ Eventos";
            bEventos.UseVisualStyleBackColor = false;
            bEventos.Click += bEventos_Click;
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
            // bDashboard
            // 
            bDashboard.BackColor = Color.MediumSeaGreen;
            bDashboard.FlatAppearance.BorderSize = 0;
            bDashboard.FlatStyle = FlatStyle.Flat;
            bDashboard.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bDashboard.ForeColor = Color.White;
            bDashboard.Location = new Point(11, 97);
            bDashboard.Name = "bDashboard";
            bDashboard.Size = new Size(169, 33);
            bDashboard.TabIndex = 0;
            bDashboard.Text = "💻 Dashboard";
            bDashboard.UseVisualStyleBackColor = true;
            bDashboard.Click += bDashboard_Click;
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
            // panelAdministrador
            // 
            panelAdministrador.BackColor = Color.White;
            panelAdministrador.Location = new Point(203, 0);
            panelAdministrador.Name = "panelAdministrador";
            panelAdministrador.Size = new Size(1173, 697);
            panelAdministrador.TabIndex = 3;
            // 
            // Administrador
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1370, 692);
            Controls.Add(panelAdministrador);
            Controls.Add(panel1);
            Name = "Administrador";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormAdministrador";
            WindowState = FormWindowState.Maximized;
            Load += FormAdministrador_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button bUsuarios;
        private Button bEventos;
        private Label label2;
        private Button buttonCerrarSesion;
        private Button bDashboard;
        private Panel panel2;
        private Label Nombre;
        private PictureBox pictureBox1;
        private Panel panelAdministrador;
        private Button bJefeEventos;
        private Button button1;
    }
}