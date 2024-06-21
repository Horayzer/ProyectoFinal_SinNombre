using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IData<T>
    {
        List<T> Listar();
        T ByID(int id);
        bool Insertar(T item);
        bool Actualizar(T item);
        bool Eliminar(T item);
    }
}
