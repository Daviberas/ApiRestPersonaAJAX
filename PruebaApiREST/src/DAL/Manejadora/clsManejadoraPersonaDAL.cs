using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENT;
using DAL;

namespace DAL.Manejadora
{
    public class clsManejadoraPersonaDAL
    {
        private clsMyConnection miConexion;

        public clsManejadoraPersonaDAL()
        {
            miConexion = new clsMyConnection();
        }

        /// <summary>
        /// El método se conecta a la base de datos y obtiene los datos de la persona de id recibido como parámetro.
        /// </summary>
        /// <param name="id">Tipo entero.</param>
        /// <returns>Un objeto de la clase persona si se realiza la operación correctamente, en caso de error se lanzará la excepción correspondiente.</returns>

        public clsPersona obtenerPersonaDAL(int id)
        {
            clsPersona resultado = new clsPersona();

            SqlConnection conexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            
            miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

            try
            {
                conexion = miConexion.getConnection();

                miComando.CommandText = "select nombre, apellidos, fechaNac, telefono, direccion from PERSONAS where IDPersona = @id";
                miComando.Connection = conexion;
                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    if (miLector.Read())
                    {
                        resultado.Id = id;
                        resultado.Nombre = (String)miLector["nombre"];
                        resultado.Apellidos = (String)miLector["apellidos"];
                        resultado.FechaNac = (DateTime)miLector["fechaNac"];
                        resultado.Direccion = (String)miLector["direccion"];
                        resultado.Telefono = (String)miLector["telefono"];
                    }
                }
                else
                    resultado = null;

                return resultado;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
                miConexion.closeConnection(ref conexion);
            }
        }

        /// <summary>
        /// El método se conecta a la base de datos y añade una nueva persona a la tabla personas.
        /// </summary>
        /// <param name="persona">Tipo persona.</param>
        /// <returns>Un entero, que indica el número de filas afectadas, en caso de error se lanzará la excepción correspondiente.</returns>

        public int insertarPersonaDAL(clsPersona persona)
        {
            int resultado = 0;

            SqlConnection conexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            
            miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = persona.Nombre;
            miComando.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar).Value = persona.Apellidos;
            miComando.Parameters.Add("@fechaNac", System.Data.SqlDbType.Date).Value = persona.FechaNac;
            miComando.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = persona.Telefono;
            miComando.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = persona.Direccion;

            try
            {
                conexion = miConexion.getConnection();

                miComando.CommandText = "insert into PERSONAS(nombre,apellidos,fechaNac,telefono,direccion) VALUES (@nombre,@apellidos,@fechaNac,@telefono,@direccion)";
                miComando.Connection = conexion;
                resultado = miComando.ExecuteNonQuery();
                
                return resultado;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
                miConexion.closeConnection(ref conexion);
            }
        }

        /// <summary>
        /// El método se conecta a la base de datos y borra la persona cuyo id coincida con el recibido como parámetro.
        /// </summary>
        /// <param name="id">Tipo entero</param>
        /// <returns>Un entero, que indica el número de filas afectadas, en caso de error se lanzará la excepción correspondiente.</returns>

        public int borrarPersonaDAL(int id)
        {
            int resultado = 0;

            SqlConnection conexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            
            miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

            try
            {
                conexion = miConexion.getConnection();

                miComando.CommandText = "delete from PERSONAS where IDPersona = @id";
                miComando.Connection = conexion;
                resultado = miComando.ExecuteNonQuery();

                return resultado;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
                miConexion.closeConnection(ref conexion);
            }
        
        }

        /// <summary>
        /// El método se conecta a la base de datos y actualiza una persona de la tabla personas.
        /// </summary>
        /// <param name="persona">Tipo persona</param>
        /// <returns>Un entero, que indica el número de filas afectadas, en caso de error se lanzará la excepción correspondiente.</returns>

        public int actualizarPersonaDAL(clsPersona persona)
        {
            int resultado = 0;

            SqlConnection conexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            
            miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = persona.Id;
            miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = persona.Nombre;
            miComando.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar).Value = persona.Apellidos;
            miComando.Parameters.Add("@fechaNac", System.Data.SqlDbType.Date).Value = persona.FechaNac;
            miComando.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = persona.Telefono;
            miComando.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = persona.Direccion;

            try
            {
                conexion = miConexion.getConnection();

                miComando.CommandText = "update PERSONAS set nombre = @nombre, apellidos = @apellidos, fechaNac = @fechaNac, telefono = @telefono, direccion = @direccion where IDPersona = @id";
                miComando.Connection = conexion;
                resultado = miComando.ExecuteNonQuery();

                return resultado;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
                miConexion.closeConnection(ref conexion);
            }
        }
    }
}
