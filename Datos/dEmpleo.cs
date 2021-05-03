using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using Entidades;

namespace Datos
{
    public class dEmpleo
    {
        Database db = new Database();

        public string Insertar(Empleo empleo)
        {
            try
            {
                // 1. Me conecto con la BD
                SqlConnection con = db.ConectaDb();
                // 2. Crear la instruccion SQL
                string insert = string.Format("INSERT INTO Empleos(Nombre, SalarioMinimo, SalarioMaximo) VALUES ('{0}', {1}, {2})", 
                    empleo.Nombre, empleo.SalarioMinimo, empleo.SalarioMaximo);
                // 3. Creo el Command = SQL + Con
                SqlCommand cmd = new SqlCommand(insert, con);
                // 4. Ejecuto
                cmd.ExecuteNonQuery();
                return "Inserto";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                // SIEMPRE SE VA A EJECUTAR=EXITO O FRACASO
                db.DesconectaDb();
            }
        }
        public string Modificar(Empleo empleo)
        {
            try
            {
                // 1. Me conecto con la BD
                SqlConnection con = db.ConectaDb();
                // 2. Crear la instruccion SQL
                string update = string.Format("UPDATE Empleos SET Nombre = '{0}', SalarioMinimo = {1}, SalarioMaximo = {2} WHERE CodEmpleo = {3}", 
                    empleo.Nombre, empleo.SalarioMinimo, empleo.SalarioMaximo, empleo.CodEmpleo);
                SqlCommand cmd = new SqlCommand(update, con);
                cmd.ExecuteNonQuery();
                return "Modificó";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                db.DesconectaDb();
            }
        }
        public string Eliminar(int codEmpleo)
        {
            try
            {
                SqlConnection con = db.ConectaDb();
                string delete = string.Format("DELETE FROM Empleos WHERE CodEmpleo = {0}", codEmpleo);
                SqlCommand cmd = new SqlCommand(delete, con);
                cmd.ExecuteNonQuery();
                return "Elimino";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                db.DesconectaDb();
            }
        }
        public Empleo BuscarPorCod(int codEmpleo)
        {
            try
            {
                // 0. Declara el objeto que contendra los datos de la tabla
                Empleo empleo = null;
                // 1. Me conecto con la BD
                SqlConnection con = db.ConectaDb();
                // 2. Crear la instruccion SQL
                string select = string.Format("SELECT CodEmpleo, Nombre, SalarioMinimo, SalarioMaximo FROM Empleos WHERE CodEmpleo = {0}", codEmpleo);
                // 3. Creo el Command = SQL + Con
                SqlCommand cmd = new SqlCommand(select, con);
                // 4. Ejecuto un ExecuteReader y el resultado lo guardo en reader
                SqlDataReader reader = cmd.ExecuteReader();
                // 5. Extraer del objeto reader los datos .Read() hacia el objeto empleo
                if (reader.Read())
                {
                    // 6. Instancia el objeto
                    empleo = new Empleo();
                    // 7. Transferir los datos de reader a empleo
                    empleo.CodEmpleo = (int)reader["CodEmpleo"];
                    empleo.Nombre = (String)reader["Nombre"];
                    empleo.SalarioMinimo = (decimal)reader["SalarioMinimo"];
                    empleo.SalarioMaximo = (decimal)reader["SalarioMaximo"];
                }
                reader.Close();
                return empleo;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                db.DesconectaDb();
            }
        }
        public List<Empleo> ListarTodo()
        {
            try
            {
                // 0. Declara los objetos que contendra los datos de la tabla
                List<Empleo> empleos = new List<Empleo>();
                Empleo empleo = null;
                // 1. Me conecto con la BD
                SqlConnection con = db.ConectaDb();
                // 2. Crear la instruccion SQL
                string select = "SELECT CodEmpleo, Nombre, SalarioMinimo, SalarioMaximo FROM Empleos";
                // 3. Creo el Command = SQL + Con
                SqlCommand cmd = new SqlCommand(select, con);
                // 4. Ejecuto un ExecuteReader y el resultado lo guardo en reader
                SqlDataReader reader = cmd.ExecuteReader();
                // 5. Extraer del objeto reader los datos con .Read() hacia el objeto empleo
                while (reader.Read())
                {
                    // 6. Instancia el objeto
                    empleo = new Empleo();
                    // 7. Transferir los datos de reader a empleo
                    empleo.CodEmpleo = (int)reader["CodEmpleo"];
                    empleo.Nombre = (String)reader["Nombre"];
                    empleo.SalarioMinimo = (decimal)reader["SalarioMinimo"];
                    empleo.SalarioMaximo = (decimal)reader["SalarioMaximo"];
                    // 8. Agregar el objeto empleo a List de empleos
                    empleos.Add(empleo);
                }
                reader.Close();
                return empleos;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                db.DesconectaDb();
            }
        }
    }
}
