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
            button1 = new Button();
            labelTitulo = new Label();
            btnAtras = new Button();
            labelInfo = new Label();
            labelOcupacion = new Label();
            progressBar1 = new ProgressBar();
            dataGridView1 = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            btnCol = new DataGridViewButtonColumn();
            textBoxBuscar = new TextBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Ivory;
            panel1.Controls.Add(button1);
            panel1.Controls.Add(labelTitulo);
            panel1.Controls.Add(btnAtras);
            panel1.Controls.Add(labelInfo);
            panel1.Controls.Add(labelOcupacion);
            panel1.Controls.Add(progressBar1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(20);
            panel1.Size = new Size(1173, 197);
            panel1.TabIndex = 1;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.Window;
            button1.Enabled = false;
            button1.FlatStyle = FlatStyle.Popup;
            button1.ForeColor = SystemColors.ControlText;
            button1.Location = new Point(1080, 163);
            button1.Margin = new Padding(0);
            button1.Name = "button1";
            button1.Size = new Size(46, 25);
            button1.TabIndex = 12;
            button1.TabStop = false;
            button1.Text = "🔍";
            button1.UseVisualStyleBackColor = false;
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
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, btnCol });
            dataGridView1.Location = new Point(20, 194);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1110, 486);
            dataGridView1.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Participante";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Correo";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Fecha de Inscripcion";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // btnCol
            // 
            btnCol.Name = "btnCol";
            // 
            // textBoxBuscar
            // 
            textBoxBuscar.Font = new Font("Segoe UI", 10F);
            textBoxBuscar.ForeColor = SystemColors.ActiveCaptionText;
            textBoxBuscar.Location = new Point(20, 163);
            textBoxBuscar.Name = "textBoxBuscar";
            textBoxBuscar.Size = new Size(1054, 25);
            textBoxBuscar.TabIndex = 11;
            textBoxBuscar.TextChanged += textBoxBuscar_TextChanged;
            // 
            // UCInscriptos
            // 
            BackColor = Color.White;
            Controls.Add(dataGridView1);
            Controls.Add(textBoxBuscar);
            Controls.Add(panel1);
            Name = "UCInscriptos";
            Size = new Size(1173, 700);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewButtonColumn btnCol;
        private Button button1;
        private TextBox textBoxBuscar;
    }
}
