using AccessData;
using Data;
using System.Collections.Generic;

namespace Logic
{
    public class LogicEntrenador
    {
        DataEntrenador data;

        public LogicEntrenador()
        {
            data = new DataEntrenador();
        }

        public List<Entrenador> Listar()
        {
            List<Entrenador> list = data.Listar();
            return list;
        }

        public Entrenador ListarByID(int id)
        {
            Entrenador item = data.ByID(id);
            return item;
        }

        public bool Añadir(Entrenador item)
        {
            return data.Insertar(item);
        }

        public bool Actualizar(Entrenador item)
        {
            return data.Actualizar(item);
        }

        public bool Eliminar(Entrenador item)
        {
            return data.Eliminar(item);
        }
    }
}
