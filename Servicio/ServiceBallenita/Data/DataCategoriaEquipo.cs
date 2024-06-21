using AccessData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DataCategoriaEquipo : IData<CategoriaEquipo>
    {
        ballenitaEntities contexto;

        public DataCategoriaEquipo()
        {
            contexto = new ballenitaEntities();
        }

        public bool Actualizar(CategoriaEquipo item)
        {
            if (contexto.CategoriaEquipo.Any(p => p.ID_Categoria == item.ID_Categoria))
            {
                contexto.Entry(item).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
                return true;
            }
            return false;
        }

        public CategoriaEquipo ByID(int id)
        {
            return contexto.CategoriaEquipo.FirstOrDefault(p => p.ID_Categoria == id);
        }

        public bool Eliminar(CategoriaEquipo item)
        {
            var cat = contexto.CategoriaEquipo.FirstOrDefault(p => p.ID_Categoria == item.ID_Categoria);
            if (cat != null)
            {
                contexto.CategoriaEquipo.Remove(cat);
                contexto.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Insertar(CategoriaEquipo CategoriaEquipo)
        {
            if (contexto.CategoriaEquipo.Add(CategoriaEquipo) != null)
            {
                contexto.SaveChanges();
                return true;
            }
            return false;
        }

        public List<CategoriaEquipo> Listar()
        {
            return contexto.CategoriaEquipo.ToList();
        }
    }
}
