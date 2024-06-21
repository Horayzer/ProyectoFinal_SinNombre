using AccessData;
using Logic;
using System.Web.Http;

namespace REST.Controllers
{
    public class JugadorPartidoController : ApiController
    {
        LogicJugadorPartido logic = new LogicJugadorPartido();

        //Get
        public IHttpActionResult Get()
        {
            var respuesta = logic.Listar();
            return Ok(respuesta);
        }

        //Get/id
        public IHttpActionResult Get(int id, int id2)
        {
            JugadorPartido respuesta = logic.ListarByID(id,id2);
            if (respuesta != null)
            {
                return Ok(respuesta);
            }
            return NotFound();
        }

        // POST
        public IHttpActionResult Post([FromBody] JugadorPartido item)
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
        public IHttpActionResult Put(int id, [FromBody] JugadorPartido item)
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
        public IHttpActionResult Delete(int id, int id2)
        {
            JugadorPartido item = logic.ListarByID(id, id2);
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
