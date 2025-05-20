using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Academia_Sistemas.Models;

namespace Academia_Sistemas.Clases
{
    public class clsEstudiantes
    {
        private Academia_SistemasEntities dbEstudiantes = new Academia_SistemasEntities();
        public Estudiante estudiante { get; set; }

        public string Insertar()
        {
            try
            {
                dbEstudiantes.Estudiantes.Add(estudiante);
                dbEstudiantes.SaveChanges();
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
                Estudiante es = dbEstudiantes.Estudiantes.Where(e => e.IdEstudiante == IdEstudiante).FirstOrDefault();
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
            dbEstudiantes.Estudiantes.AddOrUpdate(estudiante);
            dbEstudiantes.SaveChanges();
            return "Estudiante actualizado correctamente";
        }

        public string Borrar(int IdEstudiante)
        {
            Estudiante es = Consultar(estudiante.IdEstudiante);
            if (es == null)
            {
                return "Estudiante no existe";
            }
            dbEstudiantes.Estudiantes.Remove(es);
            dbEstudiantes.SaveChanges();
            return "Estudiante eliminado correctamente";
        }
    }
}