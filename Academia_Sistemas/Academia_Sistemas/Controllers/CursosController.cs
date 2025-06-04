using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Academia_Sistemas.Clases;
using Academia_Sistemas.Models;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Academia_Sistemas.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Cursos")]
    public class CursosController : ApiController
    {

        [HttpGet]
        [Route("Consultar")]
        public Curso Consultar(int IdCurso)
        {
            clsCursos clsCurso = new clsCursos();
            return clsCurso.Consultar(IdCurso); ;
        }

        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Curso> ConsultarTodos()
        {
            clsCursos clsCurso = new clsCursos();
            return clsCurso.ConsultarTodos();
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
            return clsCurso.Borrar(idCurso);
        }
    }
}