using AccessData;
using Data;
using System.Collections.Generic;

namespace Logic
{
    public class LogicJugadorPartido
    {
        DataJugadorPartido data;

        public LogicJugadorPartido()
        {
            data = new DataJugadorPartido();
        }

        public List<JugadorPartido> Listar()
        {
            List<JugadorPartido> list = data.Listar();
            return list;
        }

        public JugadorPartido ListarByID(int id, int id2)
        {
            JugadorPartido item = data.ByID(id,id2);
            return item;
        }

        public bool Añadir(JugadorPartido item)
        {
            return data.Insertar(item);
        }

        public bool Actualizar(JugadorPartido item)
        {
            return data.Actualizar(item);
        }

        public bool Eliminar(JugadorPartido item)
        {
            return data.Eliminar(item);
        }
    }
}
