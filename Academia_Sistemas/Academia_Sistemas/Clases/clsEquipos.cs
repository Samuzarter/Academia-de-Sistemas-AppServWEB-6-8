using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Academia_Sistemas.Models;

namespace Academia_Sistemas.Clases
{
    public class clsEquiposs
    {
        private Academia_SistemasEntities dbEquipos = new Academia_SistemasEntities();
        public Equipos equipo { get; set; }

        public string Insertar()
        {
            try
            {
                dbEquipos.Equipos.Add(equipo);
                dbEquipos.SaveChanges();
                return "Equipo insertado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar el equipo: " + ex.Message;
            }
        }

        public Equipos Consultar(int IdEquipo)
        {
            try
            {
                Equipos eq = dbEquipos.Equipos.Where(e => e.IdEquipo == equipo.IdEquipo).FirstOrDefault();
                return eq;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar equipo: " + ex.Message);
            }
        }

        public string Actualizar()
        {
            Equipos eq = Consultar(equipo.IdEquipo);
            if (eq == null)
            {
                return "Equipo no existe";
            }
            dbEquipos.Equipos.AddOrUpdate(equipo);
            dbEquipos.SaveChanges();
            return "Equipo actualizado correctamente";
        }

        public string Borrar(int IdEquipo)
        {
            Equipos eq = Consultar(equipo.IdEquipo);
            if (eq == null)
            {
                return "Equipo no existe";
            }
            dbEquipos.Equipos.Remove(eq);
            dbEquipos.SaveChanges();
            return "Equipo eliminado correctamente";
        }
    }
}