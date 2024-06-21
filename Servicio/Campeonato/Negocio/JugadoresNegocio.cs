using AccesoDatos;
using Datos;
using System.Collections.Generic;

namespace Negocio
{
    public class JugadoresesNegocio
    {
        JugadoresDatos data;

        public JugadoresesNegocio()
        {
            data = new JugadoresDatos();
        }

        public List<Jugadores> Listar()
        {
            List<Jugadores> list = data.Listar();
            return list;
        }

        public Jugadores ListarByID(int id)
        {
            Jugadores item = data.ByID(id);
            return item;
        }

        public bool Añadir(Jugadores item)
        {
            return data.Insertar(item);
        }

        public bool Actualizar(Jugadores item)
        {
            return data.Actualizar(item);
        }

        public bool Eliminar(Jugadores item)
        {
            return data.Eliminar(item);
        }
    }
}
