using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Academia_Sistemas.Models;

namespace Academia_Sistemas.Clases
{
    public class clsCursos
    {
        private Academia_SistemasEntities dbCursos = new Academia_SistemasEntities();
        public Curso curso { get; set; }

        public string Insertar()
        {
            try
            {
                dbCursos.Cursos.Add(curso);
                dbCursos.SaveChanges();
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
                Curso cu = dbCursos.Cursos.Where(e => e.IdCurso == IdCurso).FirstOrDefault();
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
            dbCursos.Cursos.AddOrUpdate(curso);
            dbCursos.SaveChanges();
            return "Curso actualizado correctamente";
        }

        public string Borrar(int IdCurso)
        {
            Curso cu = Consultar(curso.IdCurso);
            if (cu == null)
            {
                return "Curso no existe";
            }
            dbCursos.Cursos.Remove(cu);
            dbCursos.SaveChanges();
            return "Curso eliminado correctamente";
        }
    }
}