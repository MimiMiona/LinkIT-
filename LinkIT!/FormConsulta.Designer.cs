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
            labelPrincipal = new Label();
            bCancelar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(46, 71);
            label1.Name = "label1";
            label1.Size = new Size(195, 25);
            label1.TabIndex = 0;
            label1.Text = "Describa su problema";
            // 
            // textDescripcion
            // 
            textDescripcion.Location = new Point(46, 99);
            textDescripcion.Multiline = true;
            textDescripcion.Name = "textDescripcion";
            textDescripcion.Size = new Size(627, 193);
            textDescripcion.TabIndex = 1;
            // 
            // bEnviar
            // 
            bEnviar.Location = new Point(551, 323);
            bEnviar.Name = "bEnviar";
            bEnviar.Size = new Size(122, 33);
            bEnviar.TabIndex = 2;
            bEnviar.Text = "Enviar";
            bEnviar.UseVisualStyleBackColor = true;
            bEnviar.Click += bEnviar_Click;
            // 
            // labelPrincipal
            // 
            labelPrincipal.AutoSize = true;
            labelPrincipal.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelPrincipal.Location = new Point(131, 9);
            labelPrincipal.Name = "labelPrincipal";
            labelPrincipal.Size = new Size(446, 32);
            labelPrincipal.TabIndex = 4;
            labelPrincipal.Text = "Comuníquese con soporte de Eventos";
            // 
            // bCancelar
            // 
            bCancelar.Location = new Point(46, 323);
            bCancelar.Name = "bCancelar";
            bCancelar.Size = new Size(122, 33);
            bCancelar.TabIndex = 5;
            bCancelar.Text = "Cancelar";
            bCancelar.UseVisualStyleBackColor = true;
            bCancelar.Click += bCancelar_Click;
            // 
            // FormConsulta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(713, 381);
            Controls.Add(bCancelar);
            Controls.Add(labelPrincipal);
            Controls.Add(bEnviar);
            Controls.Add(textDescripcion);
            Controls.Add(label1);
            Name = "FormConsulta";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textDescripcion;
        private Button bEnviar;
        private Label labelPrincipal;
        private Button bCancelar;
    }
}