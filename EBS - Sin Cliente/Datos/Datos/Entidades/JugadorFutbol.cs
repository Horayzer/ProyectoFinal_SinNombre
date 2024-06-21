using Datos.DTO;
using Newtonsoft.Json.Linq;
using System;

namespace Datos.Entidades
{
    public class JugadorFutbol
    {
        public int jugador_id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int edad { get; set; }
        public string posicion { get; set; }
        public int division_id { get; set; }
        public string nacionalidad { get; set; }
        public string foto { get; set; }

        public JugadorFutbol() { }

        public JugadorFutbol(string json)
        {
            JObject data = JObject.Parse(json);
            jugador_id = (int)data["jugador_id"];
            nombre = (string)data["nombre"];
            apellido = (string)data["apellido"];
            edad = (int)data["edad"];
            posicion = (string)data["posicion"];
            division_id = (int)data["division_id"];
            nacionalidad = (string)data["nacionalidad"];
            foto = (string)data["foto"];
        }
        public JugadorFutbol(JugadorDTO jugador)
        {
            this.jugador_id = jugador.Id;
            this.nombre = ObtenerNombre(jugador.Nombre); // Asignar solo el nombre al campo nombre
            this.apellido = ObtenerApellido(jugador.Nombre); // Asignar solo el apellido al campo apellido
            this.posicion = jugador.Posicion;
            this.edad = jugador.Edad;
            this.foto = jugador.foto;
            this.nacionalidad = "Ecuatoriana";
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
