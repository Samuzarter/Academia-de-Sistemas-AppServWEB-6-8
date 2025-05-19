using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Academia_Sistemas.Models;

namespace Academia_Sistemas.Clases
{
    public class clsCategoriasCursos
    {
        private Academia_SistemasEntities dbCatCursos = new Academia_SistemasEntities();
        public CategoriasCurso categoriasCurso { get; set; }

        public string Insertar()
        {
            try
            {
                dbCatCursos.CategoriasCursos.Add(categoriasCurso);
                dbCatCursos.SaveChanges();
                return "Categoria insertada correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar la categoria: " + ex.Message;
            }
        }

        public CategoriasCurso Consultar(int IdCategoria)
        {
            try
            {
                CategoriasCurso cat = dbCatCursos.CategoriasCursos.Where(e => e.IdCategoria == IdCategoria).FirstOrDefault();
                return cat;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar categoria: " + ex.Message);
            }
        }

        public string Actualizar()
        {
            CategoriasCurso cat = Consultar(categoriasCurso.IdCategoria);
            if (cat == null)
            {
                return "Categoria no existe";
            }
            dbCatCursos.CategoriasCursos.AddOrUpdate(categoriasCurso);
            dbCatCursos.SaveChanges();
            return "Categoria actualizada correctamente";
        }

        public string Borrar()
        {
            CategoriasCurso cat = Consultar(categoriasCurso.IdCategoria);
            if (cat == null)
            {
                return "Categoria no existe";
            }
            dbCatCursos.CategoriasCursos.Remove(cat);
            dbCatCursos.SaveChanges();
            return "Categoria eliminada correctamente";
        }
    }
}