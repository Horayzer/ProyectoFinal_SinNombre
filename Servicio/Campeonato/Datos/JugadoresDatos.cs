using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class JugadoresDatos : IData<Jugadores>
    {
        CampeonatoEntities contexto;

        public JugadoresDatos()
        {
            contexto = new CampeonatoEntities();
        }

        public bool Actualizar(Jugadores item)
        {
            if (contexto.Jugadores.Any(p => p.idJugador == item.idJugador))
            {
                contexto.Entry(item).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
                return true;
            }
            return false;
        }

        public Jugadores ByID(int id)
        {
            return contexto.Jugadores.FirstOrDefault(p => p.idJugador == id);
        }

        public bool Eliminar(Jugadores item)
        {
            var cat = contexto.Jugadores.FirstOrDefault(p => p.idJugador == item.idJugador);
            if (cat != null)
            {
                contexto.Jugadores.Remove(cat);
                contexto.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Insertar(Jugadores Jugadores)
        {
            if (contexto.Jugadores.Add(Jugadores) != null)
            {
                contexto.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Jugadores> Listar()
        {
            return contexto.Jugadores.ToList();
        }
    }
}
