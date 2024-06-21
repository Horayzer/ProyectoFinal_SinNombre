using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Info_EquipoDatos : IData<Info_Equipo>
    {
        CampeonatoEntities contexto;

        public Info_EquipoDatos()
        {
            contexto = new CampeonatoEntities();
        }

        public bool Actualizar(Info_Equipo item)
        {
            if (contexto.Info_Equipo.Any(p => p.idEquipo == item.idEquipo))
            {
                contexto.Entry(item).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
                return true;
            }
            return false;
        }

        public Info_Equipo ByID(int id)
        {
            return contexto.Info_Equipo.FirstOrDefault(p => p.idEquipo == id);
        }

        public bool Eliminar(Info_Equipo item)
        {
            var cat = contexto.Info_Equipo.FirstOrDefault(p => p.idEquipo == item.idEquipo);
            if (cat != null)
            {
                contexto.Info_Equipo.Remove(cat);
                contexto.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Insertar(Info_Equipo Info_Equipo)
        {
            if (contexto.Info_Equipo.Add(Info_Equipo) != null)
            {
                contexto.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Info_Equipo> Listar()
        {
            return contexto.Info_Equipo.ToList();
        }
    }
}