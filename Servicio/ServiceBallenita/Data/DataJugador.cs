using AccessData;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    public class DataJugador : IData<Jugador>
    {
        ballenitaEntities contexto;

        public DataJugador()
        {
            contexto = new ballenitaEntities();
        }

        public bool Actualizar(Jugador item)
        {
            if (contexto.Jugador.Any(p => p.ID_Jugador == item.ID_Jugador))
            {
                contexto.Entry(item).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
                return true;
            }
            return false;
        }

        public Jugador ByID(int id)
        {
            return contexto.Jugador.FirstOrDefault(p => p.ID_Jugador == id);
        }

        public bool Eliminar(Jugador item)
        {
            var cat = contexto.Jugador.FirstOrDefault(p => p.ID_Jugador == item.ID_Jugador);
            if (cat != null)
            {
                contexto.Jugador.Remove(cat);
                contexto.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Insertar(Jugador Jugador)
        {
            if (contexto.Jugador.Add(Jugador) != null)
            {
                contexto.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Jugador> Listar()
        {
            return contexto.Jugador.ToList();
        }
    }
}
