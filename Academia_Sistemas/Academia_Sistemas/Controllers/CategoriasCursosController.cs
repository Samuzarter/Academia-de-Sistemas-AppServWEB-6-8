using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Academia_Sistemas.Clases;
using Academia_Sistemas.Models;
using System.Web.Http;

namespace Academia_Sistemas.Controllers
{
    [RoutePrefix("api/CategoriasCurso")]
    public class CategoriasCursoController : ApiController
    {

        [HttpGet]
        [Route("Consultar")]
        public CategoriasCurso Consultar(int IdCategoriasCurso)
        {
            clsCategoriasCursos clsCategoriasCurso = new clsCategoriasCursos();
            return clsCategoriasCurso.Consultar(IdCategoriasCurso); ;
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar(CategoriasCurso CategoriasCurso)
        {
            clsCategoriasCursos clsCategoriasCurso = new clsCategoriasCursos();
            clsCategoriasCurso.categoriasCurso = CategoriasCurso;
            return clsCategoriasCurso.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar(CategoriasCurso CategoriasCurso)
        {
            clsCategoriasCursos clsCategoriasCurso = new clsCategoriasCursos();
            clsCategoriasCurso.categoriasCurso = CategoriasCurso;
            return clsCategoriasCurso.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int idCategoriasCurso)
        {
            clsCategoriasCursos clsCategoriasCurso = new clsCategoriasCursos();
            return clsCategoriasCurso.Borrar();
        }
    }
}