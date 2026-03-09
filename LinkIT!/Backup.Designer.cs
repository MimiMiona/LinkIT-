namespace LinkIT_
{
    partial class Backup
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
            label1 = new Label();
            bCancelar = new Button();
            bAceptar = new Button();
            txtClave = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(238, 96);
            label1.Name = "label1";
            label1.Size = new Size(282, 17);
            label1.TabIndex = 0;
            label1.Text = "Ingrese su Contraseña para Cargar el Backup";
            // 
            // bCancelar
            // 
            bCancelar.Location = new Point(110, 219);
            bCancelar.Name = "bCancelar";
            bCancelar.Size = new Size(100, 36);
            bCancelar.TabIndex = 2;
            bCancelar.Text = "Cancelar";
            bCancelar.UseVisualStyleBackColor = true;
            bCancelar.Click += bCancelar_Click;
            // 
            // bAceptar
            // 
            bAceptar.Location = new Point(530, 219);
            bAceptar.Name = "bAceptar";
            bAceptar.Size = new Size(100, 36);
            bAceptar.TabIndex = 3;
            bAceptar.Text = "Aceptar";
            bAceptar.UseVisualStyleBackColor = true;
            bAceptar.Click += bAceptar_Click;
            // 
            // txtClave
            // 
            txtClave.Location = new Point(155, 154);
            txtClave.Name = "txtClave";
            txtClave.PasswordChar = '*';
            txtClave.Size = new Size(432, 23);
            txtClave.TabIndex = 4;
            txtClave.UseSystemPasswordChar = true;
            // 
            // Backup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 322);
            Controls.Add(txtClave);
            Controls.Add(bAceptar);
            Controls.Add(bCancelar);
            Controls.Add(label1);
            Name = "Backup";
            Text = "Backup";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button bCancelar;
        private Button bAceptar;
        private TextBox txtClave;
    }
}

