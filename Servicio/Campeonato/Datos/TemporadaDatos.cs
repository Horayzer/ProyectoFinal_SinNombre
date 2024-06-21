using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class TemporadaDatos : IData<Temporada>
    {
        CampeonatoEntities contexto;

        public TemporadaDatos()
        {
            contexto = new CampeonatoEntities();
        }

        public bool Actualizar(Temporada item)
        {
            if (contexto.Temporada.Any(p => p.idTemporada == item.idTemporada))
            {
                contexto.Entry(item).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
                return true;
            }
            return false;
        }

        public Temporada ByID(int id)
        {
            return contexto.Temporada.FirstOrDefault(p => p.idTemporada == id);
        }

        public bool Eliminar(Temporada item)
        {
            var cat = contexto.Temporada.FirstOrDefault(p => p.idTemporada == item.idTemporada);
            if (cat != null)
            {
                contexto.Temporada.Remove(cat);
                contexto.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Insertar(Temporada Temporada)
        {
            if (contexto.Temporada.Add(Temporada) != null)
            {
                contexto.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Temporada> Listar()
        {
            return contexto.Temporada.ToList();
        }
    }
}