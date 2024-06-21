using AccessData;
using Logic;
using System.Web.Http;

namespace REST.Controllers
{
    public class JugadorController : ApiController
    {
        LogicJugador logic = new LogicJugador();

        //Get
        public IHttpActionResult Get()
        {
            var respuesta = logic.Listar();
            return Ok(respuesta);
        }

        //Get/id
        public IHttpActionResult Get(int id)
        {
            Jugador respuesta = logic.ListarByID(id);
            if (respuesta != null)
            {
                return Ok(respuesta);
            }
            return NotFound();
        }

        // POST
        public IHttpActionResult Post([FromBody] Jugador item)
        {
            if (logic.Añadir(item))
            {
                return CreatedAtRoute("DefaultApi", new { id = item.ID_Jugador }, item);
            }
            else
            {
                return InternalServerError();
            }
        }

        // PUT/id
        public IHttpActionResult Put(int id, [FromBody] Jugador item)
        {
            item.ID_Jugador = id;
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
            Jugador item = logic.ListarByID(id);
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
