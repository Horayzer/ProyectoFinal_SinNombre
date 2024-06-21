using Datos.DTO;
using Newtonsoft.Json.Linq;
using System;

namespace Datos.Entidades
{
    public class EntrenadorCampeonato
    {
        public int id_Director { get; set; }
        public Nullable<int> id_Categoria { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string nacionalidad { get; set; }
        public Nullable<int> titulosGanados { get; set; }
        public Nullable<int> victorias { get; set; }
        public Nullable<int> derrotas { get; set; }
        public Nullable<int> empates { get; set; }
        public string foto_url { get; set; }

        public EntrenadorCampeonato() { }
        public EntrenadorCampeonato(string Json)
        {
            JObject data = JObject.Parse(Json);
            id_Director = (int)data["id_Director"];
            id_Categoria = data["id_Categoria"] != null ? (int?)data["id_Categoria"] : null;
            nombre = (string)data["nombre"];
            apellido = (string)data["apellido"];
            nacionalidad = (string)data["nacionalidad"];
            titulosGanados = data["titulosGanados"] != null ? (int?)data["titulosGanados"] : null;
            victorias = data["victorias"] != null ? (int?)data["victorias"] : null;
            derrotas = data["derrotas"] != null ? (int?)data["derrotas"] : null;
            empates = data["empates"] != null ? (int?)data["empates"] : null;
            foto_url = (string)data["foto_url"];
        }
        public EntrenadorCampeonato(EntrenadorDTO entrenador)
        {
            this.id_Director = entrenador.Id;
            this.id_Categoria = 41;
            this.nombre = ObtenerNombre(entrenador.Nombre);
            this.apellido = ObtenerApellido(entrenador.Nombre);
            this.nacionalidad = entrenador.Nacionalidad;
            this.titulosGanados = 1;
            this.victorias = 1;
            this.derrotas = 1;
            this.empates = 1;
            this.foto_url = entrenador.Foto;
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