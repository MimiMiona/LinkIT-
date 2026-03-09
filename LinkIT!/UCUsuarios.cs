using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace LinkIT_
{
    public partial class UCUsuarios : UserControl
    {
        private int idSeleccionado = 0; // Almacena el ID del usuario seleccionado
        private string rolVista; // Almacena el rol de usuario para ajustar la vista
        bool mostrandoActivos = true; // Variable que indica si se muestran usuarios activos
        private DataTable usuariosDT; // Almacena los usuarios en un DataTable

        // Constructor que recibe el rol del usuario y configura la vista
        public UCUsuarios(string rol)
        {
            InitializeComponent(); // Inicializa los componentes del UserControl

            rolVista = rol; // Asigna el rol de vista

            ConfigurarVista(); // Configura la vista según el rol
            MostrarUsuarios(rolVista); // Muestra los usuarios de acuerdo al rol
        }

        // Evento que filtra los usuarios al escribir en el cuadro de búsqueda
        private void textBoxBuscar_TextChanged(object sender, EventArgs e)
        {
            if (usuariosDT == null)
                return;

            // Se limpia el filtro de búsqueda
            string filtro = textBoxBuscar.Text.Trim().Replace("'", "''"); // Evita errores por comillas

            // Filtra los usuarios por nombre, correo o DNI
            DataView dv = new DataView(usuariosDT);
            dv.RowFilter = $"nombre LIKE '%{filtro}%' OR correo LIKE '%{filtro}%' OR Convert(DNI, 'System.String') LIKE '%{filtro}%'";

            // Actualiza el DataGridView con el filtro aplicado
            dataGridView1.DataSource = dv;
        }

        // Configura la vista dependiendo del rol del usuario
        private void ConfigurarVista()
        {
            if (rolVista == "Jefe de Eventos")
            {
                labelClave.Visible = true;
                textClave.Visible = true;
                bGuardar.Visible = true;
            }
            else
            {
                labelClave.Visible = false;
                textClave.Visible = false;
                bGuardar.Visible = false;
            }
        }

        // Método que muestra los usuarios de acuerdo al rol y si están activos o no
        private void MostrarUsuarios(string rol)
        {
            Conexion con = new Conexion(); // Crea la conexión con la base de datos

            // Consulta SQL para obtener los usuarios activos (o eliminados) dependiendo de la variable mostrandoActivos
            string query = @"
                SELECT 
                    u.id_usuario,
                    u.nombre,
                    u.DNI,
                    u.correo,
                    r.nombre AS rol,
                    u.fecha_registro,
                    u.activo
                FROM Usuario u
                INNER JOIN Rol r ON u.id_rol = r.id_rol
                WHERE u.activo = @activo
            ";

            if (rol != "Todos")
            {
                query += " AND r.nombre = @rol"; // Filtro por rol si no es "Todos"
            }

            // Prepara el comando SQL para la consulta
            SqlCommand cmd = new SqlCommand(query, con.AbrirConexion());
            cmd.Parameters.AddWithValue("@activo", mostrandoActivos ? 1 : 0); // Si se muestran usuarios activos, el parámetro es 1, sino 0

            if (rol != "Todos")
                cmd.Parameters.AddWithValue("@rol", rol); // Si no es "Todos", añade el filtro por rol

            SqlDataAdapter da = new SqlDataAdapter(cmd); // Adapta los datos de la consulta
            DataTable dt = new DataTable(); // Crea un DataTable para almacenar los resultados
            da.Fill(dt); // Llena el DataTable con los resultados de la consulta
            usuariosDT = dt; // Asigna el DataTable a la variable global

            dataGridView1.DataSource = dt; // Muestra los usuarios en el DataGridView

            con.CerrarConexion(); // Cierra la conexión con la base de datos
        }

        // Evento que maneja la selección de una fila en el DataGridView
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Verifica si se hizo clic en una fila válida
            {
                DataGridViewRow fila = dataGridView1.Rows[e.RowIndex]; // Obtiene la fila seleccionada

                idSeleccionado = Convert.ToInt32(fila.Cells["id_usuario"].Value); // Obtiene el ID del usuario seleccionado

                // Rellena los campos de texto con los datos del usuario seleccionado
                textNombre.Text = fila.Cells["nombre"].Value.ToString();
                textCorreo.Text = fila.Cells["correo"].Value.ToString();
                textDNI.Text = fila.Cells["DNI"].Value.ToString();
            }
        }

        // Método que cifra la contraseña usando SHA256
        private string HashPassword(string password)
        {
            using (SHA256 sha = SHA256.Create()) // Crea un objeto SHA256 para el hash
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password)); // Computa el hash de la contraseña
                StringBuilder builder = new StringBuilder();

                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("X2")); // Convierte cada byte en su representación hexadecimal
                }

                return builder.ToString(); // Devuelve la contraseña cifrada
            }
        }

        // Evento que guarda un nuevo usuario (Jefe de Eventos)
        private void bGuardar_Click(object sender, EventArgs e)
        {
            // Verifica que todos los campos estén completos
            if (textNombre.Text == "" || textCorreo.Text == "" || textDNI.Text == "" || textClave.Text == "")
            {
                MessageBox.Show("Complete todos los campos");
                return;
            }

            Conexion con = new Conexion(); // Crea la conexión con la base de datos

            // Consulta para verificar si el correo o DNI ya están registrados
            SqlCommand verificar = new SqlCommand(
                "SELECT COUNT(*) FROM Usuario WHERE correo=@correo OR DNI=@dni",
                con.AbrirConexion());

            verificar.Parameters.AddWithValue("@correo", textCorreo.Text);
            verificar.Parameters.AddWithValue("@dni", textDNI.Text);

            int existe = (int)verificar.ExecuteScalar(); // Ejecuta la consulta y obtiene el resultado

            if (existe > 0) // Si ya existe un usuario con ese correo o DNI, muestra un mensaje
            {
                MessageBox.Show("Ya existe un usuario con ese correo o DNI");
                con.CerrarConexion();
                return;
            }

            // Hashea la contraseña antes de guardarla
            string claveHash = HashPassword(textClave.Text);

            // Comando SQL para insertar un nuevo usuario
            SqlCommand cmd = new SqlCommand(@"
                INSERT INTO Usuario
                (id_rol, nombre, correo, contraseña, dni, fecha_registro, activo)
                VALUES
                (2,@nombre,@correo,@clave,@dni,GETDATE(),1)
            ", con.AbrirConexion());

            cmd.Parameters.AddWithValue("@nombre", textNombre.Text);
            cmd.Parameters.AddWithValue("@correo", textCorreo.Text);
            cmd.Parameters.AddWithValue("@clave", claveHash);
            cmd.Parameters.AddWithValue("@dni", textDNI.Text);

            cmd.ExecuteNonQuery(); // Ejecuta la consulta
            con.CerrarConexion(); // Cierra la conexión

            MessageBox.Show("Jefe de eventos creado");

            MostrarUsuarios(rolVista); // Actualiza la lista de usuarios
            LimpiarCampos(); // Limpia los campos del formulario
        }

        // Evento que modifica los datos de un usuario seleccionado
        private void bModificar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0) // Verifica si se ha seleccionado un usuario
            {
                MessageBox.Show("Seleccione un usuario");
                return;
            }

            Conexion con = new Conexion(); // Crea la conexión con la base de datos

            // Comando SQL para modificar los datos del usuario
            SqlCommand cmd = new SqlCommand(@"
            UPDATE Usuario 
            SET nombre=@nombre,
                correo=@correo,
                DNI=@dni
            WHERE id_usuario=@id",
            con.AbrirConexion());

            cmd.Parameters.AddWithValue("@nombre", textNombre.Text);
            cmd.Parameters.AddWithValue("@correo", textCorreo.Text);
            cmd.Parameters.AddWithValue("@dni", textDNI.Text);
            cmd.Parameters.AddWithValue("@id", idSeleccionado);

            cmd.ExecuteNonQuery(); // Ejecuta la consulta
            con.CerrarConexion(); // Cierra la conexión

            MessageBox.Show("Usuario modificado");

            MostrarUsuarios(rolVista); // Actualiza la lista de usuarios
            LimpiarCampos(); // Limpia los campos del formulario
            idSeleccionado = 0; // Resetea la variable idSeleccionado
        }

        // Evento que elimina (desactiva) un usuario o lo reactiva
        private void bEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0) // Verifica si se ha seleccionado un usuario
            {
                MessageBox.Show("Seleccione un usuario");
                return;
            }

            Conexion con = new Conexion(); // Crea la conexión con la base de datos

            if (mostrandoActivos) // Si se están mostrando usuarios activos
            {
                // Comando para desactivar al usuario (poner activo=0)
                SqlCommand cmd = new SqlCommand(
                "UPDATE Usuario SET activo = 0 WHERE id_usuario=@id",
                con.AbrirConexion());

                cmd.Parameters.AddWithValue("@id", idSeleccionado);
                cmd.ExecuteNonQuery(); // Ejecuta la consulta

                MessageBox.Show("Usuario desactivado");
            }
            else // Si no se están mostrando usuarios activos, los reactiva
            {
                SqlCommand cmd = new SqlCommand(
                "UPDATE Usuario SET activo = 1 WHERE id_usuario=@id",
                con.AbrirConexion());

                cmd.Parameters.AddWithValue("@id", idSeleccionado);
                cmd.ExecuteNonQuery(); // Ejecuta la consulta

                MessageBox.Show("Usuario activado");
            }

            con.CerrarConexion(); // Cierra la conexión

            MostrarUsuarios(rolVista); // Actualiza la lista de usuarios
            LimpiarCampos(); // Limpia los campos del formulario
            idSeleccionado = 0; // Resetea la variable idSeleccionado
        }

        // Evento que alterna entre mostrar usuarios activos y eliminados
        private void bMostrar_Click(object sender, EventArgs e)
        {
            mostrandoActivos = !mostrandoActivos;

            if (mostrandoActivos)
            {
                bMostrar.Text = "Mostrar Eliminados";
                bEliminar.Text = "Eliminar";
            }
            else
            {
                bMostrar.Text = "Mostrar Activos";
                bEliminar.Text = "Activar";
            }

            MostrarUsuarios(rolVista); // Actualiza la lista de usuarios
        }

        // Evento para limpiar los campos de texto
        private void bLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos(); // Llama al método que limpia los campos
        }

        // Método que limpia los campos de texto
        private void LimpiarCampos()
        {
            textNombre.Clear();
            textCorreo.Clear();
            textDNI.Clear();
            textClave.Clear();
        }
    }
}