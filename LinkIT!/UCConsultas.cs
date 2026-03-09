using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace LinkIT_
{
    public partial class UCConsultas : UserControl
    {
        private bool mostrandoPendientes = true; // Controla si estamos mostrando las consultas pendientes o atendidas
        private DataTable consultasDT; // DataTable para manejar los datos de las consultas

        // Constructor que inicializa el UserControl
        public UCConsultas()
        {
            InitializeComponent();
            InicializarDataGridView();
            CargarConsultas();
        }

        // Configuración inicial del DataGridView
        private void InicializarDataGridView()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Columna para el nombre del usuario
            DataGridViewTextBoxColumn colNombre = new DataGridViewTextBoxColumn
            {
                Name = "Nombre",
                HeaderText = "Nombre",
                ReadOnly = true
            };
            dataGridView1.Columns.Add(colNombre);

            // Columna para el correo del usuario
            DataGridViewTextBoxColumn colCorreo = new DataGridViewTextBoxColumn
            {
                Name = "Correo",
                HeaderText = "Correo",
                ReadOnly = true
            };
            dataGridView1.Columns.Add(colCorreo);

            // Columna para el estado de la consulta
            DataGridViewTextBoxColumn colEstado = new DataGridViewTextBoxColumn
            {
                Name = "Estado",
                HeaderText = "Estado",
                ReadOnly = true
            };
            dataGridView1.Columns.Add(colEstado);

            // Columna para la acción de ver detalles de la consulta
            DataGridViewButtonColumn colVer = new DataGridViewButtonColumn
            {
                Name = "Accion",
                HeaderText = "Acción",
                Text = "Ver",
                UseColumnTextForButtonValue = true
            };
            dataGridView1.Columns.Add(colVer);

            dataGridView1.CellClick += dataGridView1_CellClick; // Evento cuando se hace clic en una celda
        }

        // Método que carga las consultas de la base de datos en el DataGridView
        private void CargarConsultas()
        {
            dataGridView1.Rows.Clear();

            // DataTable que se usará para filtrar y cargar las consultas
            consultasDT = new DataTable();
            consultasDT.Columns.Add("Nombre", typeof(string));
            consultasDT.Columns.Add("Correo", typeof(string));
            consultasDT.Columns.Add("Estado", typeof(string));
            consultasDT.Columns.Add("idConsulta", typeof(int));
            consultasDT.Columns.Add("descripcion", typeof(string));

            Conexion con = new Conexion();
            string estado = mostrandoPendientes ? "pendiente" : "atendida"; // Filtrar por estado (pendiente o atendida)

            // Consultar la base de datos según el estado de la consulta
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

                // Leer los datos de cada consulta
                string nombre = reader["nombre"].ToString();
                string correo = reader["correo"].ToString();
                string estadoRow = reader["estado"].ToString();
                int idConsulta = Convert.ToInt32(reader["id_consulta"]);
                string descripcion = reader["descripcion"].ToString();

                // Agregar los datos al DataGridView
                int fila = dataGridView1.Rows.Add(nombre, correo, estadoRow);

                // Asociar los datos de la consulta con cada fila (esto se usa al hacer clic en el botón "Ver")
                dataGridView1.Rows[fila].Tag = new
                {
                    idConsulta = idConsulta,
                    descripcion = descripcion
                };

                // Agregar los datos al DataTable para permitir filtrado
                consultasDT.Rows.Add(nombre, correo, estadoRow, idConsulta, descripcion);
            }

            reader.Close();
            con.CerrarConexion();

            // Ocultar el DataGridView si no hay datos
            dataGridView1.Visible = hayDatos;
        }

        // Filtrar las consultas a medida que se escribe en el campo de búsqueda
        private void textBoxBuscar_TextChanged(object sender, EventArgs e)
        {
            if (consultasDT == null) return;

            string filtro = textBoxBuscar.Text.Trim().ToLower();

            dataGridView1.Rows.Clear();

            // Filtrar las filas de acuerdo con el texto introducido
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

                    // Asociar los datos de la consulta con la fila
                    dataGridView1.Rows[fila].Tag = new
                    {
                        idConsulta = (int)row["idConsulta"],
                        descripcion = row["descripcion"].ToString()
                    };
                }
            }

            // Ocultar el DataGridView si no hay resultados filtrados
            dataGridView1.Visible = dataGridView1.Rows.Count > 0;
        }

        // Evento cuando se hace clic en el botón "Ver" de una consulta
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dataGridView1.Columns[e.ColumnIndex].Name != "Accion") return;

            var datos = dataGridView1.Rows[e.RowIndex].Tag;
            if (datos == null) return;

            dynamic consulta = datos;

            // Mostrar el formulario de detalles de la consulta
            FormVerConsulta form = new FormVerConsulta(
                consulta.idConsulta,
                consulta.descripcion,
                dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(),
                dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(),
                dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString()
            );

            form.ShowDialog();

            // Recargar las consultas después de que una consulta ha sido atendida
            CargarConsultas();
        }

        // Cambiar entre mostrar las consultas pendientes y atendidas
        private void bMostrar_Click(object sender, EventArgs e)
        {
            // Alternar entre pendientes y atendidas
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

            // Recargar las consultas con el nuevo filtro
            CargarConsultas();
        }
    }
}