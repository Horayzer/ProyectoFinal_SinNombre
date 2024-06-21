using Datos.DTO;
using Logica;
using System.Collections.Generic;
using System.Web.Services;

namespace SOAP
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    public class ServicioJugadores : System.Web.Services.WebService
    {
        JugadorMiddleware mdSOAP = new JugadorMiddleware();
        //Listar
        [WebMethod]
        public List<JugadorDTO> JugadoresLista()
        {
            return mdSOAP.ListaJugadoresREST();
        }
        //ListarByNombre
        [WebMethod]
        public List<JugadorDTO> JugadoresListaByNombre(string nombre)
        {
            return mdSOAP.FindByNombre(nombre);
        }
        //Añadir
        [WebMethod]
        public string JugadoresAgregar(JugadorDTO jugador)
        {
            if (jugador != null)
            {
                return mdSOAP.AddJugador(jugador);
            } else
            {
                return "No se pudo insertar el jugador";
            }
        }
        //Actualizar
        [WebMethod]
        public string JugadoresActualizar(JugadorDTO jugador)
        {
            return mdSOAP.UpdateJugador(jugador);
        }
        //Eliminar
        [WebMethod]
        public string JugadoresEliminar(int idJugador, string equipo)
        {
            return mdSOAP.DeleteJugador(idJugador, equipo);
        }

    }
}
