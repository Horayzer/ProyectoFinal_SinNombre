using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Director_TecnicoDatos : IData<Director_Tecnico>
    {
        CampeonatoEntities contexto;

        public Director_TecnicoDatos()
        {
            contexto = new CampeonatoEntities();
        }

        public bool Actualizar(Director_Tecnico item)
        {
            if (contexto.Director_Tecnico.Any(p => p.id_Director == item.id_Director))
            {
                contexto.Entry(item).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
                return true;
            }
            return false;
        }

        public Director_Tecnico ByID(int id)
        {
            return contexto.Director_Tecnico.FirstOrDefault(p => p.id_Director == id);
        }

        public bool Eliminar(Director_Tecnico item)
        {
            var cat = contexto.Director_Tecnico.FirstOrDefault(p => p.id_Director == item.id_Director);
            if (cat != null)
            {
                contexto.Director_Tecnico.Remove(cat);
                contexto.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Insertar(Director_Tecnico Director_Tecnico)
        {
            if (contexto.Director_Tecnico.Add(Director_Tecnico) != null)
            {
                contexto.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Director_Tecnico> Listar()
        {
            return contexto.Director_Tecnico.ToList();
        }
    }
}
