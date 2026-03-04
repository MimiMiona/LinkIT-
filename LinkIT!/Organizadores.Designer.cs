namespace LinkIT_
{
    partial class Organizadores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Organizadores));
            textTelefono = new TextBox();
            textDNI = new TextBox();
            textNombre = new TextBox();
            textApellido = new TextBox();
            bGuardar = new Button();
            dataGridView1 = new DataGridView();
            bMostrar = new Button();
            bEliminar = new Button();
            bModificar = new Button();
            bLimpiar = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // textTelefono
            // 
            textTelefono.Location = new Point(146, 165);
            textTelefono.Name = "textTelefono";
            textTelefono.Size = new Size(100, 23);
            textTelefono.TabIndex = 0;
            // 
            // textDNI
            // 
            textDNI.Location = new Point(146, 121);
            textDNI.Name = "textDNI";
            textDNI.Size = new Size(100, 23);
            textDNI.TabIndex = 1;
            // 
            // textNombre
            // 
            textNombre.Location = new Point(146, 34);
            textNombre.Name = "textNombre";
            textNombre.Size = new Size(100, 23);
            textNombre.TabIndex = 2;
            // 
            // textApellido
            // 
            textApellido.Location = new Point(146, 78);
            textApellido.Name = "textApellido";
            textApellido.Size = new Size(100, 23);
            textApellido.TabIndex = 3;
            // 
            // bGuardar
            // 
            bGuardar.BackColor = Color.PaleGoldenrod;
            bGuardar.FlatStyle = FlatStyle.Popup;
            bGuardar.Location = new Point(443, 34);
            bGuardar.Name = "bGuardar";
            bGuardar.Size = new Size(104, 50);
            bGuardar.TabIndex = 4;
            bGuardar.Text = "Guardar";
            bGuardar.UseVisualStyleBackColor = false;
            bGuardar.Click += bGuardar_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.Khaki;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 234);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(776, 150);
            dataGridView1.TabIndex = 5;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // bMostrar
            // 
            bMostrar.BackColor = Color.PaleGoldenrod;
            bMostrar.FlatStyle = FlatStyle.Popup;
            bMostrar.Location = new Point(570, 98);
            bMostrar.Name = "bMostrar";
            bMostrar.Size = new Size(104, 50);
            bMostrar.TabIndex = 6;
            bMostrar.Text = "Mostrar";
            bMostrar.UseVisualStyleBackColor = false;
            bMostrar.Click += bMostrar_Click;
            // 
            // bEliminar
            // 
            bEliminar.BackColor = Color.PaleGoldenrod;
            bEliminar.FlatStyle = FlatStyle.Popup;
            bEliminar.Location = new Point(570, 34);
            bEliminar.Name = "bEliminar";
            bEliminar.Size = new Size(104, 50);
            bEliminar.TabIndex = 7;
            bEliminar.Text = "Eliminar";
            bEliminar.UseVisualStyleBackColor = false;
            bEliminar.Click += bEliminar_Click;
            // 
            // bModificar
            // 
            bModificar.BackColor = Color.PaleGoldenrod;
            bModificar.FlatStyle = FlatStyle.Popup;
            bModificar.Location = new Point(443, 98);
            bModificar.Name = "bModificar";
            bModificar.Size = new Size(104, 50);
            bModificar.TabIndex = 8;
            bModificar.Text = "Modificar";
            bModificar.UseVisualStyleBackColor = false;
            bModificar.Click += bModificar_Click;
            // 
            // bLimpiar
            // 
            bLimpiar.BackColor = Color.PaleGoldenrod;
            bLimpiar.FlatStyle = FlatStyle.Popup;
            bLimpiar.Location = new Point(510, 157);
            bLimpiar.Name = "bLimpiar";
            bLimpiar.Size = new Size(104, 50);
            bLimpiar.TabIndex = 9;
            bLimpiar.Text = "Limpiar";
            bLimpiar.UseVisualStyleBackColor = false;
            bLimpiar.Click += bLimpiar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(49, 29);
            label1.Name = "label1";
            label1.Size = new Size(85, 28);
            label1.TabIndex = 10;
            label1.Text = "Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F);
            label2.Location = new Point(49, 73);
            label2.Name = "label2";
            label2.Size = new Size(86, 28);
            label2.TabIndex = 11;
            label2.Text = "Apellido";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F);
            label3.Location = new Point(49, 116);
            label3.Name = "label3";
            label3.Size = new Size(46, 28);
            label3.TabIndex = 12;
            label3.Text = "DNI";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15F);
            label4.Location = new Point(49, 160);
            label4.Name = "label4";
            label4.Size = new Size(86, 28);
            label4.TabIndex = 13;
            label4.Text = "Telefono";
            // 
            // Organizadores
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Ivory;
            ClientSize = new Size(800, 396);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(bLimpiar);
            Controls.Add(bModificar);
            Controls.Add(bEliminar);
            Controls.Add(bMostrar);
            Controls.Add(dataGridView1);
            Controls.Add(bGuardar);
            Controls.Add(textApellido);
            Controls.Add(textNombre);
            Controls.Add(textDNI);
            Controls.Add(textTelefono);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Organizadores";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textTelefono;
        private TextBox textDNI;
        private TextBox textNombre;
        private TextBox textApellido;
        private Button bGuardar;
        private DataGridView dataGridView1;
        private Button bMostrar;
        private Button bEliminar;
        private Button bModificar;
        private Button bLimpiar;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}