using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Biblioteca.Data; //primero incluir el namespace de data.
using Biblioteca.Data.Modelos; //Luego incluir el namespace de modelos.
using System.Web.Http.Description; //sirve para usar IHttpActionResult

namespace Biblioteca.Host.Controllers
{
    public class EditorialController : ApiController
    {
        BibliotecaContext bibliotecaContext = new BibliotecaContext("BibliotecaLocal"); //creando nuestro contexto, 

        protected override void Dispose(bool disposing)// el objeto deje de existir.
        {
            if (disposing)
            {
                bibliotecaContext.Dispose(); //se destruye el metodo bibliotecaContext 
            }
            base.Dispose(disposing);
        }


        // GET: api/Editorial
        //metodo para obtener todos los editoriales
        public IEnumerable<Editorial> Get() //Editorial es el modelo
        {
            return bibliotecaContext.Editoriales;
            
        }

        // GET: api/Editorial/5
        [ResponseType(typeof(Editorial))]// Response indica exactamente de que tipo es la respuesta que el metodo debe devolver
        public IHttpActionResult Get(int id) //define el resultado de una accion
        {
           var editorial = bibliotecaContext.Editoriales.Find(id);
            if (editorial == null)
            {
               return NotFound();
            }
            else
            {
               return Ok(editorial);
            }
        }

        // POST: api/Editorial
        public IHttpActionResult Post(Editorial nuevoEditorial)
        {
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }


            bibliotecaContext.Editoriales.Add(nuevoEditorial);
            bibliotecaContext.SaveChanges();
            return Ok(nuevoEditorial);
        }

        // PUT: api/Editorial/5
        [ResponseType(typeof(Editorial))]
        public IHttpActionResult Put(int id, Editorial editorial)
        {
            if (id != editorial.Id)
            {
               return BadRequest(ModelState);
            }

            bibliotecaContext.Entry(editorial).State = System.Data.Entity.EntityState.Modified;
            bibliotecaContext.SaveChanges();

            return Ok(editorial);
        }

        // DELETE: api/Editorial/5
        public IHttpActionResult Delete(int id)
        {
            var editorial = bibliotecaContext.Editoriales.Find(id);

            if (editorial == null)
            {
                return NotFound();
            }

            bibliotecaContext.Editoriales.Remove(editorial);
            bibliotecaContext.SaveChanges();
            return Ok();
        }
    }
}
