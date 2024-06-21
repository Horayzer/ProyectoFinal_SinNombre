using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class EstadisticaDatos : IData<Estadistica>
    {
        CampeonatoEntities contexto;

        public EstadisticaDatos()
        {
            contexto = new CampeonatoEntities();
        }

        public bool Actualizar(Estadistica item)
        {
            if (contexto.Estadistica.Any(p => p.idEstadistica == item.idEstadistica))
            {
                contexto.Entry(item).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
                return true;
            }
            return false;
        }

        public Estadistica ByID(int id)
        {
            return contexto.Estadistica.FirstOrDefault(p => p.idEstadistica == id);
        }

        public bool Eliminar(Estadistica item)
        {
            var cat = contexto.Estadistica.FirstOrDefault(p => p.idEstadistica == item.idEstadistica);
            if (cat != null)
            {
                contexto.Estadistica.Remove(cat);
                contexto.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Insertar(Estadistica Estadistica)
        {
            if (contexto.Estadistica.Add(Estadistica) != null)
            {
                contexto.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Estadistica> Listar()
        {
            return contexto.Estadistica.ToList();
        }
    }
}