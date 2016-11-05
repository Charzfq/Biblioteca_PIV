using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Biblioteca.Host.Controllers
{// todos los atributos deben estar despues de la clase
    
    public class PruebaController : ApiController
    {
        [Route("api/Prueba/Buscar/{nombre}")]// lo que esta en llaves es el parametro string nombre del get string
        [HttpGet]
        public IEnumerable<string>BuscarPorNombre(string nombre) //creando un get con string (buscar por nombre)
           
        {
            return new string[] { "nombre1", "nombre2", nombre };
        }
        // GET: api/Prueba
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Prueba/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Prueba
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Prueba/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Prueba/5
        public string Delete(int id)
        {
            return "Eliminado";
        }
    }
}
