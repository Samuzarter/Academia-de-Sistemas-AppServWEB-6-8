using System;
using System.Data.Entity.Migrations;
using System.Linq;
using Academia_Sistemas.Models;

namespace Academia_Sistemas.Clases
{
    public class clsSede
    {

        private Academia_SistemasEntities dbSede = new Academia_SistemasEntities();
        public Sede sede { get; set; }

        public string Insertar()
        {
            try
            {
                dbSede.Sedes.Add(sede);
                dbSede.SaveChanges();
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
                Sede se = dbSede.Sedes.Where(e => e.IdSede == sede.IdSede).FirstOrDefault();
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
            dbSede.Sedes.AddOrUpdate(sede);
            dbSede.SaveChanges();
            return "Sede actualizada correctamente";
        }

        public string Borrar(int Id_Sede)
        {
            Sede se = Consultar(Id_Sede);
            if (se == null)
            {
                return "Sede inexistente";
            }
            dbSede.Sedes.Remove(se);
            dbSede.SaveChanges();
            return "Eliminacion exitosa";
        }

    }
}