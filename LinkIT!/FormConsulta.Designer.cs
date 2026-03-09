namespace LinkIT_
{
    partial class FormConsulta
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
            textDescripcion = new TextBox();
            bEnviar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(110, 53);
            label1.Name = "label1";
            label1.Size = new Size(201, 28);
            label1.TabIndex = 0;
            label1.Text = "Describa su problema";
            // 
            // textDescripcion
            // 
            textDescripcion.Location = new Point(107, 88);
            textDescripcion.Multiline = true;
            textDescripcion.Name = "textDescripcion";
            textDescripcion.Size = new Size(433, 193);
            textDescripcion.TabIndex = 1;
            // 
            // bEnviar
            // 
            bEnviar.Location = new Point(540, 305);
            bEnviar.Name = "bEnviar";
            bEnviar.Size = new Size(122, 33);
            bEnviar.TabIndex = 2;
            bEnviar.Text = "Enviar";
            bEnviar.UseVisualStyleBackColor = true;
            bEnviar.Click += bEnviar_Click;
            // 
            // FormConsulta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 381);
            Controls.Add(bEnviar);
            Controls.Add(textDescripcion);
            Controls.Add(label1);
            Name = "FormConsulta";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textDescripcion;
        private Button bEnviar;
    }
}