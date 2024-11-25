using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Se importa la libreria para manejar SQL
using System.Data.SqlClient;


namespace InventarioPlus.DataAcces
{
    class ConexionDB
    {
        // Se obtiene la cade de conexion desde settings del proyecto
        public static string ObtenerCadena()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            {
                DataSource = @"VLADIMIR\SQLEXPRESS",  // Servidor y nombre de instancia
                InitialCatalog = "ATLAS_INVENTARIO", // Nombre de la base de datos
                IntegratedSecurity = true,          // Usar autenticación de Windows
                Encrypt = false,                    // Desactivar encriptación
                TrustServerCertificate = true      // Permitir certificados no confiables
            };
            return builder.ConnectionString;
        }
    }
}
