namespace LinkIT_
{
    partial class UCUsuarios
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
            textCorreo = new TextBox();
            textDNI = new TextBox();
            textNombre = new TextBox();
            textClave = new TextBox();
            bGuardar = new Button();
            dataGridView1 = new DataGridView();
            bMostrar = new Button();
            bEliminar = new Button();
            bModificar = new Button();
            bLimpiar = new Button();
            label1 = new Label();
            labelClave = new Label();
            label3 = new Label();
            label4 = new Label();
            button1 = new Button();
            textBoxBuscar = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // textCorreo
            // 
            textCorreo.Location = new Point(146, 120);
            textCorreo.Name = "textCorreo";
            textCorreo.Size = new Size(324, 23);
            textCorreo.TabIndex = 0;
            // 
            // textDNI
            // 
            textDNI.Location = new Point(146, 77);
            textDNI.Name = "textDNI";
            textDNI.Size = new Size(324, 23);
            textDNI.TabIndex = 1;
            // 
            // textNombre
            // 
            textNombre.Location = new Point(146, 34);
            textNombre.Name = "textNombre";
            textNombre.Size = new Size(324, 23);
            textNombre.TabIndex = 2;
            // 
            // textClave
            // 
            textClave.Location = new Point(146, 164);
            textClave.Name = "textClave";
            textClave.Size = new Size(324, 23);
            textClave.TabIndex = 3;
            textClave.UseSystemPasswordChar = true;
            // 
            // bGuardar
            // 
            bGuardar.BackColor = Color.PaleGoldenrod;
            bGuardar.FlatStyle = FlatStyle.Popup;
            bGuardar.Location = new Point(956, 22);
            bGuardar.Name = "bGuardar";
            bGuardar.Size = new Size(104, 50);
            bGuardar.TabIndex = 4;
            bGuardar.Text = "Guardar";
            bGuardar.UseVisualStyleBackColor = false;
            bGuardar.Click += bGuardar_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.Khaki;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 290);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1138, 388);
            dataGridView1.TabIndex = 5;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // bMostrar
            // 
            bMostrar.BackColor = Color.PaleGoldenrod;
            bMostrar.FlatStyle = FlatStyle.Popup;
            bMostrar.Location = new Point(892, 159);
            bMostrar.Name = "bMostrar";
            bMostrar.Size = new Size(104, 50);
            bMostrar.TabIndex = 6;
            bMostrar.Text = "Mostrar Eliminados";
            bMostrar.UseVisualStyleBackColor = false;
            bMostrar.Click += bMostrar_Click;
            // 
            // bEliminar
            // 
            bEliminar.BackColor = Color.PaleGoldenrod;
            bEliminar.FlatStyle = FlatStyle.Popup;
            bEliminar.Location = new Point(1022, 93);
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
            bModificar.Location = new Point(892, 93);
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
            bLimpiar.Location = new Point(1022, 159);
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
            // labelClave
            // 
            labelClave.AutoSize = true;
            labelClave.Font = new Font("Segoe UI", 15F);
            labelClave.Location = new Point(49, 159);
            labelClave.Name = "labelClave";
            labelClave.Size = new Size(59, 28);
            labelClave.TabIndex = 11;
            labelClave.Text = "Clave";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F);
            label3.Location = new Point(49, 72);
            label3.Name = "label3";
            label3.Size = new Size(46, 28);
            label3.TabIndex = 12;
            label3.Text = "DNI";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15F);
            label4.Location = new Point(49, 115);
            label4.Name = "label4";
            label4.Size = new Size(72, 28);
            label4.TabIndex = 13;
            label4.Text = "Correo";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.Window;
            button1.Enabled = false;
            button1.FlatStyle = FlatStyle.Popup;
            button1.ForeColor = SystemColors.ControlText;
            button1.Location = new Point(1104, 259);
            button1.Margin = new Padding(0);
            button1.Name = "button1";
            button1.Size = new Size(46, 25);
            button1.TabIndex = 15;
            button1.TabStop = false;
            button1.Text = "🔍";
            button1.UseVisualStyleBackColor = false;
            // 
            // textBoxBuscar
            // 
            textBoxBuscar.Font = new Font("Segoe UI", 10F);
            textBoxBuscar.ForeColor = SystemColors.ActiveCaptionText;
            textBoxBuscar.Location = new Point(12, 259);
            textBoxBuscar.Name = "textBoxBuscar";
            textBoxBuscar.Size = new Size(1067, 25);
            textBoxBuscar.TabIndex = 14;
            textBoxBuscar.TextChanged += textBoxBuscar_TextChanged;
            // 
            // UCUsuarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Ivory;
            Controls.Add(button1);
            Controls.Add(textBoxBuscar);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(labelClave);
            Controls.Add(label1);
            Controls.Add(bLimpiar);
            Controls.Add(bModificar);
            Controls.Add(bEliminar);
            Controls.Add(bMostrar);
            Controls.Add(dataGridView1);
            Controls.Add(bGuardar);
            Controls.Add(textClave);
            Controls.Add(textNombre);
            Controls.Add(textDNI);
            Controls.Add(textCorreo);
            Name = "UCUsuarios";
            Size = new Size(1173, 697);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textCorreo;
        private TextBox textDNI;
        private TextBox textNombre;
        private TextBox textClave;
        private Button bGuardar;
        private DataGridView dataGridView1;
        private Button bMostrar;
        private Button bEliminar;
        private Button bModificar;
        private Button bLimpiar;
        private Label label1;
        private Label labelClave;
        private Label label3;
        private Label label4;
        private Button button1;
        private TextBox textBoxBuscar;
    }
}