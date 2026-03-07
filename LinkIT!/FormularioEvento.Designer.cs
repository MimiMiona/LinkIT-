namespace LinkIT_
{
    partial class FormularioEvento
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            labeltxtTitulo = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            txtTitulo = new TextBox();
            txtDescripcion = new TextBox();
            txtCapacidad = new TextBox();
            labelTitulo = new Label();
            comboBoxEstado = new ComboBox();
            dateTimeFechaEvento = new DateTimePicker();
            BCancelar = new Button();
            bAceptar = new Button();
            txtHorarioFin = new TextBox();
            txtHorarioInicio = new TextBox();
            SuspendLayout();
            // 
            // labeltxtTitulo
            // 
            labeltxtTitulo.AutoSize = true;
            labeltxtTitulo.Location = new Point(34, 75);
            labeltxtTitulo.Name = "labeltxtTitulo";
            labeltxtTitulo.Size = new Size(38, 15);
            labeltxtTitulo.TabIndex = 0;
            labeltxtTitulo.Text = "Titulo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(34, 133);
            label2.Name = "label2";
            label2.Size = new Size(69, 15);
            label2.TabIndex = 1;
            label2.Text = "Descripcion";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(34, 190);
            label3.Name = "label3";
            label3.Size = new Size(139, 15);
            label3.TabIndex = 2;
            label3.Text = "Horario Inicial del Evento";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(34, 252);
            label4.Name = "label4";
            label4.Size = new Size(170, 15);
            label4.TabIndex = 3;
            label4.Text = "Horario Finalizacion del Evento";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(34, 314);
            label5.Name = "label5";
            label5.Size = new Size(108, 15);
            label5.TabIndex = 4;
            label5.Text = "Capacidad Maxima";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(34, 373);
            label6.Name = "label6";
            label6.Size = new Size(96, 15);
            label6.TabIndex = 5;
            label6.Text = "Fecha del Evento";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(34, 430);
            label7.Name = "label7";
            label7.Size = new Size(42, 15);
            label7.TabIndex = 6;
            label7.Text = "Estado";
            // 
            // txtTitulo
            // 
            txtTitulo.Location = new Point(34, 93);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(390, 23);
            txtTitulo.TabIndex = 7;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(34, 151);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(390, 23);
            txtDescripcion.TabIndex = 8;
            // 
            // txtCapacidad
            // 
            txtCapacidad.Location = new Point(34, 332);
            txtCapacidad.Name = "txtCapacidad";
            txtCapacidad.Size = new Size(390, 23);
            txtCapacidad.TabIndex = 11;
            // 
            // labelTitulo
            // 
            labelTitulo.AutoSize = true;
            labelTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTitulo.Location = new Point(141, 13);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new Size(262, 32);
            labelTitulo.TabIndex = 17;
            labelTitulo.Text = "Crea/Modifica Evento";
            // 
            // comboBoxEstado
            // 
            comboBoxEstado.FormattingEnabled = true;
            comboBoxEstado.Location = new Point(34, 448);
            comboBoxEstado.Name = "comboBoxEstado";
            comboBoxEstado.Size = new Size(390, 23);
            comboBoxEstado.TabIndex = 18;
            // 
            // dateTimeFechaEvento
            // 
            dateTimeFechaEvento.Location = new Point(34, 391);
            dateTimeFechaEvento.Name = "dateTimeFechaEvento";
            dateTimeFechaEvento.Size = new Size(390, 23);
            dateTimeFechaEvento.TabIndex = 19;
            // 
            // BCancelar
            // 
            BCancelar.BackColor = Color.MediumSeaGreen;
            BCancelar.FlatAppearance.BorderSize = 0;
            BCancelar.FlatStyle = FlatStyle.Flat;
            BCancelar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BCancelar.ForeColor = Color.White;
            BCancelar.Location = new Point(34, 495);
            BCancelar.Name = "BCancelar";
            BCancelar.Size = new Size(96, 33);
            BCancelar.TabIndex = 20;
            BCancelar.Text = "Cancelar";
            BCancelar.UseVisualStyleBackColor = true;
            BCancelar.Click += BCancelar_Click;
            // 
            // bAceptar
            // 
            bAceptar.BackColor = Color.MediumSeaGreen;
            bAceptar.FlatAppearance.BorderSize = 0;
            bAceptar.FlatStyle = FlatStyle.Flat;
            bAceptar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bAceptar.ForeColor = Color.White;
            bAceptar.Location = new Point(328, 495);
            bAceptar.Name = "bAceptar";
            bAceptar.Size = new Size(96, 33);
            bAceptar.TabIndex = 21;
            bAceptar.Text = "Aceptar";
            bAceptar.UseVisualStyleBackColor = true;
            bAceptar.Click += bAceptar_Click;
            // 
            // txtHorarioFin
            // 
            txtHorarioFin.Location = new Point(34, 270);
            txtHorarioFin.Name = "txtHorarioFin";
            txtHorarioFin.Size = new Size(390, 23);
            txtHorarioFin.TabIndex = 22;
            // 
            // txtHorarioInicio
            // 
            txtHorarioInicio.Location = new Point(34, 208);
            txtHorarioInicio.Name = "txtHorarioInicio";
            txtHorarioInicio.Size = new Size(390, 23);
            txtHorarioInicio.TabIndex = 23;
            // 
            // FormularioEvento
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(502, 554);
            Controls.Add(txtHorarioInicio);
            Controls.Add(txtHorarioFin);
            Controls.Add(bAceptar);
            Controls.Add(BCancelar);
            Controls.Add(dateTimeFechaEvento);
            Controls.Add(comboBoxEstado);
            Controls.Add(labelTitulo);
            Controls.Add(txtCapacidad);
            Controls.Add(txtDescripcion);
            Controls.Add(txtTitulo);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(labeltxtTitulo);
            Name = "FormularioEvento";
            StartPosition = FormStartPosition.CenterScreen;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labeltxtTitulo;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox txtTitulo;
        private TextBox txtDescripcion;
        private TextBox txtCapacidad;
        private Label labelTitulo;
        private ComboBox comboBoxEstado;
        private DateTimePicker dateTimeFechaEvento;
        private Button BCancelar;
        private Button bAceptar;
        private TextBox txtHorarioFin;
        private TextBox txtHorarioInicio;
    }
}
