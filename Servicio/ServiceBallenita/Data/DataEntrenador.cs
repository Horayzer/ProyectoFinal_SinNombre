using AccessData;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    public class DataEntrenador : IData<Entrenador>
    {
        ballenitaEntities contexto;

        public DataEntrenador()
        {
            contexto = new ballenitaEntities();
        }

        public bool Actualizar(Entrenador item)
        {
            if (contexto.Entrenador.Any(p => p.ID_Entrenador == item.ID_Entrenador))
            {
                contexto.Entry(item).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
                return true;
            }
            return false;
        }

        public Entrenador ByID(int id)
        {
            return contexto.Entrenador.FirstOrDefault(p => p.ID_Entrenador == id);
        }

        public bool Eliminar(Entrenador item)
        {
            var cat = contexto.Entrenador.FirstOrDefault(p => p.ID_Entrenador == item.ID_Entrenador);
            if (cat != null)
            {
                contexto.Entrenador.Remove(cat);
                contexto.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Insertar(Entrenador Entrenador)
        {
            if (contexto.Entrenador.Add(Entrenador) != null)
            {
                contexto.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Entrenador> Listar()
        {
            return contexto.Entrenador.ToList();
        }
    }
}
