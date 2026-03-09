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
        private int idSeleccionado = 0;
        private string rolVista;
        bool mostrandoActivos = true;
        private DataTable usuariosDT;

        public UCUsuarios(string rol)
        {
            InitializeComponent();

            rolVista = rol;

            ConfigurarVista();
            MostrarUsuarios(rolVista);
        }

        private void textBoxBuscar_TextChanged(object sender, EventArgs e)
        {
            if (usuariosDT == null)
                return;

            string filtro = textBoxBuscar.Text.Trim().Replace("'", "''"); // Evitar errores por comillas

            DataView dv = new DataView(usuariosDT);

            // Filtramos por nombre, correo o DNI (puedes agregar más columnas)
            dv.RowFilter = $"nombre LIKE '%{filtro}%' OR correo LIKE '%{filtro}%' OR Convert(DNI, 'System.String') LIKE '%{filtro}%'";

            dataGridView1.DataSource = dv;
        }

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

        private void MostrarUsuarios(string rol)
        {
            Conexion con = new Conexion();

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
                query += " AND r.nombre = @rol";
            }

            SqlCommand cmd = new SqlCommand(query, con.AbrirConexion());

            cmd.Parameters.AddWithValue("@activo", mostrandoActivos ? 1 : 0);

            if (rol != "Todos")
                cmd.Parameters.AddWithValue("@rol", rol);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            usuariosDT = dt;

            dataGridView1.DataSource = dt;

            con.CerrarConexion();


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];

                idSeleccionado = Convert.ToInt32(fila.Cells["id_usuario"].Value);

                textNombre.Text = fila.Cells["nombre"].Value.ToString();
                textCorreo.Text = fila.Cells["correo"].Value.ToString();
                textDNI.Text = fila.Cells["DNI"].Value.ToString();
            }
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();

                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("X2"));
                }

                return builder.ToString();
            }
        }

        private void bGuardar_Click(object sender, EventArgs e)
        {
            if (textNombre.Text == "" || textCorreo.Text == "" || textDNI.Text == "" || textClave.Text == "")
            {
                MessageBox.Show("Complete todos los campos");
                return;
            }

            Conexion con = new Conexion();

            SqlCommand verificar = new SqlCommand(
            "SELECT COUNT(*) FROM Usuario WHERE correo=@correo OR DNI=@dni",
            con.AbrirConexion());

            verificar.Parameters.AddWithValue("@correo", textCorreo.Text);
            verificar.Parameters.AddWithValue("@dni", textDNI.Text);

            int existe = (int)verificar.ExecuteScalar();

            if (existe > 0)
            {
                MessageBox.Show("Ya existe un usuario con ese correo o DNI");
                con.CerrarConexion();
                return;
            }

            string claveHash = HashPassword(textClave.Text);

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

            cmd.ExecuteNonQuery();
            con.CerrarConexion();

            MessageBox.Show("Jefe de eventos creado");

            MostrarUsuarios(rolVista);
            LimpiarCampos();
        }

        private void bModificar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un usuario");
                return;
            }

            Conexion con = new Conexion();

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

            cmd.ExecuteNonQuery();
            con.CerrarConexion();

            MessageBox.Show("Usuario modificado");

            MostrarUsuarios(rolVista);
            LimpiarCampos();
            idSeleccionado = 0;
        }

        private void bEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un usuario");
                return;
            }

            Conexion con = new Conexion();

            if (mostrandoActivos)
            {
                SqlCommand cmd = new SqlCommand(
                "UPDATE Usuario SET activo = 0 WHERE id_usuario=@id",
                con.AbrirConexion());

                cmd.Parameters.AddWithValue("@id", idSeleccionado);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Usuario desactivado");
            }
            else
            {
                SqlCommand cmd = new SqlCommand(
                "UPDATE Usuario SET activo = 1 WHERE id_usuario=@id",
                con.AbrirConexion());

                cmd.Parameters.AddWithValue("@id", idSeleccionado);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Usuario activado");
            }

            con.CerrarConexion();

            MostrarUsuarios(rolVista);
            LimpiarCampos();
            idSeleccionado = 0;
        }

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

            MostrarUsuarios(rolVista);
        }



        private void bLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            textNombre.Clear();
            textCorreo.Clear();
            textDNI.Clear();
            textClave.Clear();
        }

        
    }
}