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
            labelTitulo = new Label();
            labelNombre = new Label();
            labelCorreo = new Label();
            labelDescripcion = new Label();
            SuspendLayout();
            // 
            // textDescripcion
            // 
            textDescripcion.BorderStyle = BorderStyle.FixedSingle;
            textDescripcion.Location = new Point(83, 149);
            textDescripcion.Multiline = true;
            textDescripcion.Name = "textDescripcion";
            textDescripcion.ReadOnly = true;
            textDescripcion.Size = new Size(627, 251);
            textDescripcion.TabIndex = 0;
            textDescripcion.TabStop = false;
            // 
            // bAtendida
            // 
            bAtendida.Location = new Point(571, 406);
            bAtendida.Name = "bAtendida";
            bAtendida.Size = new Size(184, 48);
            bAtendida.TabIndex = 1;
            bAtendida.Text = "Atendido";
            bAtendida.UseVisualStyleBackColor = true;
            bAtendida.Click += bAtendida_Click;
            // 
            // labelTitulo
            // 
            labelTitulo.AutoSize = true;
            labelTitulo.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTitulo.Location = new Point(331, 20);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new Size(143, 30);
            labelTitulo.TabIndex = 2;
            labelTitulo.Text = "Consulta Nro";
            // 
            // labelNombre
            // 
            labelNombre.AutoSize = true;
            labelNombre.Location = new Point(83, 68);
            labelNombre.Name = "labelNombre";
            labelNombre.Size = new Size(38, 15);
            labelNombre.TabIndex = 3;
            labelNombre.Text = "label2";
            // 
            // labelCorreo
            // 
            labelCorreo.AutoSize = true;
            labelCorreo.Location = new Point(83, 99);
            labelCorreo.Name = "labelCorreo";
            labelCorreo.Size = new Size(38, 15);
            labelCorreo.TabIndex = 4;
            labelCorreo.Text = "label3";
            // 
            // labelDescripcion
            // 
            labelDescripcion.AutoSize = true;
            labelDescripcion.Location = new Point(83, 131);
            labelDescripcion.Name = "labelDescripcion";
            labelDescripcion.Size = new Size(54, 15);
            labelDescripcion.TabIndex = 5;
            labelDescripcion.Text = "Mensaje:";
            // 
            // FormVerConsulta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 480);
            Controls.Add(labelDescripcion);
            Controls.Add(labelCorreo);
            Controls.Add(labelNombre);
            Controls.Add(labelTitulo);
            Controls.Add(bAtendida);
            Controls.Add(textDescripcion);
            Name = "FormVerConsulta";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textDescripcion;
        private Button bAtendida;
        private Label labelTitulo;
        private Label labelNombre;
        private Label labelCorreo;
        private Label labelDescripcion;
    }
}