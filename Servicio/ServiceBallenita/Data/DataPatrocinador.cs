using AccessData;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    public class DataPatrocinador : IData<Patrocinador>
    {
        ballenitaEntities contexto;

        public DataPatrocinador()
        {
            contexto = new ballenitaEntities();
        }

        public bool Actualizar(Patrocinador item)
        {
            if (contexto.Patrocinador.Any(p => p.ID_Patrocinador == item.ID_Patrocinador))
            {
                contexto.Entry(item).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
                return true;
            }
            return false;
        }

        public Patrocinador ByID(int id)
        {
            return contexto.Patrocinador.FirstOrDefault(p => p.ID_Patrocinador == id);
        }

        public bool Eliminar(Patrocinador item)
        {
            var cat = contexto.Patrocinador.FirstOrDefault(p => p.ID_Patrocinador == item.ID_Patrocinador);
            if (cat != null)
            {
                contexto.Patrocinador.Remove(cat);
                contexto.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Insertar(Patrocinador Patrocinador)
        {
            if (contexto.Patrocinador.Add(Patrocinador) != null)
            {
                contexto.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Patrocinador> Listar()
        {
            return contexto.Patrocinador.ToList();
        }
    }
}
