using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Academia_Sistemas.Clases;
using Academia_Sistemas.Models;
using System.Web.Http;

namespace Academia_Sistemas.Controllers
{
    [RoutePrefix("api/Cursos")]
    public class CursoController : ApiController
    {

        [HttpGet]
        [Route("Consultar")]
        public Curso Consultar(int IdCurso)
        {
            clsCursos clsCurso = new clsCursos();
            return clsCurso.Consultar(IdCurso); ;
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar(Curso Curso)
        {
            clsCursos clsCurso = new clsCursos();
            clsCurso.curso = Curso;
            return clsCurso.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar(Curso Curso)
        {
            clsCursos clsCurso = new clsCursos();
            clsCurso.curso = Curso;
            return clsCurso.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int idCurso)
        {
            clsCursos clsCurso = new clsCursos();
            return clsCurso.Borrar();
        }
    }
}