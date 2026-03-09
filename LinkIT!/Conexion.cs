using Microsoft.Data.SqlClient;
using System;

namespace LinkIT_
{
    public class Conexion
    {
        // Cadena de conexión a la base de datos LinkIT
        private SqlConnection conexion = new SqlConnection(
            @"Server=localhost\SQLEXPRESS;Database=LinkIT;Trusted_Connection=True;TrustServerCertificate=True;");

        // Método para abrir la conexión a la base de datos
        public SqlConnection AbrirConexion()
        {
            if (conexion.State == System.Data.ConnectionState.Closed)
                conexion.Open();
            return conexion;
        }

        // Método para cerrar la conexión a la base de datos
        public SqlConnection CerrarConexion()
        {
            if (conexion.State == System.Data.ConnectionState.Open)
                conexion.Close();
            return conexion;
        }

        // Método para realizar un backup de la base de datos LinkIT
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

        // Método para restaurar la base de datos LinkIT desde un backup
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