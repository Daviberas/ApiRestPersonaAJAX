using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BL;
using ENT;
using BL.Manejadora;

namespace PruebaApiREST.Controllers
{
    [Route("api/[controller]")]
    public class PersonaController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<clsPersona> Get()
        {
            IEnumerable<clsPersona> lista = new clsListadosBL().getListadoPersonasBL();
            return lista;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            clsPersona persona;
            persona = new clsManejadoraPersonaBL().obtenerPersonaBL(id);
            if(persona!=null)
                return new ObjectResult(persona);
            else
                return NotFound();
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]clsPersona value)
        {
            int i = new clsManejadoraPersonaBL().insertarPersonaBL(value);
            if (i > 0)
                return NoContent();
            else
                return Forbid();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]clsPersona value)
        {
            clsManejadoraPersonaBL mane = new clsManejadoraPersonaBL();
            if (mane.obtenerPersonaBL(id) != null)
            {
                value.Id = id;
                mane.actualizarPersonaBL(value);
                return NoContent();
            }
            else
                return NotFound();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            int i = new clsManejadoraPersonaBL().borrarPersonaBL(id);
            if (i > 0)
            {
                return NoContent();
            }
            else
                return NotFound();
        }
    }
}
