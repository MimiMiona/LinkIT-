using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace LinkIT_
{
    public partial class UCConsultas : UserControl
    {
      
        private bool mostrandoPendientes = true;
        private DataTable consultasDT;
        public UCConsultas()
        {
            InitializeComponent();
            InicializarDataGridView();
            CargarConsultas();
        }

        private void InicializarDataGridView()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            DataGridViewTextBoxColumn colNombre = new DataGridViewTextBoxColumn();
            colNombre.Name = "Nombre";
            colNombre.HeaderText = "Nombre";
            colNombre.ReadOnly = true;
            dataGridView1.Columns.Add(colNombre);

            DataGridViewTextBoxColumn colCorreo = new DataGridViewTextBoxColumn();
            colCorreo.Name = "Correo";
            colCorreo.HeaderText = "Correo";
            colCorreo.ReadOnly = true;
            dataGridView1.Columns.Add(colCorreo);

            DataGridViewTextBoxColumn colEstado = new DataGridViewTextBoxColumn();
            colEstado.Name = "Estado";
            colEstado.HeaderText = "Estado";
            colEstado.ReadOnly = true;
            dataGridView1.Columns.Add(colEstado);

            DataGridViewButtonColumn colVer = new DataGridViewButtonColumn();
            colVer.Name = "Accion";
            colVer.HeaderText = "Acción";
            colVer.Text = "Ver";
            colVer.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(colVer);

            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        private void CargarConsultas()
        {
            dataGridView1.Rows.Clear();

            // Creamos el DataTable para guardar los datos y filtrar
            consultasDT = new DataTable();
            consultasDT.Columns.Add("Nombre", typeof(string));
            consultasDT.Columns.Add("Correo", typeof(string));
            consultasDT.Columns.Add("Estado", typeof(string));
            consultasDT.Columns.Add("idConsulta", typeof(int));
            consultasDT.Columns.Add("descripcion", typeof(string));

            Conexion con = new Conexion();

            string estado = mostrandoPendientes ? "pendiente" : "atendida";

            SqlCommand cmd = new SqlCommand(@"
            SELECT c.id_consulta, u.nombre, u.correo, c.descripcion, c.estado
            FROM Consulta c
            INNER JOIN Usuario u ON c.id_usuario = u.id_usuario
            WHERE c.estado = @estado
            ORDER BY c.id_consulta DESC
            ", con.AbrirConexion());

            cmd.Parameters.AddWithValue("@estado", estado);

            SqlDataReader reader = cmd.ExecuteReader();

            bool hayDatos = false;

            while (reader.Read())
            {
                hayDatos = true;

                string nombre = reader["nombre"].ToString();
                string correo = reader["correo"].ToString();
                string estadoRow = reader["estado"].ToString();
                int idConsulta = Convert.ToInt32(reader["id_consulta"]);
                string descripcion = reader["descripcion"].ToString();

                int fila = dataGridView1.Rows.Add(
                    nombre,
                    correo,
                    estadoRow

                );

                dataGridView1.Rows[fila].Tag = new
                {
                    idConsulta = idConsulta,
                    descripcion = descripcion
                };
                consultasDT.Rows.Add(nombre, correo, estadoRow, idConsulta, descripcion);
            }

            reader.Close();
            con.CerrarConexion();

            // ocultar tabla si no hay datos
            dataGridView1.Visible = hayDatos;
        }

        private void textBoxBuscar_TextChanged(object sender, EventArgs e)
        {
            if (consultasDT == null) return;

            string filtro = textBoxBuscar.Text.Trim().ToLower();

            dataGridView1.Rows.Clear();

            foreach (DataRow row in consultasDT.Rows)
            {
                string nombre = row["Nombre"].ToString().ToLower();
                string correo = row["Correo"].ToString().ToLower();
                string estado = row["Estado"].ToString().ToLower();

                if (nombre.Contains(filtro) || correo.Contains(filtro) || estado.Contains(filtro))
                {
                    int fila = dataGridView1.Rows.Add(
                        row["Nombre"],
                        row["Correo"],
                        row["Estado"]
                    );

                    dataGridView1.Rows[fila].Tag = new
                    {
                        idConsulta = (int)row["idConsulta"],
                        descripcion = row["descripcion"].ToString()
                    };
                }
            }

            // ocultar tabla si no hay datos filtrados
            dataGridView1.Visible = dataGridView1.Rows.Count > 0;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dataGridView1.Columns[e.ColumnIndex].Name != "Accion") return;

            var datos = dataGridView1.Rows[e.RowIndex].Tag;
            if (datos == null) return;

            dynamic consulta = datos;

            FormVerConsulta form = new FormVerConsulta(
                consulta.idConsulta,
                consulta.descripcion,
                dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(),
                dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(),
                dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString()
            );

            form.ShowDialog();

            // recargar luego de atender
            CargarConsultas();
        }

        private void bMostrar_Click(object sender, EventArgs e)
        {
            // alternar entre pendientes y atendidas
            mostrandoPendientes = !mostrandoPendientes;

            if (mostrandoPendientes)
            {
                bMostrar.Text = "Mostrar atendidas";
                labelSinConsultas.Text = "No Hay Consultas Pendientes";
            }
            else
            {
                bMostrar.Text = "Mostrar pendientes";
                labelSinConsultas.Text = "No Hay Consultas Atendidas";
            }
    
            CargarConsultas();
        }
    }
}