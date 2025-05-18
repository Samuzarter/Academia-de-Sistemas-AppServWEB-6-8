using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Academia_Sistemas.Models;

namespace Academia_Sistemas.Clases
{
    public class clsCurso
    {
        private Academia_SistemasEntities dbCurso = new Academia_SistemasEntities();
        public Curso curso { get; set; }

        public string Insertar()
        {
            try
            {
                dbCurso.Cursos.Add(curso);
                dbCurso.SaveChanges();
                return "Curso insertado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar el curso: " + ex.Message;
            }
        }

        public Curso Consultar(int IdCurso)
        {
            try
            {
                Curso cu = dbCurso.Cursos.Where(e => e.IdCurso == curso.IdCurso).FirstOrDefault();
                return cu;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar curso: " + ex.Message);
            }
        }

        public string Actualizar()
        {
            Curso cu = Consultar(curso.IdCurso);
            if (cu == null)
            {
                return "Curso no existe";
            }
            dbCurso.Cursos.AddOrUpdate(curso);
            dbCurso.SaveChanges();
            return "Curso actualizado correctamente";
        }

        public string Borrar()
        {
            Curso cu = Consultar(curso.IdCurso);
            if (cu == null)
            {
                return "Curso no existe";
            }
            dbCurso.Cursos.Remove(cu);
            dbCurso.SaveChanges();
            return "Curso eliminado correctamente";
        }
    }
}