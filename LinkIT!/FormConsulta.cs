using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LinkIT_
{
    public partial class FormConsulta : Form
    {
        public FormConsulta()
        {
            InitializeComponent();
        }

        private void bEnviar_Click(object sender, EventArgs e)
        {
            string descripcion = textDescripcion.Text.Trim();

            if (descripcion == "")
            {
                MessageBox.Show("Escriba una descripción del problema.");
                return;
            }

            try
            {
                Conexion con = new Conexion();

                SqlCommand cmd = new SqlCommand(
                "INSERT INTO Consulta (id_usuario, descripcion, estado) VALUES (@usuario,@desc,'Pendiente')",
                con.AbrirConexion());

                cmd.Parameters.AddWithValue("@usuario", Login.Sesion.IdUsuario);
                cmd.Parameters.AddWithValue("@desc", descripcion);

                cmd.ExecuteNonQuery();

                con.CerrarConexion();

                MessageBox.Show("Consulta enviada correctamente.");

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
