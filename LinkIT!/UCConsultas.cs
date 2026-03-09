using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace LinkIT_
{
    public partial class UCConsultas : UserControl
    {
        public UCConsultas()
        {
            InitializeComponent();
            InicializarDataGridView(); // Configurar columnas al inicio
            CargarConsultas();
        }

        // Configura las columnas del DataGridView
        private void InicializarDataGridView()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AllowUserToAddRows = false; // Evitar fila vacía al final

            // Columna Nombre
            DataGridViewTextBoxColumn colNombre = new DataGridViewTextBoxColumn();
            colNombre.Name = "Nombre";
            colNombre.HeaderText = "Nombre";
            colNombre.DataPropertyName = "Nombre";
            colNombre.ReadOnly = true;
            dataGridView1.Columns.Add(colNombre);

            // Columna Estado
            DataGridViewTextBoxColumn colEstado = new DataGridViewTextBoxColumn();
            colEstado.Name = "Estado";
            colEstado.HeaderText = "Estado";
            colEstado.DataPropertyName = "Estado";
            colEstado.ReadOnly = true;
            dataGridView1.Columns.Add(colEstado);

            // Columna Ver (Botón)
            DataGridViewButtonColumn colVer = new DataGridViewButtonColumn();
            colVer.Name = "Accion";
            colVer.HeaderText = "Acción";
            colVer.Text = "Ver";
            colVer.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(colVer);

            // Evento para click en botones
            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        private void CargarConsultas()
        {
            Conexion con = new Conexion();

            SqlCommand cmd = new SqlCommand(@"
    SELECT c.id_consulta, u.nombre, c.descripcion, c.estado
    FROM Consulta c
    INNER JOIN Usuario u ON c.id_usuario = u.id_usuario
    ORDER BY c.estado", con.AbrirConexion());

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int fila = dataGridView1.Rows.Add(
                    reader["nombre"].ToString(),
                    reader["estado"].ToString()
                );

                dataGridView1.Rows[fila].Tag = new
                {
                    idConsulta = Convert.ToInt32(reader["id_consulta"]),
                    descripcion = reader["descripcion"].ToString()
                };
            }

            reader.Close();
            con.CerrarConexion();
        }
        

        // Evento cuando se hace click en el botón "Ver"
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Evitar cabecera

            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                var datos = dataGridView1.Rows[e.RowIndex].Tag;
                dynamic consulta = datos;

                FormVerConsulta form = new FormVerConsulta(
                    consulta.idConsulta,
                    consulta.descripcion
                );

                form.ShowDialog();

                // Recargar después de cerrar
                CargarConsultas();
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}