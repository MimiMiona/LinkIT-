namespace LinkIT_
{
    partial class Registro
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
            bVolver = new Button();
            label4 = new Label();
            label3 = new Label();
            labelClave = new Label();
            label1 = new Label();
            textClave = new TextBox();
            textNombre = new TextBox();
            textDNI = new TextBox();
            textCorreo = new TextBox();
            bGuardar = new Button();
            bLimpiar = new Button();
            SuspendLayout();
            // 
            // bVolver
            // 
            bVolver.Location = new Point(619, 390);
            bVolver.Name = "bVolver";
            bVolver.Size = new Size(103, 34);
            bVolver.TabIndex = 0;
            bVolver.Text = "Volver";
            bVolver.UseVisualStyleBackColor = true;
            bVolver.Click += bVolver_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15F);
            label4.Location = new Point(164, 128);
            label4.Name = "label4";
            label4.Size = new Size(72, 28);
            label4.TabIndex = 21;
            label4.Text = "Correo";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F);
            label3.Location = new Point(164, 85);
            label3.Name = "label3";
            label3.Size = new Size(46, 28);
            label3.TabIndex = 20;
            label3.Text = "DNI";
            // 
            // labelClave
            // 
            labelClave.AutoSize = true;
            labelClave.Font = new Font("Segoe UI", 15F);
            labelClave.Location = new Point(164, 172);
            labelClave.Name = "labelClave";
            labelClave.Size = new Size(59, 28);
            labelClave.TabIndex = 19;
            labelClave.Text = "Clave";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(164, 42);
            label1.Name = "label1";
            label1.Size = new Size(85, 28);
            label1.TabIndex = 18;
            label1.Text = "Nombre";
            // 
            // textClave
            // 
            textClave.Location = new Point(261, 177);
            textClave.Name = "textClave";
            textClave.Size = new Size(324, 23);
            textClave.TabIndex = 17;
            // 
            // textNombre
            // 
            textNombre.Location = new Point(261, 47);
            textNombre.Name = "textNombre";
            textNombre.Size = new Size(324, 23);
            textNombre.TabIndex = 16;
            // 
            // textDNI
            // 
            textDNI.Location = new Point(261, 90);
            textDNI.Name = "textDNI";
            textDNI.Size = new Size(324, 23);
            textDNI.TabIndex = 15;
            // 
            // textCorreo
            // 
            textCorreo.Location = new Point(261, 133);
            textCorreo.Name = "textCorreo";
            textCorreo.Size = new Size(324, 23);
            textCorreo.TabIndex = 14;
            // 
            // bGuardar
            // 
            bGuardar.Location = new Point(164, 248);
            bGuardar.Name = "bGuardar";
            bGuardar.Size = new Size(176, 57);
            bGuardar.TabIndex = 22;
            bGuardar.Text = "Guardar";
            bGuardar.UseVisualStyleBackColor = true;
            bGuardar.Click += bGuardar_Click;
            // 
            // bLimpiar
            // 
            bLimpiar.Location = new Point(433, 248);
            bLimpiar.Name = "bLimpiar";
            bLimpiar.Size = new Size(176, 57);
            bLimpiar.TabIndex = 23;
            bLimpiar.Text = "Limpiar";
            bLimpiar.UseVisualStyleBackColor = true;
            bLimpiar.Click += bLimpiar_Click;
            // 
            // Registro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(bLimpiar);
            Controls.Add(bGuardar);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(labelClave);
            Controls.Add(label1);
            Controls.Add(textClave);
            Controls.Add(textNombre);
            Controls.Add(textDNI);
            Controls.Add(textCorreo);
            Controls.Add(bVolver);
            Name = "Registro";
            Text = "Registro";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button bVolver;
        private Label label4;
        private Label label3;
        private Label labelClave;
        private Label label1;
        private TextBox textClave;
        private TextBox textNombre;
        private TextBox textDNI;
        private TextBox textCorreo;
        private Button bGuardar;
        private Button bLimpiar;
    }
}