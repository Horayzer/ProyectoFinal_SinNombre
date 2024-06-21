using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class CategoriasDatos : IData<Categorias>
    {
        CampeonatoEntities contexto;

        public CategoriasDatos()
        {
            contexto = new CampeonatoEntities();
        }

        public bool Actualizar(Categorias item)
        {
            if (contexto.Categorias.Any(p => p.idCategoria == item.idCategoria))
            {
                contexto.Entry(item).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
                return true;
            }
            return false;
        }

        public Categorias ByID(int id)
        {
            return contexto.Categorias.FirstOrDefault(p => p.idCategoria == id);
        }

        public bool Eliminar(Categorias item)
        {
            var cat = contexto.Categorias.FirstOrDefault(p => p.idCategoria == item.idCategoria);
            if (cat != null)
            {
                contexto.Categorias.Remove(cat);
                contexto.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Insertar(Categorias Categorias)
        {
            if (contexto.Categorias.Add(Categorias) != null)
            {
                contexto.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Categorias> Listar()
        {
            return contexto.Categorias.ToList();
        }
    }
}
