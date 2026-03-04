using Microsoft.Data.SqlClient;
namespace LinkIT_
{
    public class Conexion
    {
        private SqlConnection conexion = new SqlConnection(
            @"Server=(localdb)\MSSQLLocalDB;Database=LinkIT;Trusted_Connection=True;");

        public SqlConnection AbrirConexion()
        {
            if (conexion.State == System.Data.ConnectionState.Closed)
                conexion.Open();
            return conexion;
        }

        public SqlConnection CerrarConexion()
        {
            if (conexion.State == System.Data.ConnectionState.Open)
                conexion.Close();
            return conexion;
        }
    }
}