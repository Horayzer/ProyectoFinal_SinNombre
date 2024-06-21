using Datos.DTO;
using Newtonsoft.Json.Linq;
using System;

namespace Datos.Entidades
{
    public class JugadorBallenita
    {
        public int ID_Jugador { get; set; }
        public string Nombre_Jugador { get; set; }
        public string Posicion { get; set; }
        public Nullable<System.DateTime> Fecha_Nacimiento { get; set; }
        public string Nacionalidad { get; set; }
        public Nullable<int> ID_Categoria { get; set; }
        public string Foto_Jugador_URL { get; set; }
        public JugadorBallenita() { }
        public JugadorBallenita(string Json)
        {
            JObject data = JObject.Parse(Json);
            ID_Jugador = (int)data["ID_Jugador"];
            Nombre_Jugador = (string)data["Nombre_Jugador"];
            Posicion = (string)data["Posicion"];
            Fecha_Nacimiento = data["Fecha_Nacimiento"] != null ? (DateTime?)data["Fecha_Nacimiento"] : null;
            Nacionalidad = (string)data["Nacionalidad"];
            ID_Categoria = data["ID_Categoria"] != null ? (int?)data["ID_Categoria"] : null;
            Foto_Jugador_URL = (string)data["Foto_Jugador_URL"];
        }
        public JugadorBallenita(JugadorDTO jugador)
        {
            this.ID_Jugador = jugador.Id;
            this.Nombre_Jugador = jugador.Nombre;
            this.Posicion = jugador.Posicion;
            this.Fecha_Nacimiento = CalculateBirthDateFromAge(jugador.Edad);
            this.Foto_Jugador_URL = jugador.foto;
            this.Nacionalidad = "Ecuatoriana";
            this.ID_Categoria = 1;
        }
        private DateTime CalculateBirthDateFromAge(int age)
        {
            // Obtener la fecha actual
            DateTime today = DateTime.Today;

            // Calcular la fecha de nacimiento restando la edad en años
            DateTime birthDate = today.AddYears(-age);

            return birthDate;
        }

    }
}
