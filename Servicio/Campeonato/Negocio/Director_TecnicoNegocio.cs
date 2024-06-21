using AccesoDatos;
using Datos;
using System.Collections.Generic;

namespace Negocio
{
    public class Director_TecnicoNegocio
    {
        Director_TecnicoDatos data;

        public Director_TecnicoNegocio()
        {
            data = new Director_TecnicoDatos();
        }

        public List<Director_Tecnico> Listar()
        {
            List<Director_Tecnico> list = data.Listar();
            return list;
        }

        public Director_Tecnico ListarByID(int id)
        {
            Director_Tecnico item = data.ByID(id);
            return item;
        }

        public bool Añadir(Director_Tecnico item)
        {
            return data.Insertar(item);
        }

        public bool Actualizar(Director_Tecnico item)
        {
            return data.Actualizar(item);
        }

        public bool Eliminar(Director_Tecnico item)
        {
            return data.Eliminar(item);
        }
    }
}