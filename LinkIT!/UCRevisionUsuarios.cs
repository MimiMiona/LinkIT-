using Microsoft.Data.SqlClient;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace LinkIT_
{
    public partial class UCRevisionUsuarios : UserControl
    {
        public int idUsuario; // Almacena el id del usuario logueado

        // Constructor que recibe el id del usuario logueado
        public UCRevisionUsuarios(int idUsuarioLogueado)
        {
            InitializeComponent(); // Inicializa los componentes del UserControl

            idUsuario = idUsuarioLogueado; // Asigna el id del usuario logueado

            dataGridView1.Columns.Clear(); // Limpia las columnas del DataGridView

            // Agrega las columnas para Nombre, Correo, y Fecha de Solicitud
            dataGridView1.Columns.Add("colNombre", "Nombre");
            dataGridView1.Columns.Add("colCorreo", "Correo");
            dataGridView1.Columns.Add("colFecha", "Fecha Solicitud");

            // Agrega una columna de botón para aprobar
            DataGridViewButtonColumn aprobar = new DataGridViewButtonColumn();
            aprobar.Name = "colAprobar";
            aprobar.HeaderText = "Aprobar";
            aprobar.Text = "Aprobar";
            aprobar.UseColumnTextForButtonValue = true;

            // Agrega una columna de botón para rechazar
            DataGridViewButtonColumn rechazar = new DataGridViewButtonColumn();
            rechazar.Name = "colRechazar";
            rechazar.HeaderText = "Rechazar";
            rechazar.Text = "Rechazar";
            rechazar.UseColumnTextForButtonValue = true;

            // Agrega las columnas de aprobar y rechazar al DataGridView
            dataGridView1.Columns.Add(aprobar);
            dataGridView1.Columns.Add(rechazar);

            // Configura algunas propiedades del DataGridView
            dataGridView1.AllowUserToAddRows = false; // Evita que el usuario agregue filas
            dataGridView1.RowHeadersVisible = false; // Oculta las cabeceras de las filas
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Ajusta el tamaño de las columnas

            // Asocia el evento de clic a una celda con el método dataGridView1_CellContentClick
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;

            // Carga las solicitudes pendientes de los usuarios
            CargarUsuariosPendientes();
        }

        // Método para cargar las solicitudes pendientes desde la base de datos
        private void CargarUsuariosPendientes()
        {
            dataGridView1.Rows.Clear(); // Limpia las filas del DataGridView

            Conexion con = new Conexion(); // Crea la conexión con la base de datos

            // Consulta SQL para obtener las solicitudes pendientes
            SqlCommand cmd = new SqlCommand(@"
            SELECT id_solicitud, nombre, correo, fecha_solicitud
            FROM Solicitud
            WHERE estado = 'pendiente'
            ORDER BY fecha_solicitud DESC
            ", con.AbrirConexion());

            SqlDataReader reader = cmd.ExecuteReader(); // Ejecuta la consulta

            bool haySolicitudes = false; // Flag para verificar si hay solicitudes pendientes

            // Recorre los resultados de la consulta
            while (reader.Read())
            {
                haySolicitudes = true;

                // Agrega una fila con los datos de cada solicitud
                int fila = dataGridView1.Rows.Add(
                    reader["nombre"].ToString(),
                    reader["correo"].ToString(),
                    Convert.ToDateTime(reader["fecha_solicitud"]).ToString("dd/MM/yyyy HH:mm")
                );

                // Guarda el id de la solicitud en el Tag de la fila para poder acceder a él más tarde
                dataGridView1.Rows[fila].Tag = Convert.ToInt32(reader["id_solicitud"]);
            }

            reader.Close(); // Cierra el lector de datos
            con.CerrarConexion(); // Cierra la conexión con la base de datos

            // Si no hay solicitudes pendientes, muestra un mensaje
            if (!haySolicitudes)
            {
                panelSinSolicitudes.Visible = true; // Muestra el panel de "sin solicitudes"
                dataGridView1.Visible = false; // Oculta el DataGridView
            }
            else
            {
                panelSinSolicitudes.Visible = false; // Oculta el panel de "sin solicitudes"
                dataGridView1.Visible = true; // Muestra el DataGridView
            }
        }

        // Evento que se dispara cuando se hace clic en una celda del DataGridView
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Protecciones para evitar errores
            if (e.RowIndex < 0) return; // Evita clics en el encabezado
            if (e.RowIndex >= dataGridView1.Rows.Count) return; // Evita clics fuera de las filas
            if (e.ColumnIndex < 0) return; // Evita clics en las filas de cabecera

            var fila = dataGridView1.Rows[e.RowIndex]; // Obtiene la fila seleccionada

            if (fila.Tag == null) return; // Si no hay tag en la fila, no hace nada

            int idSolicitud = Convert.ToInt32(fila.Tag); // Obtiene el id de la solicitud
            string accion = dataGridView1.Columns[e.ColumnIndex].Name; // Obtiene el nombre de la columna clickeada

            // Si la acción es "Aprobar", llama al método AprobarUsuario
            if (accion == "colAprobar")
            {
                AprobarUsuario(idSolicitud);
            }
            // Si la acción es "Rechazar", llama al método RechazarUsuario
            else if (accion == "colRechazar")
            {
                RechazarUsuario(idSolicitud);
            }

            // Recarga las solicitudes después de la acción
            CargarUsuariosPendientes();
        }

        // Método para aprobar a un usuario
        private void AprobarUsuario(int idSolicitud)
        {
            Conexion con = new Conexion();
            SqlConnection conexion = con.AbrirConexion();

            // Consulta SQL para insertar el nuevo usuario y actualizar la solicitud
            SqlCommand cmd = new SqlCommand(@"
            INSERT INTO Usuario (id_rol,nombre,correo,contraseña,DNI,fecha_registro,activo)
            SELECT 3, nombre, correo, contraseña, DNI, GETDATE(), 1
            FROM Solicitud
            WHERE id_solicitud = @id;

            UPDATE Solicitud
            SET estado = 'aprobado',
                id_usuario = @idusuario
            WHERE id_solicitud = @id
            ", conexion);

            cmd.Parameters.AddWithValue("@id", idSolicitud); // Agrega el parámetro id de la solicitud
            cmd.Parameters.AddWithValue("@idusuario", idUsuario); // Agrega el parámetro id del usuario que aprueba

            cmd.ExecuteNonQuery(); // Ejecuta la consulta
            con.CerrarConexion(); // Cierra la conexión con la base de datos
        }

        // Método para rechazar a un usuario
        private void RechazarUsuario(int idSolicitud)
        {
            Conexion con = new Conexion();

            // Consulta SQL para actualizar el estado de la solicitud a "rechazado"
            SqlCommand cmd = new SqlCommand(@"
            UPDATE Solicitud
            SET estado = 'rechazado',
                id_usuario = @idusuario
            WHERE id_solicitud = @id
            ", con.AbrirConexion());

            cmd.Parameters.AddWithValue("@id", idSolicitud); // Agrega el parámetro id de la solicitud
            cmd.Parameters.AddWithValue("@idusuario", idUsuario); // Agrega el parámetro id del usuario que rechaza

            cmd.ExecuteNonQuery(); // Ejecuta la consulta
            con.CerrarConexion(); // Cierra la conexión con la base de datos
        }
    }
}