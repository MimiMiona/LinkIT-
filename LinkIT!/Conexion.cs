using Microsoft.Data.SqlClient;
using System;

namespace LinkIT_
{
    public class Conexion
    {
        private SqlConnection conexion = new SqlConnection(
            @"Server=localhost\SQLEXPRESS;Database=LinkIT;Trusted_Connection=True;TrustServerCertificate=True;");

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

        public void HacerBackup(string ruta)
        {
            SqlConnection conn = new SqlConnection(
                @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;TrustServerCertificate=True;");

            conn.Open();

            string query = $"BACKUP DATABASE LinkIT TO DISK = '{ruta}' WITH INIT";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public void RestoreBackup(string ruta)
        {
            SqlConnection conn = new SqlConnection(
                @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;TrustServerCertificate=True;");

            conn.Open();

            string query = $@"
            ALTER DATABASE LinkIT SET SINGLE_USER WITH ROLLBACK IMMEDIATE
            RESTORE DATABASE LinkIT FROM DISK = '{ruta}' WITH REPLACE
            ALTER DATABASE LinkIT SET MULTI_USER";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();

            conn.Close();
        }
    }
}