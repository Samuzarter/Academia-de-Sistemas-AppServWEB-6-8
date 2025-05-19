using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Academia_Sistemas.Models;

namespace Academia_Sistemas.Clases
{
    public class clsCalificacione
    {
        private Academia_SistemasEntities dbCalificacione = new Academia_SistemasEntities();
        public Calificacione calificacione { get; set; }

        public string Insertar()
        {
            try
            {
                dbCalificacione.Calificaciones.Add(calificacione);
                dbCalificacione.SaveChanges();
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
                Calificacione ca = dbCalificacione.Calificaciones.Where(e => e.IdCalificacion == calificacione.IdCalificacion).FirstOrDefault();
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
            dbCalificacione.Calificaciones.AddOrUpdate(calificacione);
            dbCalificacione.SaveChanges();
            return "Calificacion actualizada correctamente";
        }

        public string Borrar(int IdCalificacion)
        {
            Calificacione ca = Consultar(calificacione.IdCalificacion);
            if (ca == null)
            {
                return "Calificacion no existe";
            }
            dbCalificacione.Calificaciones.Remove(ca);
            dbCalificacione.SaveChanges();
            return "Calificacion eliminada correctamente";
        }
    }
}