using AccessData;
using Data;
using System.Collections.Generic;

namespace Logic
{
    public class LogicJugador
    {
        DataJugador data;

        public LogicJugador()
        {
            data = new DataJugador();
        }

        public List<Jugador> Listar()
        {
            List<Jugador> list = data.Listar();
            return list;
        }

        public Jugador ListarByID(int id)
        {
            Jugador item = data.ByID(id);
            return item;
        }

        public bool Añadir(Jugador item)
        {
            return data.Insertar(item);
        }

        public bool Actualizar(Jugador item)
        {
            return data.Actualizar(item);
        }

        public bool Eliminar(Jugador item)
        {
            return data.Eliminar(item);
        }
    }
}
