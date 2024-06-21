using AccessData;
using Data;
using System.Collections.Generic;

namespace Logic
{
    public class LogicPatrocinador
    {
        DataPatrocinador data;

        public LogicPatrocinador()
        {
            data = new DataPatrocinador();
        }

        public List<Patrocinador> Listar()
        {
            List<Patrocinador> list = data.Listar();
            return list;
        }

        public Patrocinador ListarByID(int id)
        {
            Patrocinador item = data.ByID(id);
            return item;
        }

        public bool Añadir(Patrocinador item)
        {
            return data.Insertar(item);
        }

        public bool Actualizar(Patrocinador item)
        {
            return data.Actualizar(item);
        }

        public bool Eliminar(Patrocinador item)
        {
            return data.Eliminar(item);
        }
    }
}
