namespace LinkIT_
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            label1 = new Label();
            label2 = new Label();
            txtClave = new TextBox();
            txtUsuario = new TextBox();
            bIngresar = new Button();
            pictureBox1 = new PictureBox();
            bEliminar = new Button();
            bSalir = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(80, 72);
            label1.Name = "label1";
            label1.Size = new Size(79, 28);
            label1.TabIndex = 0;
            label1.Text = "Usuario";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F);
            label2.Location = new Point(80, 110);
            label2.Name = "label2";
            label2.Size = new Size(59, 28);
            label2.TabIndex = 1;
            label2.Text = "Clave";
            // 
            // txtClave
            // 
            txtClave.Location = new Point(184, 110);
            txtClave.Name = "txtClave";
            txtClave.PasswordChar = '*';
            txtClave.Size = new Size(130, 23);
            txtClave.TabIndex = 2;
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(184, 72);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(130, 23);
            txtUsuario.TabIndex = 3;
            // 
            // bIngresar
            // 
            bIngresar.BackColor = Color.PaleGoldenrod;
            bIngresar.FlatAppearance.BorderColor = Color.White;
            bIngresar.FlatStyle = FlatStyle.Popup;
            bIngresar.Font = new Font("Segoe UI", 11F);
            bIngresar.Location = new Point(63, 177);
            bIngresar.Name = "bIngresar";
            bIngresar.Size = new Size(96, 34);
            bIngresar.TabIndex = 4;
            bIngresar.Text = "Ingresar";
            bIngresar.UseVisualStyleBackColor = false;
            bIngresar.Click += bIngresar_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(383, 51);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(218, 216);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // bEliminar
            // 
            bEliminar.BackColor = Color.PaleGoldenrod;
            bEliminar.FlatAppearance.BorderColor = Color.White;
            bEliminar.FlatStyle = FlatStyle.Popup;
            bEliminar.Font = new Font("Segoe UI", 11F);
            bEliminar.Location = new Point(211, 177);
            bEliminar.Name = "bEliminar";
            bEliminar.Size = new Size(103, 34);
            bEliminar.TabIndex = 7;
            bEliminar.Text = "Limpiar";
            bEliminar.UseVisualStyleBackColor = false;
            bEliminar.Click += bEliminar_Click;
            // 
            // bSalir
            // 
            bSalir.BackColor = Color.PaleGoldenrod;
            bSalir.FlatAppearance.BorderColor = Color.White;
            bSalir.FlatStyle = FlatStyle.Popup;
            bSalir.Font = new Font("Segoe UI", 11F);
            bSalir.Location = new Point(136, 231);
            bSalir.Name = "bSalir";
            bSalir.Size = new Size(103, 34);
            bSalir.TabIndex = 8;
            bSalir.Text = "Salir";
            bSalir.UseVisualStyleBackColor = false;
            bSalir.Click += bSalir_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Ivory;
            ClientSize = new Size(639, 308);
            Controls.Add(bSalir);
            Controls.Add(bEliminar);
            Controls.Add(pictureBox1);
            Controls.Add(bIngresar);
            Controls.Add(txtUsuario);
            Controls.Add(txtClave);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtClave;
        private TextBox txtUsuario;
        private Button bIngresar;
        private PictureBox pictureBox1;
        private Button bEliminar;
        private Button bSalir;
    }
}
