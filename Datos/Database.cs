using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Datos
{
    //Objetivo: Brindar la conexión a la BD
    public class Database
    {
        private SqlConnection conn;
        public SqlConnection ConectaDb()
        {
            try
            {
                //Integrated Security=true: Que se están conectando al SQL SERVER
                //con Autenticación Windows
                string cadenadeconexion = "Data Source=localhost;Initial Catalog=dbRRHH;Integrated Security=True";
                conn = new SqlConnection(cadenadeconexion);
                conn.Open();
                return conn;
            }
            catch (SqlException e)
            {
                return null;
            }
        }
        public void DesconectaDb()
        {
            conn.Close();
        }
    }
}