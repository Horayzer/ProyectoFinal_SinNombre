using AccessData;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class LogicPartido
    {
        DataPartido data;

        public LogicPartido()
        {
            data = new DataPartido();
        }

        public List<Partido> Listar()
        {
            List<Partido> list = data.Listar();
            return list;
        }

        public Partido ListarByID(int id)
        {
            Partido item = data.ByID(id);
            return item;
        }

        public bool Añadir(Partido item)
        {
            return data.Insertar(item);
        }

        public bool Actualizar(Partido item)
        {
            return data.Actualizar(item);
        }

        public bool Eliminar(Partido item)
        {
            return data.Eliminar(item);
        }
    }
}
