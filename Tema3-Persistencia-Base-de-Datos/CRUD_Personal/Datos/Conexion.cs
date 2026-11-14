using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_Personal.Datos
{
    internal class Conexion
    {
        private const string CadenaConexion =
        @"Server=(localdb)\MSSQLLocalDB;Initial Catalog=AccesoDatos;Integrated Security=true;";

        // Devuelve una conexión YA ABIERTA. Quien la pide la cierra con using.
        public static SqlConnection Conectar()
        {
            var conexion = new SqlConnection(CadenaConexion);
            try
            {
                conexion.Open();
                return conexion;
            }
            catch (SqlException ex)
            {
                conexion.Dispose();
                throw new InvalidOperationException(
                    "No se pudo conectar con la base de datos AccesoDatos", ex);
            }
        }
    }
}
