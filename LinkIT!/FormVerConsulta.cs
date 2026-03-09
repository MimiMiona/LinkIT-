using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace LinkIT_
{
    public partial class FormVerConsulta : Form
    {
        public FormVerConsulta()
        {
            InitializeComponent();
        }
        int idConsulta;

        public FormVerConsulta(int id, string descripcion)
        {
            InitializeComponent();

            idConsulta = id;
            textDescripcion.Text = descripcion;
        } 

        private void bAtendida_Click(object sender, EventArgs e)
        {
            Conexion con = new Conexion();

            SqlCommand cmd = new SqlCommand(
                "UPDATE Consulta SET estado='Atendida' WHERE id_consulta=@id",
                con.AbrirConexion());

            cmd.Parameters.AddWithValue("@id", idConsulta);

            cmd.ExecuteNonQuery();
            con.CerrarConexion();

            MessageBox.Show("Consulta marcada como atendida.");

            this.Close();
        }
    }
}
