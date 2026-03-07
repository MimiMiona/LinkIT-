namespace LinkIT_
{
    partial class UCInscriptos
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
            panel1 = new Panel();
            labelTitulo = new Label();
            btnAtras = new Button();
            labelInfo = new Label();
            labelOcupacion = new Label();
            progressBar1 = new ProgressBar();
            dataGridView1 = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Ivory;
            panel1.Controls.Add(labelTitulo);
            panel1.Controls.Add(btnAtras);
            panel1.Controls.Add(labelInfo);
            panel1.Controls.Add(labelOcupacion);
            panel1.Controls.Add(progressBar1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(20);
            panel1.Size = new Size(1173, 150);
            panel1.TabIndex = 1;
            // 
            // labelTitulo
            // 
            labelTitulo.AutoSize = true;
            labelTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            labelTitulo.Location = new Point(20, 60);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new Size(213, 30);
            labelTitulo.TabIndex = 0;
            labelTitulo.Text = "Nombre del Evento";
            // 
            // btnAtras
            // 
            btnAtras.ForeColor = SystemColors.ControlDarkDark;
            btnAtras.Location = new Point(20, 20);
            btnAtras.Name = "btnAtras";
            btnAtras.Size = new Size(160, 30);
            btnAtras.TabIndex = 1;
            btnAtras.Text = "⬅ Volver a Mis Eventos";
            // 
            // labelInfo
            // 
            labelInfo.AutoSize = true;
            labelInfo.Font = new Font("Segoe UI", 9F);
            labelInfo.Location = new Point(20, 100);
            labelInfo.Name = "labelInfo";
            labelInfo.Size = new Size(133, 15);
            labelInfo.TabIndex = 2;
            labelInfo.Text = "2026-03-15 09:00 - 12:00";
            // 
            // labelOcupacion
            // 
            labelOcupacion.AutoSize = true;
            labelOcupacion.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelOcupacion.ForeColor = Color.ForestGreen;
            labelOcupacion.Location = new Point(920, 84);
            labelOcupacion.Name = "labelOcupacion";
            labelOcupacion.Size = new Size(200, 19);
            labelOcupacion.TabIndex = 3;
            labelOcupacion.Text = "4 inscriptos • 84% ocupación";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(20, 120);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(1100, 18);
            progressBar1.TabIndex = 4;
            progressBar1.Value = 84;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.Location = new Point(20, 160);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1110, 520);
            dataGridView1.TabIndex = 0;
            // Columnas
            dataGridView1.Columns.Add("Participante", "PARTICIPANTE");
            dataGridView1.Columns.Add("Correo", "CORREO");
            dataGridView1.Columns.Add("FechaInscripcion", "FECHA DE INSCRIPCION");

            DataGridViewButtonColumn btnCol = new DataGridViewButtonColumn
            {
                HeaderText = "ACCION",
                Text = "Dar de Baja",
                UseColumnTextForButtonValue = true,
                Width = 120
            };
            dataGridView1.Columns.Add(btnCol);
            // 
            // UCInscriptos
            // 
            BackColor = Color.White;
            Controls.Add(dataGridView1);
            Controls.Add(panel1);
            Name = "UCInscriptos";
            Size = new Size(1173, 700);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label2;
        private Label labelInfo;
        private ProgressBar progressBar1;
        private Label labelOcupacion;
        private Label label;
        private Button btnAtras;
        private DataGridView dataGridView1;
        private Label labelTitulo;
    }
}
