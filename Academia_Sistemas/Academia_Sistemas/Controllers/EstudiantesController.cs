using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Academia_Sistemas.Clases;
using Academia_Sistemas.Models;
using System.Web.Http;

namespace Academia_Sistemas.Controllers
{
    [RoutePrefix("api/Estudiantes")]
    public class EstudiantesController : ApiController
    {

        [HttpGet]
        [Route("Consultar")]
        public Estudiante Consultar(int IdEstudiante)
        {
            clsEstudiantes clsEstudiante = new clsEstudiantes();
            return clsEstudiante.Consultar(IdEstudiante); ;
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar(Estudiante Estudiante)
        {
            clsEstudiantes clsEstudiante = new clsEstudiantes();
            clsEstudiante.estudiante = Estudiante;
            return clsEstudiante.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar(Estudiante Estudiante)
        {
            clsEstudiantes clsEstudiante = new clsEstudiantes();
            clsEstudiante.estudiante = Estudiante;
            return clsEstudiante.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int idEstudiante)
        {
            clsEstudiantes clsEstudiante = new clsEstudiantes();
            return clsEstudiante.Borrar(idEstudiante);
        }
    }
}