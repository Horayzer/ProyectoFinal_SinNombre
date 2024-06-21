using AccessData;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SOAP
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    public class ServiceJugador : System.Web.Services.WebService
    {
        private LogicJugador logic = new LogicJugador();

        [WebMethod]
        public List<Jugador> Listar()
        {
            return logic.Listar();
        }

        [WebMethod]
        public Jugador BuscarxID(int id)
        {
            Jugador temp = logic.ListarByID(id);
            if (temp != null)
            {
                return temp;
            }
            return null;
        }

        [WebMethod]
        public bool Añadir(Jugador item)
        {
            return logic.Añadir(item);
        }

        [WebMethod]
        public bool Actualizar(Jugador item)
        {
            return logic.Actualizar(item);
        }

        [WebMethod]
        public bool Eliminar(Jugador item)
        {
            return logic.Eliminar(item);
        }
    }
}
