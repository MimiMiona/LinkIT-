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
            bRestaurarBackup = new Button();
            bHacerBackup = new Button();
            bUsuarioTotales = new Button();
            bJefeEventos = new Button();
            bEventos = new Button();
            lblUsuario = new Label();
            bCerrarSesion = new Button();
            bDashboard = new Button();
            panel2 = new Panel();
            Nombre = new Label();
            pictureBox1 = new PictureBox();
            panel3 = new Panel();
            label1 = new Label();
            panelAdministrador = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.MintCream;
            panel1.Controls.Add(bRestaurarBackup);
            panel1.Controls.Add(bHacerBackup);
            panel1.Controls.Add(bUsuarioTotales);
            panel1.Controls.Add(bJefeEventos);
            panel1.Controls.Add(bEventos);
            panel1.Controls.Add(lblUsuario);
            panel1.Controls.Add(bCerrarSesion);
            panel1.Controls.Add(bDashboard);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(panel3);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(208, 694);
            panel1.TabIndex = 2;
            // 
            // bRestaurarBackup
            // 
            bRestaurarBackup.BackColor = Color.MediumSeaGreen;
            bRestaurarBackup.FlatAppearance.BorderSize = 0;
            bRestaurarBackup.FlatStyle = FlatStyle.Flat;
            bRestaurarBackup.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bRestaurarBackup.ForeColor = Color.White;
            bRestaurarBackup.Location = new Point(11, 292);
            bRestaurarBackup.Name = "bRestaurarBackup";
            bRestaurarBackup.Size = new Size(169, 33);
            bRestaurarBackup.TabIndex = 12;
            bRestaurarBackup.Text = "🔼 Restaurar Backup";
            bRestaurarBackup.UseVisualStyleBackColor = true;
            bRestaurarBackup.Click += bRestaurarBackup_Click;
            // 
            // bHacerBackup
            // 
            bHacerBackup.BackColor = Color.MediumSeaGreen;
            bHacerBackup.FlatAppearance.BorderSize = 0;
            bHacerBackup.FlatStyle = FlatStyle.Flat;
            bHacerBackup.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bHacerBackup.ForeColor = Color.White;
            bHacerBackup.Location = new Point(12, 253);
            bHacerBackup.Name = "bHacerBackup";
            bHacerBackup.Size = new Size(169, 33);
            bHacerBackup.TabIndex = 11;
            bHacerBackup.Text = "💾 Hacer Backup";
            bHacerBackup.UseVisualStyleBackColor = true;
            bHacerBackup.Click += bBackup_Click;
            // 
            // bUsuarioTotales
            // 
            bUsuarioTotales.BackColor = Color.MediumSeaGreen;
            bUsuarioTotales.FlatAppearance.BorderSize = 0;
            bUsuarioTotales.FlatStyle = FlatStyle.Flat;
            bUsuarioTotales.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bUsuarioTotales.ForeColor = Color.White;
            bUsuarioTotales.Location = new Point(11, 214);
            bUsuarioTotales.Name = "bUsuarioTotales";
            bUsuarioTotales.Size = new Size(169, 33);
            bUsuarioTotales.TabIndex = 10;
            bUsuarioTotales.Text = "👤 Usuarios Totales";
            bUsuarioTotales.UseVisualStyleBackColor = true;
            bUsuarioTotales.Click += bUsuarioTotales_Click;
            // 
            // bJefeEventos
            // 
            bJefeEventos.BackColor = Color.MediumSeaGreen;
            bJefeEventos.FlatAppearance.BorderSize = 0;
            bJefeEventos.FlatStyle = FlatStyle.Flat;
            bJefeEventos.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bJefeEventos.ForeColor = Color.White;
            bJefeEventos.Location = new Point(12, 175);
            bJefeEventos.Name = "bJefeEventos";
            bJefeEventos.Size = new Size(169, 33);
            bJefeEventos.TabIndex = 9;
            bJefeEventos.Text = "\U0001f91d Jefe de Eventos";
            bJefeEventos.UseVisualStyleBackColor = true;
            bJefeEventos.Click += bJefeEventos_Click;
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
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblUsuario.Location = new Point(23, 592);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(40, 15);
            lblUsuario.TabIndex = 0;
            lblUsuario.Text = "label2";
            // 
            // bCerrarSesion
            // 
            bCerrarSesion.BackColor = Color.Transparent;
            bCerrarSesion.FlatStyle = FlatStyle.Flat;
            bCerrarSesion.ForeColor = Color.Black;
            bCerrarSesion.Location = new Point(11, 652);
            bCerrarSesion.Name = "bCerrarSesion";
            bCerrarSesion.Size = new Size(169, 33);
            bCerrarSesion.TabIndex = 5;
            bCerrarSesion.Text = "Cerrar Sesion ";
            bCerrarSesion.UseVisualStyleBackColor = false;
            bCerrarSesion.Click += bCerrarSesion_Click;
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
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Honeydew;
            panel3.Controls.Add(label1);
            panel3.Location = new Point(3, 581);
            panel3.Name = "panel3";
            panel3.Size = new Size(205, 65);
            panel3.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.WindowFrame;
            label1.Location = new Point(20, 39);
            label1.Name = "label1";
            label1.Size = new Size(83, 15);
            label1.TabIndex = 13;
            label1.Text = "Administrador";
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
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button bEventos;
        private Label lblUsuario;
        private Button bCerrarSesion;
        private Button bDashboard;
        private Panel panel2;
        private Label Nombre;
        private PictureBox pictureBox1;
        private Panel panelAdministrador;
        private Button bJefeEventos;
        private Button bUsuarioTotales;
        private Button bHacerBackup;
        private Button bRestaurarBackup;
        private Panel panel3;
        private Label label1;
    }
}