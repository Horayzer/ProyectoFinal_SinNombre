using AccesoDatos;
using Negocio;
using System.Web.Http;

namespace REST.Controllers
{
    public class JugadoresController : ApiController
    {
        JugadoresesNegocio logic = new JugadoresesNegocio();

        //Get
        public IHttpActionResult Get()
        {
            var respuesta = logic.Listar();
            return Ok(respuesta);
        }

        //Get/id
        public IHttpActionResult Get(int id)
        {
            Jugadores respuesta = logic.ListarByID(id);
            if (respuesta != null)
            {
                return Ok(respuesta);
            }
            return NotFound();
        }

        // POST
        public IHttpActionResult Post([FromBody] Jugadores item)
        {
            if (logic.Añadir(item))
            {
                return CreatedAtRoute("DefaultApi", new { id = item.idJugador }, item);
            }
            else
            {
                return InternalServerError();
            }
        }

        // PUT/id
        public IHttpActionResult Put(int id, [FromBody] Jugadores item)
        {
            item.idJugador = id;
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
            Jugadores item = logic.ListarByID(id);
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
