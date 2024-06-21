using Datos.DTO;
using Newtonsoft.Json.Linq;
using System;

namespace Datos.Entidades
{
    public class JugadorCampeonato
    {
        public int idJugador { get; set; }
        public Nullable<int> idEstadistica { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int edad { get; set; }
        public Nullable<int> numero_camiseta { get; set; }
        public string posicion { get; set; }
        public string foto_url { get; set; }
        public JugadorCampeonato() { }
        public JugadorCampeonato(string Json)
        {
            JObject data = JObject.Parse(Json);
            idJugador = (int)data["idJugador"];
            idEstadistica = data["idEstadistica"] != null ? (int?)data["idEstadistica"] : null;
            nombre = (string)data["nombre"];
            apellido = (string)data["apellido"];
            edad = (int)data["edad"];
            numero_camiseta = data["numero_camiseta"] != null ? (int?)data["numero_camiseta"] : null;
            posicion = (string)data["posicion"];
            foto_url = (string)data["foto_url"];
        }
        public JugadorCampeonato(JugadorDTO jugador)
        {
            this.idJugador = jugador.Id;
            this.nombre = ObtenerNombre(jugador.Nombre); // Asignar solo el nombre al campo nombre
            this.apellido = ObtenerApellido(jugador.Nombre); // Asignar solo el apellido al campo apellido
            this.posicion = jugador.Posicion;
            this.edad = jugador.Edad;
            this.foto_url = jugador.foto;
            this.numero_camiseta = 69;
            this.idEstadistica = 1;
        }

        // Método para obtener el nombre del jugador
        private string ObtenerNombre(string nombreCompleto)
        {
            if (!string.IsNullOrWhiteSpace(nombreCompleto))
            {
                string[] partes = nombreCompleto.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (partes.Length > 0)
                {
                    return partes[0]; // Primer elemento es el nombre
                }
            }
            return string.Empty; // Devolver cadena vacía si no se puede obtener el nombre
        }

        // Método para obtener el apellido del jugador
        private string ObtenerApellido(string nombreCompleto)
        {
            if (!string.IsNullOrWhiteSpace(nombreCompleto))
            {
                string[] partes = nombreCompleto.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (partes.Length > 1)
                {
                    return partes[partes.Length - 1]; // Último elemento es el apellido
                }
            }
            return string.Empty; // Devolver cadena vacía si no se puede obtener el apellido
        }
    }
}
