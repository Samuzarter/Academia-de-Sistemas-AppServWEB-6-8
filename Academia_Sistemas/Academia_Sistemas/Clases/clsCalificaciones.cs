using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Academia_Sistemas.Models;

namespace Academia_Sistemas.Clases
{
    public class clsCalificaciones
    {
        private Academia_SistemasEntities dbCalificaciones = new Academia_SistemasEntities();
        public Calificacione calificacione { get; set; }

        public string Insertar()
        {
            try
            {
                dbCalificaciones.Calificaciones.Add(calificacione);
                dbCalificaciones.SaveChanges();
                return "Calificacion insertada correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar la calificacion: " + ex.Message;
            }
        }

        public Calificacione Consultar(int IdCalificacion)
        {
            try
            {
                Calificacione ca = dbCalificaciones.Calificaciones.Where(e => e.IdCalificacion == IdCalificacion).FirstOrDefault();
                return ca;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar calificacion: " + ex.Message);
            }
        }

        public string Actualizar()
        {
            Calificacione ca = Consultar(calificacione.IdCalificacion);
            if (ca == null)
            {
                return "Calificacion no existe";
            }
            dbCalificaciones.Calificaciones.AddOrUpdate(calificacione);
            dbCalificaciones.SaveChanges();
            return "Calificacion actualizada correctamente";
        }

        public string Borrar()
        {
            Calificacione ca = Consultar(calificacione.IdCalificacion);
            if (ca == null)
            {
                return "Calificacion no existe";
            }
            dbCalificaciones.Calificaciones.Remove(ca);
            dbCalificaciones.SaveChanges();
            return "Calificacion eliminada correctamente";
        }
    }
}