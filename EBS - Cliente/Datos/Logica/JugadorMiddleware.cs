using Datos.DTO;
using Datos.Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Logica
{
    public class JugadorMiddleware
    {
        string urlFutbol = "http://localhost:3000/api/jugadores"; //Futbol
        string urlBallenita = "http://localhost:61219/api/Jugador"; //Ballenita
        string urlCampeonato = "http://localhost:64340/api/Jugadores"; //Campeonato

        //Listar
            // Listado de jugadores de la base de datos ventas REST
        public List<JugadorBallenita> ListarJugadoresBallenita()
        {
            WebClient respuesta = new WebClient();
            string get = respuesta.DownloadString(new Uri(urlBallenita));
            List<JugadorBallenita> listaBallenita = JsonConvert.DeserializeObject<List<JugadorBallenita>>(get);
            return listaBallenita;
        }
        public List<JugadorCampeonato> ListarJugadoresCampeonato()
        {
            WebClient respuesta = new WebClient();
            string get = respuesta.DownloadString(new Uri(urlCampeonato));
            List<JugadorCampeonato> listaCampeonato = JsonConvert.DeserializeObject<List<JugadorCampeonato>>(get);
            return listaCampeonato;
        }
        public List<JugadorFutbol> ListarJugadoresFutbol()
        {
            WebClient respuesta = new WebClient();
            string get = respuesta.DownloadString(new Uri(urlFutbol));
            List<JugadorFutbol> listaFutbol = JsonConvert.DeserializeObject<List<JugadorFutbol>>(get);
            return listaFutbol;
        }
        public List<JugadorDTO> ListaJugadoresREST()
        {
            List<JugadorDTO> ListaJugadores = new List<JugadorDTO>();
            foreach (var item in ListarJugadoresBallenita())
            {
                JugadorDTO jugador = new JugadorDTO();
                jugador.Id = item.ID_Jugador;
                jugador.Nombre = item.Nombre_Jugador;
                jugador.Posicion = item.Posicion;
                jugador.Edad = CalculateAge(item.Fecha_Nacimiento);
                jugador.foto = item.Foto_Jugador_URL;
                jugador.Equipo = "Ballenita";
                ListaJugadores.Add(jugador);
            }
            foreach (var item in ListarJugadoresCampeonato())
            {
                JugadorDTO jugador = new JugadorDTO();
                jugador.Id = item.idJugador;
                jugador.Nombre = item.nombre + item.apellido;
                jugador.Posicion = item.posicion;
                jugador.Edad = item.edad;
                jugador.foto = item.foto_url;
                jugador.Equipo = "Campeonato";
                ListaJugadores.Add(jugador);
            }
            foreach (var item in ListarJugadoresFutbol())
            {
                JugadorDTO jugador = new JugadorDTO();
                jugador.Id = item.jugador_id;
                jugador.Nombre = item.nombre + " " + item.apellido;
                jugador.Posicion = item.posicion;
                jugador.Edad = item.edad;
                jugador.foto = item.foto;
                jugador.Equipo = "Futbol";
                ListaJugadores.Add(jugador);
            }
            return ListaJugadores;
        }
        //ListarByNombre
        public List<JugadorDTO> FindByNombre(string nombre)
        {
            List<JugadorDTO> listaJugadores = ListaJugadoresREST()
                                                .Where(p => p.Nombre.Contains(nombre))
                                                .ToList();
            return listaJugadores;
        }

        //Añadir
        // enviar los datos para insertar a través de Ballenita
        private bool AddJugadoresBallenita(JugadorBallenita jugador)
        {
            string verb = "POST";
            WebClient webClient = new WebClient();
            string JsonDatos = JsonConvert.SerializeObject(jugador);
            UTF8Encoding uTF = new UTF8Encoding();
            Byte[] bytes = uTF.GetBytes(JsonDatos);
            webClient.Headers.Add("content-type", "application/json");
            if (webClient.UploadData(urlBallenita, verb, bytes) != null)
                return true;
            return false;
        }
            // enviar los datos para insertar a través de Campeonato
        private bool AddJugadoresCampeonato(JugadorCampeonato jugador)
        {
            string verb = "POST";
            WebClient webClient = new WebClient();
            string JsonDatos = JsonConvert.SerializeObject(jugador);
            UTF8Encoding uTF = new UTF8Encoding();
            Byte[] bytes = uTF.GetBytes(JsonDatos);
            webClient.Headers.Add("content-type", "application/json");
            if (webClient.UploadData(urlCampeonato, verb, bytes) != null)
                return true;
            return false;
        }
            // enviar los datos para insertar a través de Futbol
        private bool AddJugadoresFutbol(JugadorFutbol jugador)
        {
            string verb = "POST";
            WebClient webClient = new WebClient();
            string JsonDatos = JsonConvert.SerializeObject(jugador);
            UTF8Encoding uTF = new UTF8Encoding();
            Byte[] bytes = uTF.GetBytes(JsonDatos);
            webClient.Headers.Add("content-type", "application/json");
            if (webClient.UploadData(urlFutbol, verb, bytes) != null)
                return true;
            return false;
        }
        public string AddJugador(JugadorDTO jugador)
        {
            if (jugador != null)
            {
                if (jugador.Equipo.CompareTo("Ballenita") == 0)
                {
                    JugadorBallenita jugadorBallenita = new JugadorBallenita(jugador);

                    AddJugadoresBallenita(jugadorBallenita);
                    return "insertado Ballena";
                }
                if (jugador.Equipo.CompareTo("Campeonato") == 0)
                {
                    JugadorCampeonato jugadorCampeonato = new JugadorCampeonato(jugador);

                    AddJugadoresCampeonato(jugadorCampeonato);
                    return "insertado Campeonato";
                }
                if (jugador.Equipo.CompareTo("Futbol") == 0)
                {
                    JugadorFutbol jugadorFutbol = new JugadorFutbol(jugador);

                    AddJugadoresFutbol(jugadorFutbol);
                    return "insertado Futbol";
                }
            }
            return "error en la definicion de la tienda";
        }
        //Actualizar
            // Método para actualizar jugadores en Ballenita
        private bool UpdateJugadoresBallenita(JugadorBallenita jugador)
        {
            string verb = "PUT";
            WebClient webClient = new WebClient();
            string JsonDatos = JsonConvert.SerializeObject(jugador);
            UTF8Encoding uTF = new UTF8Encoding();
            Byte[] bytes = uTF.GetBytes(JsonDatos);
            webClient.Headers.Add("content-type", "application/json");
            if (webClient.UploadData($"{urlBallenita}/{jugador.ID_Jugador}", verb, bytes) != null)
                return true;
            return false;
        }

            // Método para actualizar jugadores en Campeonato
        private bool UpdateJugadoresCampeonato(JugadorCampeonato jugador)
        {
            string verb = "PUT";
            WebClient webClient = new WebClient();
            string JsonDatos = JsonConvert.SerializeObject(jugador);
            UTF8Encoding uTF = new UTF8Encoding();
            Byte[] bytes = uTF.GetBytes(JsonDatos);
            webClient.Headers.Add("content-type", "application/json");
            if (webClient.UploadData($"{urlCampeonato}/{jugador.idJugador}", verb, bytes) != null)
                return true;
            return false;
        }

            // Método para actualizar jugadores en Futbol
        private bool UpdateJugadoresFutbol(JugadorFutbol jugador)
        {
            string verb = "PUT";
            WebClient webClient = new WebClient();
            string JsonDatos = JsonConvert.SerializeObject(jugador);
            UTF8Encoding uTF = new UTF8Encoding();
            Byte[] bytes = uTF.GetBytes(JsonDatos);
            webClient.Headers.Add("content-type", "application/json");
            if (webClient.UploadData($"{urlFutbol}/{jugador.jugador_id}", verb, bytes) != null)
                return true;
            return false;
        }

        public string UpdateJugador(JugadorDTO jugador)
        {
            if (jugador != null)
            {
                if (jugador.Equipo.CompareTo("Ballenita") == 0)
                {
                    JugadorBallenita jugadorBallenita = new JugadorBallenita(jugador);

                    UpdateJugadoresBallenita(jugadorBallenita);
                    return "actualizado Ballena";
                }
                if (jugador.Equipo.CompareTo("Campeonato") == 0)
                {
                    JugadorCampeonato jugadorCampeonato = new JugadorCampeonato(jugador);

                    UpdateJugadoresCampeonato(jugadorCampeonato);
                    return "actualizado Campeonato";
                }
                if (jugador.Equipo.CompareTo("Futbol") == 0)
                {
                    JugadorFutbol jugadorFutbol = new JugadorFutbol(jugador);

                    UpdateJugadoresFutbol(jugadorFutbol);
                    return "actualizado Futbol";
                }
            }
            return "error en la definicion de la tienda";
        }
        //Eliminar
            // Método para eliminar jugadores en Ballenita
        private bool DeleteJugadoresBallenita(int idJugador)
        {
            string verb = "DELETE";
            WebClient webClient = new WebClient();
            if (webClient.UploadString($"{urlBallenita}/{idJugador}", verb, "") != null)
                return true;
            return false;
        }

            // Método para eliminar jugadores en Campeonato
        private bool DeleteJugadoresCampeonato(int idJugador)
        {
            string verb = "DELETE";
            WebClient webClient = new WebClient();
            if (webClient.UploadString($"{urlCampeonato}/{idJugador}", verb, "") != null)
                return true;
            return false;
        }


        private bool DeleteJugadoresFutbol(int idJugador)
        {
            try
            {
                string verb = "DELETE";
                WebClient webClient = new WebClient();

                if (webClient.UploadString($"{urlFutbol}/{idJugador}", verb, "") != null)
                    return true;

                return false;
            }
            catch (WebException ex)
            {
                // Maneja la excepción de tiempo de espera u otras excepciones aquí
                Console.WriteLine($"Error en la solicitud: {ex.Message}");
                return false;
            }
        }


        public string DeleteJugador(int idJugador, string equipo)
        {
            if (idJugador <= 0)
            {
                return "ID de jugador inválido";
            }

            if (equipo == null)
            {
                return "Nombre de equipo no puede ser nulo";
            }

            switch (equipo)
            {
                case "Ballenita":
                    DeleteJugadoresBallenita(idJugador);
                    return "Eliminado Ballenita";

                case "Campeonato":
                    DeleteJugadoresCampeonato(idJugador);
                    return "Eliminado Campeonato";

                case "Futbol":
                    DeleteJugadoresFutbol(idJugador);
                    return "Eliminado Futbol";

                default:
                    return "Equipo no reconocido";
            }
        }

        //Metodos Extra
        private int CalculateAge(DateTime? birthDate)
        {
            if (!birthDate.HasValue)
                return 0;

            DateTime today = DateTime.Today;
            int age = today.Year - birthDate.Value.Year;
            if (birthDate.Value.Date > today.AddYears(-age)) age--;
            return age;
        }


        public JugadorDTO ObtenerJugadorPorId(int idJugador)
        {
            // Primero, busca el jugador por su ID en la lista general de jugadores
            JugadorDTO jugador = ListaJugadoresREST().FirstOrDefault(j => j.Id == idJugador);

            // Si no se encuentra en la lista general, puedes implementar búsquedas en los diferentes orígenes de datos (Ballenita, Campeonato, Futbol)
            if (jugador == null)
            {
                // Ejemplo de búsqueda específica en Ballenita
                var jugadorBallenita = ListarJugadoresBallenita().FirstOrDefault(j => j.ID_Jugador == idJugador);
                if (jugadorBallenita != null)
                {
                    jugador = new JugadorDTO
                    {
                        Id = jugadorBallenita.ID_Jugador,
                        Nombre = jugadorBallenita.Nombre_Jugador,
                        Posicion = jugadorBallenita.Posicion,
                        Edad = CalculateAge(jugadorBallenita.Fecha_Nacimiento),
                        foto = jugadorBallenita.Foto_Jugador_URL,
                        Equipo = "Ballenita"
                    };
                }
                // Aquí puedes agregar lógica similar para Campeonato y Futbol si es necesario
            }

            return jugador;
        }

    }
}
