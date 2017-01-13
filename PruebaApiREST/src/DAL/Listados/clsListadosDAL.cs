using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ENT;

namespace DAL
{
    public class clsListadosDAL
    {
        /// <summary>
        ///     Método que genera un listado de todas las personas de la tabla personas de la base de datos WPFSample.
        /// </summary>
        /// <returns>
        ///     El listado de personas.
        /// </returns>
        public List<clsPersona> getListadoPersonasDAL()
        {
            List<clsPersona> lista = new List<clsPersona>();
            clsMyConnection miConexion = new clsMyConnection();

            SqlConnection conexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            clsPersona persona;
            try
            {
                conexion = miConexion.getConnection();
                miComando.CommandText = "select * from personas";
                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();
                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        persona = new clsPersona();
                        persona.Id = (int)miLector["IDPersona"];
                        persona.Nombre = (String)miLector["nombre"];
                        persona.Apellidos = (String)miLector["apellidos"];
                        persona.FechaNac = (DateTime)miLector["fechaNac"];
                        persona.Direccion = (String)miLector["direccion"];
                        persona.Telefono = (String)miLector["telefono"];

                        lista.Add(persona);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                miConexion.closeConnection(ref conexion);
            }

            return lista;
        }
    }
}
