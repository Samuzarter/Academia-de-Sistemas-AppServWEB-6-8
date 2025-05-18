using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Academia_Sistemas.Models;

namespace Academia_Sistemas.Clases
{
    public class clsEstudiante
    {
        private Academia_SistemasEntities dbEstudiante = new Academia_SistemasEntities();
        public Estudiante estudiante { get; set; }

        public string Insertar()
        {
            try
            {
                dbEstudiante.Estudiantes.Add(estudiante);
                dbEstudiante.SaveChanges();
                return "Estudiante insertado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar el estudiante: " + ex.Message;
            }
        }

        public Estudiante Consultar(int IdEstudiante)
        {
            try
            {
                Estudiante es = dbEstudiante.Estudiantes.Where(e => e.IdEstudiante == estudiante.IdEstudiante).FirstOrDefault();
                return es;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar estudiante: " + ex.Message);
            }
        }

        public string Actualizar()
        {
            Estudiante es = Consultar(estudiante.IdEstudiante);
            if (es == null)
            {
                return "Estudiante no existe";
            }
            dbEstudiante.Estudiantes.AddOrUpdate(estudiante);
            dbEstudiante.SaveChanges();
            return "Estudiante actualizado correctamente";
        }

        public string Borrar()
        {
            Estudiante es = Consultar(estudiante.IdEstudiante);
            if (es == null)
            {
                return "Estudiante no existe";
            }
            dbEstudiante.Estudiantes.Remove(es);
            dbEstudiante.SaveChanges();
            return "Estudiante eliminado correctamente";
        }
    }
}