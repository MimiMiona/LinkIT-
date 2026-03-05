namespace LinkIT_
{
    partial class UCDashboard
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            label1 = new Label();
            labelSubtitulo = new Label();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            labelSubtituloTotalEventos = new Label();
            pictureBox1 = new PictureBox();
            labelTotalEventos = new Label();
            panel4 = new Panel();
            labelSubtituloEventoActivo = new Label();
            label3 = new Label();
            pictureBox2 = new PictureBox();
            panel5 = new Panel();
            labelSubtituloEventoFinalizado = new Label();
            label4 = new Label();
            pictureBox3 = new PictureBox();
            panel6 = new Panel();
            labelSubtituloTasaOcupacion = new Label();
            label5 = new Label();
            pictureBox4 = new PictureBox();
            panel7 = new Panel();
            labelSubtituloEventoMayorAsistencia = new Label();
            label9 = new Label();
            pictureBox8 = new PictureBox();
            panel8 = new Panel();
            labelSubtituloTotalUsuarios = new Label();
            label8 = new Label();
            pictureBox7 = new PictureBox();
            panel9 = new Panel();
            labelSubtituloSolicitudesPendientes = new Label();
            label7 = new Label();
            pictureBox6 = new PictureBox();
            panel10 = new Panel();
            labelSubtituloJefesEventos = new Label();
            label6 = new Label();
            pictureBox5 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart2).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(20, 20);
            label1.Name = "label1";
            label1.Size = new Size(138, 32);
            label1.TabIndex = 7;
            label1.Text = "Dashboard";
            // 
            // labelSubtitulo
            // 
            labelSubtitulo.AutoSize = true;
            labelSubtitulo.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelSubtitulo.ForeColor = SystemColors.ActiveCaptionText;
            labelSubtitulo.Location = new Point(23, 55);
            labelSubtitulo.Name = "labelSubtitulo";
            labelSubtitulo.Size = new Size(247, 17);
            labelSubtitulo.TabIndex = 8;
            labelSubtitulo.Text = "Resumen general del sistema de eventos";
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chart1.Legends.Add(legend1);
            chart1.Location = new Point(3, 73);
            chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chart1.Series.Add(series1);
            chart1.Size = new Size(584, 216);
            chart1.TabIndex = 9;
            chart1.Text = "chart1";
            // 
            // chart2
            // 
            chartArea2.Name = "ChartArea1";
            chart2.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            chart2.Legends.Add(legend2);
            chart2.Location = new Point(3, 59);
            chart2.Name = "chart2";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            chart2.Series.Add(series2);
            chart2.Size = new Size(414, 227);
            chart2.TabIndex = 10;
            chart2.Text = "chart2";
            // 
            // panel1
            // 
            panel1.BackColor = Color.WhiteSmoke;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(chart1);
            panel1.Location = new Point(38, 381);
            panel1.Name = "panel1";
            panel1.Size = new Size(590, 289);
            panel1.TabIndex = 11;
            // 
            // panel2
            // 
            panel2.BackColor = Color.WhiteSmoke;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(chart2);
            panel2.Location = new Point(699, 381);
            panel2.Name = "panel2";
            panel2.Size = new Size(411, 286);
            panel2.TabIndex = 12;
            // 
            // panel3
            // 
            panel3.BackColor = Color.SeaGreen;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(labelSubtituloTotalEventos);
            panel3.Controls.Add(pictureBox1);
            panel3.Controls.Add(labelTotalEventos);
            panel3.Location = new Point(20, 116);
            panel3.Name = "panel3";
            panel3.Size = new Size(247, 79);
            panel3.TabIndex = 13;
            // 
            // labelSubtituloTotalEventos
            // 
            labelSubtituloTotalEventos.AutoSize = true;
            labelSubtituloTotalEventos.Location = new Point(83, 50);
            labelSubtituloTotalEventos.Name = "labelSubtituloTotalEventos";
            labelSubtituloTotalEventos.Size = new Size(38, 15);
            labelSubtituloTotalEventos.TabIndex = 15;
            labelSubtituloTotalEventos.Text = "label2";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.calendario;
            pictureBox1.Location = new Point(3, 15);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(63, 50);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 15;
            pictureBox1.TabStop = false;
            // 
            // labelTotalEventos
            // 
            labelTotalEventos.AutoSize = true;
            labelTotalEventos.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelTotalEventos.Location = new Point(72, 15);
            labelTotalEventos.Name = "labelTotalEventos";
            labelTotalEventos.Size = new Size(98, 15);
            labelTotalEventos.TabIndex = 15;
            labelTotalEventos.Text = "Total de Eventos";
            // 
            // panel4
            // 
            panel4.BackColor = Color.PaleGreen;
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(labelSubtituloEventoActivo);
            panel4.Controls.Add(label3);
            panel4.Controls.Add(pictureBox2);
            panel4.Location = new Point(301, 116);
            panel4.Name = "panel4";
            panel4.Size = new Size(247, 79);
            panel4.TabIndex = 14;
            // 
            // labelSubtituloEventoActivo
            // 
            labelSubtituloEventoActivo.AutoSize = true;
            labelSubtituloEventoActivo.Location = new Point(72, 50);
            labelSubtituloEventoActivo.Name = "labelSubtituloEventoActivo";
            labelSubtituloEventoActivo.Size = new Size(44, 15);
            labelSubtituloEventoActivo.TabIndex = 16;
            labelSubtituloEventoActivo.Text = "label10";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(72, 15);
            label3.Name = "label3";
            label3.Size = new Size(95, 15);
            label3.TabIndex = 16;
            label3.Text = "Eventos Activos";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.calendario__2_1;
            pictureBox2.Location = new Point(3, 15);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(63, 50);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 16;
            pictureBox2.TabStop = false;
            // 
            // panel5
            // 
            panel5.BackColor = Color.PaleGoldenrod;
            panel5.BorderStyle = BorderStyle.FixedSingle;
            panel5.Controls.Add(labelSubtituloEventoFinalizado);
            panel5.Controls.Add(label4);
            panel5.Controls.Add(pictureBox3);
            panel5.Location = new Point(582, 116);
            panel5.Name = "panel5";
            panel5.Size = new Size(247, 79);
            panel5.TabIndex = 14;
            // 
            // labelSubtituloEventoFinalizado
            // 
            labelSubtituloEventoFinalizado.AutoSize = true;
            labelSubtituloEventoFinalizado.Location = new Point(72, 50);
            labelSubtituloEventoFinalizado.Name = "labelSubtituloEventoFinalizado";
            labelSubtituloEventoFinalizado.Size = new Size(44, 15);
            labelSubtituloEventoFinalizado.TabIndex = 17;
            labelSubtituloEventoFinalizado.Text = "label11";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(72, 15);
            label4.Name = "label4";
            label4.Size = new Size(108, 15);
            label4.TabIndex = 17;
            label4.Text = "Eventos Finalizado";
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.calendario__4_;
            pictureBox3.Location = new Point(3, 15);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(63, 50);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 17;
            pictureBox3.TabStop = false;
            // 
            // panel6
            // 
            panel6.BorderStyle = BorderStyle.FixedSingle;
            panel6.Controls.Add(labelSubtituloTasaOcupacion);
            panel6.Controls.Add(label5);
            panel6.Controls.Add(pictureBox4);
            panel6.Location = new Point(863, 116);
            panel6.Name = "panel6";
            panel6.Size = new Size(247, 79);
            panel6.TabIndex = 14;
            // 
            // labelSubtituloTasaOcupacion
            // 
            labelSubtituloTasaOcupacion.AutoSize = true;
            labelSubtituloTasaOcupacion.Location = new Point(72, 50);
            labelSubtituloTasaOcupacion.Name = "labelSubtituloTasaOcupacion";
            labelSubtituloTasaOcupacion.Size = new Size(44, 15);
            labelSubtituloTasaOcupacion.TabIndex = 26;
            labelSubtituloTasaOcupacion.Text = "label16";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.Location = new Point(72, 15);
            label5.Name = "label5";
            label5.Size = new Size(108, 15);
            label5.TabIndex = 18;
            label5.Text = "Tasa de Ocupación";
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.tendencia;
            pictureBox4.Location = new Point(3, 15);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(63, 50);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 18;
            pictureBox4.TabStop = false;
            // 
            // panel7
            // 
            panel7.BorderStyle = BorderStyle.FixedSingle;
            panel7.Controls.Add(labelSubtituloEventoMayorAsistencia);
            panel7.Controls.Add(label9);
            panel7.Controls.Add(pictureBox8);
            panel7.Location = new Point(20, 240);
            panel7.Name = "panel7";
            panel7.Size = new Size(247, 79);
            panel7.TabIndex = 14;
            // 
            // labelSubtituloEventoMayorAsistencia
            // 
            labelSubtituloEventoMayorAsistencia.AutoSize = true;
            labelSubtituloEventoMayorAsistencia.Location = new Point(77, 49);
            labelSubtituloEventoMayorAsistencia.Name = "labelSubtituloEventoMayorAsistencia";
            labelSubtituloEventoMayorAsistencia.Size = new Size(44, 15);
            labelSubtituloEventoMayorAsistencia.TabIndex = 18;
            labelSubtituloEventoMayorAsistencia.Text = "label12";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label9.Location = new Point(72, 14);
            label9.Name = "label9";
            label9.Size = new Size(165, 15);
            label9.TabIndex = 22;
            label9.Text = "Evento con Mayor Asistencia";
            // 
            // pictureBox8
            // 
            pictureBox8.Image = Properties.Resources.insignia;
            pictureBox8.Location = new Point(3, 14);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(63, 50);
            pictureBox8.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox8.TabIndex = 22;
            pictureBox8.TabStop = false;
            // 
            // panel8
            // 
            panel8.BackColor = Color.PaleGoldenrod;
            panel8.BorderStyle = BorderStyle.FixedSingle;
            panel8.Controls.Add(labelSubtituloTotalUsuarios);
            panel8.Controls.Add(label8);
            panel8.Controls.Add(pictureBox7);
            panel8.Location = new Point(301, 240);
            panel8.Name = "panel8";
            panel8.Size = new Size(247, 79);
            panel8.TabIndex = 14;
            // 
            // labelSubtituloTotalUsuarios
            // 
            labelSubtituloTotalUsuarios.AutoSize = true;
            labelSubtituloTotalUsuarios.Location = new Point(72, 49);
            labelSubtituloTotalUsuarios.Name = "labelSubtituloTotalUsuarios";
            labelSubtituloTotalUsuarios.Size = new Size(44, 15);
            labelSubtituloTotalUsuarios.TabIndex = 23;
            labelSubtituloTotalUsuarios.Text = "label13";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label8.Location = new Point(72, 14);
            label8.Name = "label8";
            label8.Size = new Size(101, 15);
            label8.TabIndex = 21;
            label8.Text = "Total de Usuarios";
            // 
            // pictureBox7
            // 
            pictureBox7.Image = Properties.Resources.grupo;
            pictureBox7.Location = new Point(3, 14);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(63, 50);
            pictureBox7.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox7.TabIndex = 21;
            pictureBox7.TabStop = false;
            // 
            // panel9
            // 
            panel9.BackColor = Color.PaleGreen;
            panel9.BorderStyle = BorderStyle.FixedSingle;
            panel9.Controls.Add(labelSubtituloSolicitudesPendientes);
            panel9.Controls.Add(label7);
            panel9.Controls.Add(pictureBox6);
            panel9.Location = new Point(582, 240);
            panel9.Name = "panel9";
            panel9.Size = new Size(247, 79);
            panel9.TabIndex = 14;
            // 
            // labelSubtituloSolicitudesPendientes
            // 
            labelSubtituloSolicitudesPendientes.AutoSize = true;
            labelSubtituloSolicitudesPendientes.Location = new Point(72, 49);
            labelSubtituloSolicitudesPendientes.Name = "labelSubtituloSolicitudesPendientes";
            labelSubtituloSolicitudesPendientes.Size = new Size(44, 15);
            labelSubtituloSolicitudesPendientes.TabIndex = 24;
            labelSubtituloSolicitudesPendientes.Text = "label14";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label7.Location = new Point(72, 14);
            label7.Name = "label7";
            label7.Size = new Size(132, 15);
            label7.TabIndex = 20;
            label7.Text = "Solicitudes Pendientes";
            // 
            // pictureBox6
            // 
            pictureBox6.Image = Properties.Resources.anadir_amigo;
            pictureBox6.Location = new Point(3, 14);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(63, 50);
            pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox6.TabIndex = 20;
            pictureBox6.TabStop = false;
            // 
            // panel10
            // 
            panel10.BackColor = Color.SeaGreen;
            panel10.BorderStyle = BorderStyle.FixedSingle;
            panel10.Controls.Add(labelSubtituloJefesEventos);
            panel10.Controls.Add(label6);
            panel10.Controls.Add(pictureBox5);
            panel10.Location = new Point(863, 240);
            panel10.Name = "panel10";
            panel10.Size = new Size(247, 79);
            panel10.TabIndex = 14;
            // 
            // labelSubtituloJefesEventos
            // 
            labelSubtituloJefesEventos.AutoSize = true;
            labelSubtituloJefesEventos.Location = new Point(72, 49);
            labelSubtituloJefesEventos.Name = "labelSubtituloJefesEventos";
            labelSubtituloJefesEventos.Size = new Size(44, 15);
            labelSubtituloJefesEventos.TabIndex = 25;
            labelSubtituloJefesEventos.Text = "label15";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label6.Location = new Point(72, 14);
            label6.Name = "label6";
            label6.Size = new Size(100, 15);
            label6.TabIndex = 19;
            label6.Text = "Jefes de Eventos";
            // 
            // pictureBox5
            // 
            pictureBox5.Image = Properties.Resources.liderazgo;
            pictureBox5.Location = new Point(3, 14);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(63, 50);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 19;
            pictureBox5.TabStop = false;
            // 
            // UCDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(panel10);
            Controls.Add(panel9);
            Controls.Add(panel8);
            Controls.Add(panel7);
            Controls.Add(panel6);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(labelSubtitulo);
            Controls.Add(label1);
            Name = "UCDashboard";
            Size = new Size(1173, 697);
            Load += UCDashboard_Load;
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart2).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label labelSubtitulo;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Panel panel7;
        private Panel panel8;
        private Label labelSubtituloTotalEventos;
        private PictureBox pictureBox1;
        private Label labelTotalEventos;
        private Panel panel9;
        private Panel panel10;
        private Label labelSubtituloEventoActivo;
        private Label label3;
        private PictureBox pictureBox2;
        private Label labelSubtituloEventoFinalizado;
        private Label label4;
        private PictureBox pictureBox3;
        private Label labelSubtituloTasaOcupacion;
        private Label label5;
        private PictureBox pictureBox4;
        private Label label12;
        private Label label9;
        private PictureBox pictureBox8;
        private Label label13;
        private Label label8;
        private PictureBox pictureBox7;
        private Label label14;
        private Label label7;
        private PictureBox pictureBox6;
        private Label labelSubtituloJefesEventos;
        private Label label6;
        private PictureBox pictureBox5;
        private Label labelSubtituloEventoMayorAsistencia;
        private Label labelSubtituloTotalUsuarios;
        private Label labelSubtituloSolicitudesPendientes;
    }
}
