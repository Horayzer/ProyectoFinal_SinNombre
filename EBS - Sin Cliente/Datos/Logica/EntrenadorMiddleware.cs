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
    public class EntrenadorMiddleware
    {
        string urlBallenita = "http://localhost:61219/api/entrenador"; //Ballenita
        string urlCampeonato = "http://localhost:64340/api/DirectorTecnico"; //Campeonato
        string urlFutbol = "http://localhost:3000/api/entrenadores"; //Futbol

        //Listar
            // Listado de entrenadores de la base de datos ventas REST
        public List<EntrenadorBallenita> ListarEntrenadoresBallenita()
        {
            WebClient respuesta = new WebClient();
            string get = respuesta.DownloadString(new Uri(urlBallenita));
            List<EntrenadorBallenita> listaBallenita = JsonConvert.DeserializeObject<List<EntrenadorBallenita>>(get);
            return listaBallenita;
        }
        public List<EntrenadorCampeonato> ListarEntrenadoresCampeonato()
        {
            WebClient respuesta = new WebClient();
            string get = respuesta.DownloadString(new Uri(urlCampeonato));
            List<EntrenadorCampeonato> listaCampeonato = JsonConvert.DeserializeObject<List<EntrenadorCampeonato>>(get);
            return listaCampeonato;
        }
        public List<EntrenadorFutbol> ListarEntrenadoresFutbol()
        {
            WebClient respuesta = new WebClient();
            string get = respuesta.DownloadString(new Uri(urlFutbol));
            List<EntrenadorFutbol> listaFutbol = JsonConvert.DeserializeObject<List<EntrenadorFutbol>>(get);
            return listaFutbol;
        }
        public List<EntrenadorDTO> ListaEntrenadoresREST()
        {
            List<EntrenadorDTO> listaEntrenadores = new List<EntrenadorDTO>();
            foreach (var item in ListarEntrenadoresBallenita())
            {
                EntrenadorDTO entrenador = new EntrenadorDTO();
                entrenador.Id = item.ID_Entrenador;
                entrenador.Nombre = item.Nombre_Entrenador;
                entrenador.Nacionalidad = item.Nacionalidad;
                entrenador.Foto = item.Foto_Entrenador_URL;
                entrenador.Equipo = "Ballenita";
                listaEntrenadores.Add(entrenador);
            }
            foreach (var item in ListarEntrenadoresCampeonato())
            {
                EntrenadorDTO entrenador = new EntrenadorDTO();
                entrenador.Id = item.id_Director;
                entrenador.Nombre = item.nombre + item.apellido;
                entrenador.Nacionalidad = item.nacionalidad;
                entrenador.Foto = item.foto_url;
                entrenador.Equipo = "Campeonato";
                listaEntrenadores.Add(entrenador);
            }
            foreach (var item in ListarEntrenadoresFutbol())
            {
                EntrenadorDTO entrenador = new EntrenadorDTO();
                entrenador.Id = item.entrenador_id;
                entrenador.Nombre = item.nombre + " " + item.apellido;
                entrenador.Nacionalidad = item.nacionalidad;
                entrenador.Foto = item.foto;
                entrenador.Equipo = "Futbol";
                listaEntrenadores.Add(entrenador);
            }
            return listaEntrenadores;
        }
        //ListarByNombre
        public List<EntrenadorDTO> FindByNombreEntrenadores(string nombre)
        {
            List<EntrenadorDTO> listaEntrenadores = ListaEntrenadoresREST()
                                                .Where(p => p.Nombre.Contains(nombre))
                                                .ToList();
            return listaEntrenadores;
        }

        //Añadir
            // enviar los datos para insertar a través de Ballenita
        private bool AddEntrenadoresBallenita(EntrenadorBallenita entrenador)
        {
            string verb = "POST";
            WebClient webClient = new WebClient();
            string JsonDatos = JsonConvert.SerializeObject(entrenador);
            UTF8Encoding uTF = new UTF8Encoding();
            Byte[] bytes = uTF.GetBytes(JsonDatos);
            webClient.Headers.Add("content-type", "application/json");
            if (webClient.UploadData(urlBallenita, verb, bytes) != null)
                return true;
            return false;
        }
            // enviar los datos para insertar a través de Campeonato
        private bool AddEntrenadoresCampeonato(EntrenadorCampeonato entrenador)
        {
            string verb = "POST";
            WebClient webClient = new WebClient();
            string JsonDatos = JsonConvert.SerializeObject(entrenador);
            UTF8Encoding uTF = new UTF8Encoding();
            Byte[] bytes = uTF.GetBytes(JsonDatos);
            webClient.Headers.Add("content-type", "application/json");
            if (webClient.UploadData(urlCampeonato, verb, bytes) != null)
                return true;
            return false;
        }
        // enviar los datos para insertar a través de Futbol
        private bool AddEntrenadoresFutbol(EntrenadorFutbol entrenador)
        {
            string verb = "POST";
            WebClient webClient = new WebClient();
            string JsonDatos = JsonConvert.SerializeObject(entrenador);
            UTF8Encoding uTF = new UTF8Encoding();
            Byte[] bytes = uTF.GetBytes(JsonDatos);
            webClient.Headers.Add("content-type", "application/json");
            if (webClient.UploadData(urlFutbol, verb, bytes) != null)
                return true;
            return false;
        }
        public string AddEntrenador(EntrenadorDTO entrenador)
        {
            if (entrenador != null)
            {
                if (entrenador.Equipo.CompareTo("Ballenita") == 0)
                {
                    EntrenadorBallenita entrenadorB = new EntrenadorBallenita(entrenador);

                    AddEntrenadoresBallenita(entrenadorB);
                    return "insertado Ballena";
                }
                if (entrenador.Equipo.CompareTo("Campeonato") == 0)
                {
                    EntrenadorCampeonato entrenadorC = new EntrenadorCampeonato(entrenador);

                    AddEntrenadoresCampeonato(entrenadorC);
                    return "insertado Campeonato";
                }
                if (entrenador.Equipo.CompareTo("Futbol") == 0)
                {
                    EntrenadorFutbol jugadorF = new EntrenadorFutbol(entrenador);

                    AddEntrenadoresFutbol(jugadorF);
                    return "insertado Futbol";
                }
            }
            return "error en la definicion de la tienda";
        }
        //Actualizar
            // Método para actualizar entrenadores en Ballenita
        private bool UpdateEntrenadoresBallenita(EntrenadorBallenita entrenador)
        {
            string verb = "PUT";
            WebClient webClient = new WebClient();
            string JsonDatos = JsonConvert.SerializeObject(entrenador);
            UTF8Encoding uTF = new UTF8Encoding();
            Byte[] bytes = uTF.GetBytes(JsonDatos);
            webClient.Headers.Add("content-type", "application/json");
            if (webClient.UploadData($"{urlBallenita}/{entrenador.ID_Entrenador}", verb, bytes) != null)
                return true;
            return false;
        }

            // Método para actualizar entrenadores en Campeonato
        private bool UpdateEntrenadoresCampeonato(EntrenadorCampeonato entrenador)
        {
            string verb = "PUT";
            WebClient webClient = new WebClient();
            string JsonDatos = JsonConvert.SerializeObject(entrenador);
            UTF8Encoding uTF = new UTF8Encoding();
            Byte[] bytes = uTF.GetBytes(JsonDatos);
            webClient.Headers.Add("content-type", "application/json");
            if (webClient.UploadData($"{urlCampeonato}/{entrenador.id_Director}", verb, bytes) != null)
                return true;
            return false;
        }

            // Método para actualizar entrenadores en Futbol
        private bool UpdateEntrenadoresFutbol(EntrenadorFutbol entrenador)
        {
            string verb = "PUT";
            WebClient webClient = new WebClient();
            string JsonDatos = JsonConvert.SerializeObject(entrenador);
            UTF8Encoding uTF = new UTF8Encoding();
            Byte[] bytes = uTF.GetBytes(JsonDatos);
            webClient.Headers.Add("content-type", "application/json");
            if (webClient.UploadData($"{urlFutbol}/{entrenador.entrenador_id}", verb, bytes) != null)
                return true;
            return false;
        }

        public string UpdateEntrenador(EntrenadorDTO entrenador)
        {
            if (entrenador != null)
            {
                if (entrenador.Equipo.CompareTo("Ballenita") == 0)
                {
                    EntrenadorBallenita entrenadorB = new EntrenadorBallenita(entrenador);

                    UpdateEntrenadoresBallenita(entrenadorB);
                    return "actualizado Ballena";
                }
                if (entrenador.Equipo.CompareTo("Campeonato") == 0)
                {
                    EntrenadorCampeonato entrenadorC = new EntrenadorCampeonato(entrenador);

                    UpdateEntrenadoresCampeonato(entrenadorC);
                    return "actualizado Campeonato";
                }
                if (entrenador.Equipo.CompareTo("Futbol") == 0)
                {
                    EntrenadorFutbol entrenadorF = new EntrenadorFutbol(entrenador);

                    UpdateEntrenadoresFutbol(entrenadorF);
                    return "actualizado Futbol";
                }
            }
            return "error en la definicion de la tienda";
        }

        //Eliminar
            // Método para eliminar entrenadores en Ballenita
        private bool DeleteEntrenadoresBallenita(int idEntrenador)
        {
            string verb = "DELETE";
            WebClient webClient = new WebClient();
            if (webClient.UploadString($"{urlBallenita}/{idEntrenador}", verb, "") != null)
                return true;
            return false;
        }

            // Método para eliminar entrenadores en Campeonato
        private bool DeleteEntrenadoresCampeonato(int idEntrenador)
        {
            string verb = "DELETE";
            WebClient webClient = new WebClient();
            if (webClient.UploadString($"{urlCampeonato}/{idEntrenador}", verb, "") != null)
                return true;
            return false;
        }

            // Método para eliminar entrenadores en Futbol
        private bool DeleteEntrenadoresFutbol(int idEntrenador)
        {
            string verb = "DELETE";
            WebClient webClient = new WebClient();
            if (webClient.UploadString($"{urlFutbol}/{idEntrenador}", verb, "") != null)
                return true;
            return false;
        }

        public string DeleteEntrenador(int idEntrenador, string equipo)
        {
            if (idEntrenador > 0)
            {
                if (equipo.CompareTo("Ballenita") == 0)
                {
                    DeleteEntrenadoresBallenita(idEntrenador);
                    return "eliminado Ballena";
                }
                if (equipo.CompareTo("Campeonato") == 0)
                {
                    DeleteEntrenadoresCampeonato(idEntrenador);
                    return "eliminado Campeonato";
                }
                if (equipo.CompareTo("Futbol") == 0)
                {
                    DeleteEntrenadoresFutbol(idEntrenador);
                    return "eliminado Futbol";
                }
            }
            return "error en la definicion de la tienda";
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
    }
}