namespace LinkIT_
{
    partial class UserControl1
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            bGuardar = new Button();
            bMostrar = new Button();
            bEliminar = new Button();
            bModificar = new Button();
            bLimpiar = new Button();
            dataGridView1 = new DataGridView();
            textNombre = new TextBox();
            textApellido = new TextBox();
            textDNI = new TextBox();
            textTelefono = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // bGuardar
            // 
            bGuardar.Location = new Point(249, 94);
            bGuardar.Name = "bGuardar";
            bGuardar.Size = new Size(75, 23);
            bGuardar.TabIndex = 0;
            bGuardar.Text = "Guardar";
            bGuardar.UseVisualStyleBackColor = true;
            bGuardar.Click += bGuardar_Click;
            // 
            // bMostrar
            // 
            bMostrar.Location = new Point(251, 127);
            bMostrar.Name = "bMostrar";
            bMostrar.Size = new Size(75, 23);
            bMostrar.TabIndex = 1;
            bMostrar.Text = "Mostrar";
            bMostrar.UseVisualStyleBackColor = true;
            bMostrar.Click += bMostrar_Click;
            // 
            // bEliminar
            // 
            bEliminar.Location = new Point(252, 164);
            bEliminar.Name = "bEliminar";
            bEliminar.Size = new Size(75, 23);
            bEliminar.TabIndex = 2;
            bEliminar.Text = "Eliminar";
            bEliminar.UseVisualStyleBackColor = true;
            bEliminar.Click += bEliminar_Click;
            // 
            // bModificar
            // 
            bModificar.Location = new Point(345, 94);
            bModificar.Name = "bModificar";
            bModificar.Size = new Size(75, 23);
            bModificar.TabIndex = 3;
            bModificar.Text = "Modificar";
            bModificar.UseVisualStyleBackColor = true;
            bModificar.Click += bModificar_Click;
            // 
            // bLimpiar
            // 
            bLimpiar.Location = new Point(345, 127);
            bLimpiar.Name = "bLimpiar";
            bLimpiar.Size = new Size(75, 23);
            bLimpiar.TabIndex = 4;
            bLimpiar.Text = "Limpiar";
            bLimpiar.UseVisualStyleBackColor = false;
            bLimpiar.Click += this.bLimpiar_Click_1;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(65, 256);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(727, 150);
            dataGridView1.TabIndex = 5;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // textNombre
            // 
            textNombre.Location = new Point(97, 93);
            textNombre.Name = "textNombre";
            textNombre.Size = new Size(100, 23);
            textNombre.TabIndex = 6;
            // 
            // textApellido
            // 
            textApellido.Location = new Point(97, 127);
            textApellido.Name = "textApellido";
            textApellido.Size = new Size(100, 23);
            textApellido.TabIndex = 7;
            // 
            // textDNI
            // 
            textDNI.Location = new Point(97, 164);
            textDNI.Name = "textDNI";
            textDNI.Size = new Size(100, 23);
            textDNI.TabIndex = 8;
            // 
            // textTelefono
            // 
            textTelefono.Location = new Point(97, 193);
            textTelefono.Name = "textTelefono";
            textTelefono.Size = new Size(100, 23);
            textTelefono.TabIndex = 9;
            // 
            // UserControl1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(textTelefono);
            Controls.Add(textDNI);
            Controls.Add(textApellido);
            Controls.Add(textNombre);
            Controls.Add(dataGridView1);
            Controls.Add(bLimpiar);
            Controls.Add(bModificar);
            Controls.Add(bEliminar);
            Controls.Add(bMostrar);
            Controls.Add(bGuardar);
            Name = "UserControl1";
            Size = new Size(846, 447);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button bGuardar;
        private Button bMostrar;
        private Button bEliminar;
        private Button bModificar;
        private Button button5;
        private DataGridView dataGridView1;
        private TextBox textNombre;
        private TextBox textApellido;
        private TextBox textDNI;
        private TextBox textTelefono;
        private Button bLimpiar;
    }
}
