using AccessData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DataPartido : IData<Partido>
    {
        ballenitaEntities contexto;

        public DataPartido()
        {
            contexto = new ballenitaEntities();
        }

        public bool Actualizar(Partido item)
        {
            if (contexto.Partido.Any(p => p.ID_Partido == item.ID_Partido))
            {
                contexto.Entry(item).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
                return true;
            }
            return false;
        }

        public Partido ByID(int id)
        {
            return contexto.Partido.FirstOrDefault(p => p.ID_Partido == id);
        }

        public bool Eliminar(Partido item)
        {
            var cat = contexto.Partido.FirstOrDefault(p => p.ID_Partido == item.ID_Partido);
            if (cat != null)
            {
                contexto.Partido.Remove(cat);
                contexto.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Insertar(Partido Partido)
        {
            if (contexto.Partido.Add(Partido) != null)
            {
                contexto.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Partido> Listar()
        {
            return contexto.Partido.ToList();
        }
    }
}
