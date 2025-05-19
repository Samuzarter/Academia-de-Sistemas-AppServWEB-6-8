using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Academia_Sistemas.Models;

namespace Academia_Sistemas.Clases
{
    public class clsCategoriasCurso
    {
        private Academia_SistemasEntities dbCatCurso = new Academia_SistemasEntities();
        public CategoriasCurso categoriasCurso { get; set; }

        public string Insertar()
        {
            try
            {
                dbCatCurso.CategoriasCursos.Add(categoriasCurso);
                dbCatCurso.SaveChanges();
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
                CategoriasCurso cat = dbCatCurso.CategoriasCursos.Where(e => e.IdCategoria == categoriasCurso.IdCategoria).FirstOrDefault();
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
            dbCatCurso.CategoriasCursos.AddOrUpdate(categoriasCurso);
            dbCatCurso.SaveChanges();
            return "Categoria actualizada correctamente";
        }

        public string Borrar(int IdCategoria)
        {
            CategoriasCurso cat = Consultar(categoriasCurso.IdCategoria);
            if (cat == null)
            {
                return "Categoria no existe";
            }
            dbCatCurso.CategoriasCursos.Remove(cat);
            dbCatCurso.SaveChanges();
            return "Categoria eliminada correctamente";
        }
    }
}