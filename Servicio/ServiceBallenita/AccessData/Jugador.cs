//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AccessData
{
    using System;
    using System.Collections.Generic;
    
    public partial class Jugador
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Jugador()
        {
            this.JugadorPartido = new List<JugadorPartido>();
        }
    
        public int ID_Jugador { get; set; }
        public string Nombre_Jugador { get; set; }
        public string Posicion { get; set; }
        public Nullable<System.DateTime> Fecha_Nacimiento { get; set; }
        public string Nacionalidad { get; set; }
        public Nullable<int> ID_Categoria { get; set; }
        public string Foto_Jugador_URL { get; set; }
    
        public virtual CategoriaEquipo CategoriaEquipo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<JugadorPartido> JugadorPartido { get; set; }
    }
}
