using AccessData;
using Logic;
using System.Web.Http;

namespace REST.Controllers
{
    public class EntrenadorController : ApiController
    {
        LogicEntrenador logic = new LogicEntrenador();

        //Get
        public IHttpActionResult Get()
        {
            var respuesta = logic.Listar();
            return Ok(respuesta);
        }

        //Get/id
        public IHttpActionResult Get(int id)
        {
            Entrenador respuesta = logic.ListarByID(id);
            if (respuesta != null)
            {
                return Ok(respuesta);
            }
            return NotFound();
        }

        // POST
        public IHttpActionResult Post([FromBody] Entrenador item)
        {
            if (logic.Añadir(item))
            {
                return CreatedAtRoute("DefaultApi", new { id = item.ID_Entrenador }, item);
            }
            else
            {
                return InternalServerError();
            }
        }

        // PUT/id
        public IHttpActionResult Put(int id, [FromBody] Entrenador item)
        {
            item.ID_Entrenador = id;
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
            Entrenador item = logic.ListarByID(id);
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
