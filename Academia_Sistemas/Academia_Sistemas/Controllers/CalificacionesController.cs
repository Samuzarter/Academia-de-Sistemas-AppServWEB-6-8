using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Academia_Sistemas.Clases;
using Academia_Sistemas.Models;
using System.Web.Http;

namespace Academia_Sistemas.Controllers
{
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



    }
}