using Datos.DTO;
using Datos.Entidades;
using Logica;
using System.Collections.Generic;
using System.Web.Services;

namespace SOAP
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class ServicioEntrenadores : System.Web.Services.WebService
    {
        EntrenadorMiddleware mdSOAP = new EntrenadorMiddleware();
        //Listar
        [WebMethod]
        public List<EntrenadorDTO> EntrenadoresLista()
        {
            return mdSOAP.ListaEntrenadoresREST();
        }
        //ListarByNombre
        [WebMethod]
        public List<EntrenadorDTO> EntrenadoresListaByNombre(string nombre)
        {
            return mdSOAP.FindByNombreEntrenadores(nombre);
        }
        //Añadir
        [WebMethod]
        public string EntrenadorAgregar(EntrenadorDTO entrenador)
        {
            if (entrenador != null)
            {
                return mdSOAP.AddEntrenador(entrenador);
            }
            else
            {
                return "No se pudo insertar el entrenador";
            }
        }
        //Actualizar
        [WebMethod]
        public string EntrenadoresActualizar(EntrenadorDTO entrenador)
        {
            return mdSOAP.UpdateEntrenador(entrenador);
        }
        //Eliminar
        [WebMethod]
        public string EntrenadoresEliminar(int idEntrenador, string equipo)
        {
            return mdSOAP.DeleteEntrenador(idEntrenador, equipo);
        }

    }
}

