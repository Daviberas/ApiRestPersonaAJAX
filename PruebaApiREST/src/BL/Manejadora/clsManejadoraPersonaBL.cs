using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Manejadora;
using DAL.Manejadora;
using ENT;

namespace BL.Manejadora
{
    public class clsManejadoraPersonaBL
    {
        /// <summary>
        /// El método llama al método para obtener personas de la capa de acceso a datos.
        /// </summary>
        /// <param name="id">Tipo entero</param>
        /// <returns>Un objeto de la clase persona si se realiza la operación correctamente, en caso de error se lanzará la excepción correspondiente.</returns>

        public clsPersona obtenerPersonaBL(int id)
        {
            clsPersona i = new clsManejadoraPersonaDAL().obtenerPersonaDAL(id);

            return i;
        }

        /// <summary>
        /// El método llama al método para insertar personas de la capa de acceso a datos.
        /// </summary>
        /// <param name="persona">Tipo persona.</param>
        /// <returns>Un entero, que indica el número de filas afectadas, en caso de error se lanzará la excepción correspondiente.</returns>

        public int insertarPersonaBL(clsPersona persona)
        {
            int i = new clsManejadoraPersonaDAL().insertarPersonaDAL(persona);

            return i;
        }

        /// <summary>
        /// El método llama al método para actualizar personas de la capa de acceso a datos.
        /// </summary>
        /// <param name="persona">Tipo persona.</param>
        /// <returns>Un entero, que indica el número de filas afectadas, en caso de error se lanzará la excepción correspondiente.</returns>

        public int actualizarPersonaBL(clsPersona persona)
        {
            int i = new clsManejadoraPersonaDAL().actualizarPersonaDAL(persona);

            return i;
        }

        /// <summary>
        /// El método llama al método para borrar personas de la capa de acceso a datos.
        /// </summary>
        /// <param name="id">Tipo entero.</param>
        /// <returns>Un entero, que indica el número de filas afectadas, en caso de error se lanzará la excepción correspondiente.</returns>

        public int borrarPersonaBL(int id)
        {
            int i = new clsManejadoraPersonaDAL().borrarPersonaDAL(id);

            return i;
        }
    }
}
