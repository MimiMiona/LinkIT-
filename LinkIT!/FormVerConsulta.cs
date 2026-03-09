using Microsoft.Data.SqlClient;
using System;
using System.Windows.Forms;

namespace LinkIT_
{
    public partial class FormVerConsulta : Form
    {
        int idConsulta;
        string estadoConsulta;

        public FormVerConsulta()
        {
            InitializeComponent();
        }

        public FormVerConsulta(int id, string descripcion, string nombre, string correo, string estado)
        {
            InitializeComponent();

            idConsulta = id;
            estadoConsulta = estado;

            // cargar datos en la interfaz
            labelTitulo.Text = "Consulta #" + id;
            labelNombre.Text = "Nombre: " + nombre;
            labelCorreo.Text = "Correo: " + correo;

            textDescripcion.Text = descripcion;
            textDescripcion.DeselectAll();

            // cambiar texto del botón según estado
            if (estadoConsulta.ToLower() == "atendida")
            {
                bAtendida.Text = "Cerrar";
            }
        }

        private void bAtendida_Click(object sender, EventArgs e)
        {
            // si ya está atendida solo cerrar
            if (estadoConsulta.ToLower() == "atendida")
            {
                this.Close();
                return;
            }

            Conexion con = new Conexion();

            SqlCommand cmd = new SqlCommand(
                "UPDATE Consulta SET estado='atendida' WHERE id_consulta=@id",
                con.AbrirConexion());

            cmd.Parameters.AddWithValue("@id", idConsulta);

            cmd.ExecuteNonQuery();
            con.CerrarConexion();

            MessageBox.Show("Consulta marcada como atendida.");

            this.Close();
        }
    }
}