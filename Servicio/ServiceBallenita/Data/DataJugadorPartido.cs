using AccessData;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    public class DataJugadorPartido : IData<JugadorPartido>
    {
        ballenitaEntities contexto;
        public DataJugadorPartido()
        {
            contexto = new ballenitaEntities();
        }

        public bool Actualizar(JugadorPartido item)
        {
            var existingItem = contexto.JugadorPartido
                .FirstOrDefault(p => p.ID_Jugador == item.ID_Jugador && p.ID_Partido == item.ID_Partido);

            if (existingItem != null)
            {
                contexto.Entry(existingItem).CurrentValues.SetValues(item);
                contexto.SaveChanges();
                return true;
            }
            return false;
        }

        JugadorPartido IData<JugadorPartido>.ByID(int id)
        {
            throw new NotImplementedException();
        }

        public JugadorPartido ByID(int idJugador, int idPartido)
        {
            return contexto.JugadorPartido
                .FirstOrDefault(p => p.ID_Jugador == idJugador && p.ID_Partido == idPartido);
        }

        public bool Eliminar(JugadorPartido item)
        {
            var existingItem = contexto.JugadorPartido
                .FirstOrDefault(p => p.ID_Jugador == item.ID_Jugador && p.ID_Partido == item.ID_Partido);

            if (existingItem != null)
            {
                contexto.JugadorPartido.Remove(existingItem);
                contexto.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Insertar(JugadorPartido jugadorPartido)
        {
            contexto.JugadorPartido.Add(jugadorPartido);
            contexto.SaveChanges();
            return true;
        }

        public List<JugadorPartido> Listar()
        {
            return contexto.JugadorPartido.ToList();
        }
    }
}
