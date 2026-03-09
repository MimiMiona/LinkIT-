namespace LinkIT_
{
    partial class FormVerConsulta
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
            textDescripcion = new TextBox();
            bAtendida = new Button();
            SuspendLayout();
            // 
            // textDescripcion
            // 
            textDescripcion.Location = new Point(71, 37);
            textDescripcion.Multiline = true;
            textDescripcion.Name = "textDescripcion";
            textDescripcion.Size = new Size(627, 261);
            textDescripcion.TabIndex = 0;
            // 
            // bAtendida
            // 
            bAtendida.Location = new Point(552, 331);
            bAtendida.Name = "bAtendida";
            bAtendida.Size = new Size(184, 48);
            bAtendida.TabIndex = 1;
            bAtendida.Text = "Atendido";
            bAtendida.UseVisualStyleBackColor = true;
            bAtendida.Click += bAtendida_Click;
            // 
            // FormVerConsulta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(bAtendida);
            Controls.Add(textDescripcion);
            Name = "FormVerConsulta";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textDescripcion;
        private Button bAtendida;
    }
}