using AccesoDatos;
using Negocio;
using System.Web.Http;

namespace REST.Controllers
{
    public class DirectorTecnicoController : ApiController
    {
        Director_TecnicoNegocio logic = new Director_TecnicoNegocio();

        //Get
        public IHttpActionResult Get()
        {
            var respuesta = logic.Listar();
            return Ok(respuesta);
        }

        //Get/id
        public IHttpActionResult Get(int id)
        {
            Director_Tecnico respuesta = logic.ListarByID(id);
            if (respuesta != null)
            {
                return Ok(respuesta);
            }
            return NotFound();
        }

        // POST
        public IHttpActionResult Post([FromBody] Director_Tecnico item)
        {
            if (logic.Añadir(item))
            {
                return CreatedAtRoute("DefaultApi", new { id = item.id_Director }, item);
            }
            else
            {
                return InternalServerError();
            }
        }

        // PUT/id
        public IHttpActionResult Put(int id, [FromBody] Director_Tecnico item)
        {
            item.id_Director = id;
            if (logic.Actualizar(item))
            {
                return Ok();
            }
            else
            {
                return InternalServerError();
            }
        }

        // DELETE/id
        public IHttpActionResult Delete(int id)
        {
            Director_Tecnico item = logic.ListarByID(id);
            if (item != null)
            {
                if (logic.Eliminar(item))
                {
                    return Ok();
                }
                else
                {
                    return InternalServerError();
                }
            }
            else
            {
                return NotFound();
            }
        }
    }
}