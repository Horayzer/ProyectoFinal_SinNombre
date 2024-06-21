using Datos.DTO;
using Newtonsoft.Json.Linq;
using System;

namespace Datos.Entidades
{
    public class EntrenadorFutbol
    {
        public int entrenador_id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string nacionalidad { get; set; }
        public string foto { get; set; }
        public DateTime fecha_contratacion { get; set; }
        public int division_id { get; set; }

        public EntrenadorFutbol() { }
        public EntrenadorFutbol(string json)
        {
            JObject data = JObject.Parse(json);
            entrenador_id = (int)data["entrenador_id"];
            nombre = (string)data["nombre"];
            apellido = (string)data["apellido"];
            nacionalidad = (string)data["nacionalidad"];
            foto = (string)data["foto"];
            fecha_contratacion = (DateTime)data["fecha_contratacion"];
            division_id = (int)data["division_id"];
        }
        public EntrenadorFutbol(EntrenadorDTO entrenador)
        {
            this.entrenador_id = entrenador.Id;
            this.nombre = ObtenerNombre(entrenador.Nombre);
            this.apellido = ObtenerApellido(entrenador.Nombre);
            this.nacionalidad = entrenador.Nacionalidad;
            this.foto = entrenador.Foto;
            this.fecha_contratacion = DateTime.Today;
            this.division_id = 1;
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
