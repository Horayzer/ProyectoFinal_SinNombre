using AccessData;
using Data;
using System.Collections.Generic;

namespace Logic
{
    public class LogicCategoriaEquipo
    {
        DataCategoriaEquipo data;

        public LogicCategoriaEquipo()
        {
            data = new DataCategoriaEquipo();
        }

        public List<CategoriaEquipo> Listar()
        {
            List<CategoriaEquipo> list = data.Listar();
            return list;
        }

        public CategoriaEquipo ListarByID(int id)
        {
            CategoriaEquipo item = data.ByID(id);
            return item;
        }

        public bool Añadir(CategoriaEquipo item)
        {
            return data.Insertar(item);
        }

        public bool Actualizar(CategoriaEquipo item)
        {
            return data.Actualizar(item);
        }

        public bool Eliminar(CategoriaEquipo item)
        {
            return data.Eliminar(item);
        }
    }
}
