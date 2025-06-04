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
    [RoutePrefix("api/Calificaciones")]
    public class CalificacionesController : ApiController
    {

        [HttpGet]
        [Route("Consultar")]
        public Calificacione Consultar(int IdCalificacion)
        {
            clsCalificaciones clsCalificacion = new clsCalificaciones();
            return clsCalificacion.Consultar(IdCalificacion); ;
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar(Calificacione Calificacion)
        {
            clsCalificaciones clsCalificacion = new clsCalificaciones();
            clsCalificacion.calificacione = Calificacion;
            return clsCalificacion.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar(Calificacione Calificacion)
        {
            clsCalificaciones clsCalificacion = new clsCalificaciones();
            clsCalificacion.calificacione = Calificacion;
            return clsCalificacion.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int idCalificacion)
        {
            clsCalificaciones clsCalificacion = new clsCalificaciones();
            return clsCalificacion.Borrar(idCalificacion);
        }

        [HttpGet]
        [Route("ConsultarPorEstudiante")]
        public List<Calificacione> ConsultarPorEstudiante(int idEstudiante)
        {
            clsCalificaciones clsCalificacion = new clsCalificaciones();
            return clsCalificacion.ConsultarPorEstudiante(idEstudiante);
        }

        [HttpGet]
        [Route("ConsultarNotasPorCurso")]
        public List<decimal> ConsultarNotasPorCurso(int idEstudiante, int idCurso)
        {
            clsCalificaciones clsCalificacion = new clsCalificaciones();
            return clsCalificacion.ObtenerNotasPorEstudianteYCurso(idEstudiante, idCurso);
        }

        [HttpGet]
        [Route("ListarTodos")]
        public IHttpActionResult ListarTodos()
        {
            try
            {
                clsCalificaciones clsCalif = new clsCalificaciones();
                var calificaciones = clsCalif.ListarTodos();
                return Ok(calificaciones);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }



    }
}