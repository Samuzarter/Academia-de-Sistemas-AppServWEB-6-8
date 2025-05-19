using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Academia_Sistemas.Clases;
using Academia_Sistemas.Models;
using System.Web.Http;

namespace Academia_Sistemas.Controllers
{
    [RoutePrefix("api/ProgramacionesCursos")]
    public class ProgramacionesCursoController : ApiController
    {

        [HttpGet]
        [Route("Consultar")]
        public ProgramacionesCurso Consultar(int IdProgramacionesCurso)
        {
            clsProgramacionesCursos clsProgramacionesCurso = new clsProgramacionesCursos();
            return clsProgramacionesCurso.Consultar(IdProgramacionesCurso); ;
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar(ProgramacionesCurso ProgramacionesCurso)
        {
            clsProgramacionesCursos clsProgramacionesCurso = new clsProgramacionesCursos();
            clsProgramacionesCurso.procurso = ProgramacionesCurso;
            return clsProgramacionesCurso.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar(ProgramacionesCurso ProgramacionesCurso)
        {
            clsProgramacionesCursos clsProgramacionesCurso = new clsProgramacionesCursos();
            clsProgramacionesCurso.procurso = ProgramacionesCurso;
            return clsProgramacionesCurso.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int idProgramacionesCurso)
        {
            clsProgramacionesCursos clsProgramacionesCurso = new clsProgramacionesCursos();
            return clsProgramacionesCurso.Borrar();
        }
    }
}