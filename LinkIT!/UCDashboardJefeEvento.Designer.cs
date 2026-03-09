namespace LinkIT_
{
    partial class UCDashboardJefeEvento
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            labelSubtitulo = new Label();
            label1 = new Label();
            panel2 = new Panel();
            label11 = new Label();
            chartAsistenciaMensual = new System.Windows.Forms.DataVisualization.Charting.Chart();
            label15 = new Label();
            panel1 = new Panel();
            label2 = new Label();
            chartEventosMes = new System.Windows.Forms.DataVisualization.Charting.Chart();
            label10 = new Label();
            panel3 = new Panel();
            labelSubtituloTotalEventos = new Label();
            pictureBox1 = new PictureBox();
            labelTotalEventos = new Label();
            panel7 = new Panel();
            labelSubtituloEventoMayorAsistencia = new Label();
            label9 = new Label();
            pictureBox8 = new PictureBox();
            panel9 = new Panel();
            labelSubtituloSolicitudesPendientes = new Label();
            label7 = new Label();
            pictureBox6 = new PictureBox();
            panel4 = new Panel();
            labelSubtituloEventoActivo = new Label();
            label3 = new Label();
            pictureBox2 = new PictureBox();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartAsistenciaMensual).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartEventosMes).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // labelSubtitulo
            // 
            labelSubtitulo.AutoSize = true;
            labelSubtitulo.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelSubtitulo.ForeColor = SystemColors.ActiveCaptionText;
            labelSubtitulo.Location = new Point(23, 55);
            labelSubtitulo.Name = "labelSubtitulo";
            labelSubtitulo.Size = new Size(247, 17);
            labelSubtitulo.TabIndex = 10;
            labelSubtitulo.Text = "Resumen general del sistema de eventos";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(20, 20);
            label1.Name = "label1";
            label1.Size = new Size(138, 32);
            label1.TabIndex = 9;
            label1.Text = "Dashboard";
            // 
            // panel2
            // 
            panel2.BackColor = Color.PaleGreen;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(label11);
            panel2.Controls.Add(chartAsistenciaMensual);
            panel2.Controls.Add(label15);
            panel2.Location = new Point(586, 267);
            panel2.Name = "panel2";
            panel2.Size = new Size(528, 334);
            panel2.TabIndex = 25;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.ForeColor = SystemColors.ActiveCaptionText;
            label11.Location = new Point(3, 35);
            label11.Name = "label11";
            label11.Size = new Size(185, 17);
            label11.TabIndex = 18;
            label11.Text = "Distribucion por estado Actual";
            // 
            // chartAsistenciaMensual
            // 
            chartArea3.Name = "ChartArea1";
            chartAsistenciaMensual.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            chartAsistenciaMensual.Legends.Add(legend3);
            chartAsistenciaMensual.Location = new Point(-1, 89);
            chartAsistenciaMensual.Name = "chartAsistenciaMensual";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            chartAsistenciaMensual.Series.Add(series3);
            chartAsistenciaMensual.Size = new Size(528, 227);
            chartAsistenciaMensual.TabIndex = 10;
            chartAsistenciaMensual.Text = "chart2";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label15.Location = new Point(3, 10);
            label15.Name = "label15";
            label15.Size = new Size(172, 25);
            label15.TabIndex = 17;
            label15.Text = "Estados de Evento";
            // 
            // panel1
            // 
            panel1.BackColor = Color.PaleGreen;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(chartEventosMes);
            panel1.Controls.Add(label10);
            panel1.Location = new Point(24, 267);
            panel1.Name = "panel1";
            panel1.Size = new Size(528, 334);
            panel1.TabIndex = 24;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label2.Location = new Point(2, 35);
            label2.Name = "label2";
            label2.Size = new Size(272, 17);
            label2.TabIndex = 16;
            label2.Text = "Total de Eventos registrado por mes en 2026";
            // 
            // chartEventosMes
            // 
            chartArea4.Name = "ChartArea1";
            chartEventosMes.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            chartEventosMes.Legends.Add(legend4);
            chartEventosMes.Location = new Point(-1, 89);
            chartEventosMes.Name = "chartEventosMes";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            chartEventosMes.Series.Add(series4);
            chartEventosMes.Size = new Size(528, 227);
            chartEventosMes.TabIndex = 9;
            chartEventosMes.Text = "chart1";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(2, 10);
            label10.Name = "label10";
            label10.Size = new Size(159, 25);
            label10.TabIndex = 15;
            label10.Text = "Eventos por Mes";
            // 
            // panel3
            // 
            panel3.BackColor = Color.PaleGreen;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(labelSubtituloTotalEventos);
            panel3.Controls.Add(pictureBox1);
            panel3.Controls.Add(labelTotalEventos);
            panel3.Location = new Point(20, 116);
            panel3.Name = "panel3";
            panel3.Size = new Size(247, 79);
            panel3.TabIndex = 26;
            // 
            // labelSubtituloTotalEventos
            // 
            labelSubtituloTotalEventos.AutoSize = true;
            labelSubtituloTotalEventos.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelSubtituloTotalEventos.Location = new Point(72, 40);
            labelSubtituloTotalEventos.Name = "labelSubtituloTotalEventos";
            labelSubtituloTotalEventos.Size = new Size(57, 21);
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
            labelTotalEventos.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTotalEventos.ForeColor = SystemColors.WindowFrame;
            labelTotalEventos.Location = new Point(71, 15);
            labelTotalEventos.Name = "labelTotalEventos";
            labelTotalEventos.Size = new Size(98, 15);
            labelTotalEventos.TabIndex = 15;
            labelTotalEventos.Text = "Total de Eventos";
            // 
            // panel7
            // 
            panel7.BackColor = Color.PaleGreen;
            panel7.BorderStyle = BorderStyle.FixedSingle;
            panel7.Controls.Add(labelSubtituloEventoMayorAsistencia);
            panel7.Controls.Add(label9);
            panel7.Controls.Add(pictureBox8);
            panel7.Location = new Point(301, 116);
            panel7.Name = "panel7";
            panel7.Size = new Size(247, 79);
            panel7.TabIndex = 16;
            // 
            // labelSubtituloEventoMayorAsistencia
            // 
            labelSubtituloEventoMayorAsistencia.AutoEllipsis = true;
            labelSubtituloEventoMayorAsistencia.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelSubtituloEventoMayorAsistencia.Location = new Point(71, 38);
            labelSubtituloEventoMayorAsistencia.MaximumSize = new Size(166, 40);
            labelSubtituloEventoMayorAsistencia.Name = "labelSubtituloEventoMayorAsistencia";
            labelSubtituloEventoMayorAsistencia.Size = new Size(166, 40);
            labelSubtituloEventoMayorAsistencia.TabIndex = 18;
            labelSubtituloEventoMayorAsistencia.Text = "label12";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label9.ForeColor = SystemColors.WindowFrame;
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
            // panel9
            // 
            panel9.BackColor = Color.PaleGreen;
            panel9.BorderStyle = BorderStyle.FixedSingle;
            panel9.Controls.Add(labelSubtituloSolicitudesPendientes);
            panel9.Controls.Add(label7);
            panel9.Controls.Add(pictureBox6);
            panel9.Location = new Point(582, 116);
            panel9.Name = "panel9";
            panel9.Size = new Size(247, 79);
            panel9.TabIndex = 23;
            // 
            // labelSubtituloSolicitudesPendientes
            // 
            labelSubtituloSolicitudesPendientes.AutoSize = true;
            labelSubtituloSolicitudesPendientes.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelSubtituloSolicitudesPendientes.Location = new Point(72, 43);
            labelSubtituloSolicitudesPendientes.Name = "labelSubtituloSolicitudesPendientes";
            labelSubtituloSolicitudesPendientes.Size = new Size(66, 21);
            labelSubtituloSolicitudesPendientes.TabIndex = 24;
            labelSubtituloSolicitudesPendientes.Text = "label14";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label7.ForeColor = SystemColors.WindowFrame;
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
            // panel4
            // 
            panel4.BackColor = Color.PaleGreen;
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(labelSubtituloEventoActivo);
            panel4.Controls.Add(label3);
            panel4.Controls.Add(pictureBox2);
            panel4.Location = new Point(863, 116);
            panel4.Name = "panel4";
            panel4.Size = new Size(247, 79);
            panel4.TabIndex = 27;
            // 
            // labelSubtituloEventoActivo
            // 
            labelSubtituloEventoActivo.AutoSize = true;
            labelSubtituloEventoActivo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelSubtituloEventoActivo.Location = new Point(72, 40);
            labelSubtituloEventoActivo.Name = "labelSubtituloEventoActivo";
            labelSubtituloEventoActivo.Size = new Size(66, 21);
            labelSubtituloEventoActivo.TabIndex = 16;
            labelSubtituloEventoActivo.Text = "label10";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.WindowFrame;
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
            // UCDashboardJefeEvento
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Ivory;
            Controls.Add(panel4);
            Controls.Add(panel9);
            Controls.Add(panel7);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(labelSubtitulo);
            Controls.Add(label1);
            Name = "UCDashboardJefeEvento";
            Size = new Size(1173, 697);
            Load += UCDashboardJefeEvento_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)chartAsistenciaMensual).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)chartEventosMes).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelSubtitulo;
        private Label label1;
        private Panel panel2;
        private Label label11;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartAsistenciaMensual;
        private Label label15;
        private Panel panel1;
        private Label label2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartEventosMes;
        private Label label10;
        private Panel panel3;
        private Label labelSubtituloTotalEventos;
        private PictureBox pictureBox1;
        private Label labelTotalEventos;
        private Panel panel7;
        private Label labelSubtituloEventoMayorAsistencia;
        private Label label9;
        private PictureBox pictureBox8;
        private Panel panel9;
        private Label labelSubtituloSolicitudesPendientes;
        private Label label7;
        private PictureBox pictureBox6;
        private Panel panel4;
        private Label labelSubtituloEventoActivo;
        private Label label3;
        private PictureBox pictureBox2;
    }
}
