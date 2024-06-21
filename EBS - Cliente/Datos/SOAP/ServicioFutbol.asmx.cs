using Datos.DTO;
using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services;

namespace SOAP
{
    /// <summary>
    /// Descripción breve de ServicioFutbol
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class ServicioFutbol : System.Web.Services.WebService
    {
        /*
         JUGADORES
         */
        JugadorMiddleware jgSOAP = new JugadorMiddleware();
        //Listar
        [WebMethod]
        public List<JugadorDTO> JugadoresLista()
        {
            return jgSOAP.ListaJugadoresREST();
        }
        //ListarByNombre
        [WebMethod]
        public List<JugadorDTO> JugadoresListaByNombre(string nombre)
        {
            return jgSOAP.FindByNombre(nombre);
        }
        //Añadir
        [WebMethod]
        public string JugadoresAgregar(JugadorDTO jugador)
        {
            if (jugador != null)
            {
                return jgSOAP.AddJugador(jugador);
            }
            else
            {
                return "No se pudo insertar el jugador";
            }
        }
        //Actualizar
        [WebMethod]
        public string JugadoresActualizar(JugadorDTO jugador)
        {
            return jgSOAP.UpdateJugador(jugador);
        }
        //Eliminar
        [WebMethod]
        public string JugadoresEliminar(int idJugador, string equipo)
        {
            return jgSOAP.DeleteJugador(idJugador, equipo);
        }
        /*
         ENTRENADORES
         */
        EntrenadorMiddleware enSOAP = new EntrenadorMiddleware();
        //Listar
        [WebMethod]
        public List<EntrenadorDTO> EntrenadoresLista()
        {
            return enSOAP.ListaEntrenadoresREST();
        }
        //ListarByNombre
        [WebMethod]
        public List<EntrenadorDTO> EntrenadoresListaByNombre(string nombre)
        {
            return enSOAP.FindByNombreEntrenadores(nombre);
        }
        //Añadir
        [WebMethod]
        public string EntrenadorAgregar(EntrenadorDTO entrenador)
        {
            if (entrenador != null)
            {
                return enSOAP.AddEntrenador(entrenador);
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
            return enSOAP.UpdateEntrenador(entrenador);
        }
        //Eliminar
        [WebMethod]
        public string EntrenadoresEliminar(int idEntrenador, string equipo)
        {
            return enSOAP.DeleteEntrenador(idEntrenador, equipo);
        }


        [WebMethod]
        public List<JugadorDTO> JugadoresListaPorEquipo(string equipo)
        {
            if (string.IsNullOrEmpty(equipo))
            {
                return new List<JugadorDTO>();
            }

            var jugadores = jgSOAP.ListaJugadoresREST()
                                  .Where(j => j.Equipo.Equals(equipo, StringComparison.OrdinalIgnoreCase))
                                  .ToList();

            // Depuración: imprimir jugadores encontrados
            System.Diagnostics.Debug.WriteLine($"Jugadores encontrados para el equipo {equipo}: {jugadores.Count}");
            foreach (var jugador in jugadores)
            {
                System.Diagnostics.Debug.WriteLine($"Nombre: {jugador.Nombre}, Posición: {jugador.Posicion}, Edad: {jugador.Edad}");
            }

            return jugadores;
        }


        [WebMethod]
        public List<string> ListarEquipos()
        {
            return jgSOAP.ListaJugadoresREST()
                         .Select(j => j.Equipo)
                         .Distinct()
                         .ToList();
        }





        [WebMethod]
        public JugadorDTO ObtenerJugadorPorId(int idJugador)
        {
            // Aquí deberías implementar la lógica para buscar el jugador por su ID
            // Puedes implementar esta lógica utilizando el middleware existente o directamente con tu lógica de datos

            // Ejemplo básico (ajusta según tu implementación real):
            return jgSOAP.ObtenerJugadorPorId(idJugador);
        }
    }
}
