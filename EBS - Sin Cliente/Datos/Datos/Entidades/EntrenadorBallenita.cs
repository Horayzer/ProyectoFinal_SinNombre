using Datos.DTO;
using Newtonsoft.Json.Linq;
using System;

namespace Datos.Entidades
{
    public class EntrenadorBallenita
    {
        public int ID_Entrenador { get; set; }
        public string Nombre_Entrenador { get; set; }
        public string Nacionalidad { get; set; }
        public Nullable<int> ID_Categoria { get; set; }
        public string Foto_Entrenador_URL { get; set; }
        public EntrenadorBallenita() { }
        public EntrenadorBallenita(string Json)
        {
            JObject data = JObject.Parse(Json);
            ID_Entrenador = (int)data["ID_Entrenador"];
            Nombre_Entrenador = (string)data["Nombre_Entrenador"];
            Nacionalidad = (string)data["Nacionalidad"];
            ID_Categoria = data["ID_Categoria"] != null ? (int?)data["ID_Categoria"] : null;
            Foto_Entrenador_URL = (string)data["Foto_Entrenador_URL"];
        }
        public EntrenadorBallenita(EntrenadorDTO entrenador)
        {
            this.ID_Entrenador = entrenador.Id;
            this.Nombre_Entrenador = entrenador.Nombre;
            this.Nacionalidad = entrenador.Nacionalidad;
            this.ID_Categoria = 1;
            this.Foto_Entrenador_URL = entrenador.Foto;
        }
    }
}

