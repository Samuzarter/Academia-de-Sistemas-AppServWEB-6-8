using System;
using System.Data.Entity.Migrations;
using System.Linq;
using Academia_Sistemas.Models;

namespace Academia_Sistemas.Clases
{
    public class clsSedes
    {

        private Academia_SistemasEntities dbSedes = new Academia_SistemasEntities();
        public Sede sede { get; set; }

        public string Insertar()
        {
            try
            {
                dbSedes.Sedes.Add(sede);
                dbSedes.SaveChanges();
                return "Sede insertada correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar la sede: " + ex.Message;
            }
        }

        public Sede Consultar(int IdSede)
        {
            try
            {
                Sede se = dbSedes.Sedes.Where(e => e.IdSede == IdSede).FirstOrDefault();
                return se;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar sede: " + ex.Message);
            }
        }

        public string Actualizar()
        {
            Sede se = Consultar(sede.IdSede);
            if (se == null)
            {
                return "Sede no existe";
            }
            dbSedes.Sedes.AddOrUpdate(sede);
            dbSedes.SaveChanges();
            return "Sede actualizada correctamente";
        }

        public string Borrar()
        {
            Sede se = Consultar(sede.IdSede);
            if (se == null)
            {
                return "Sede no existe";
            }
            dbSedes.Sedes.Remove(se);
            dbSedes.SaveChanges();
            return "Sede eliminada correctamente";
        }

    }
}