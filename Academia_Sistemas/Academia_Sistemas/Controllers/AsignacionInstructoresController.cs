using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Academia_Sistemas.Models;
using Academia_Sistemas.Clases;

namespace Academia_Sistemas.Controllers
{
    [RoutePrefix("api/AsignacionInstructores")]
    public class AsignacionInstructoresController : ApiController
    {

        [HttpGet]
        [Route("Consultar")]
        public AsignacionInstructore Consultar(int IdAsignacionInstructore)
        {
            clsAsignacionInstructores clsAsignacionInstructore = new clsAsignacionInstructores();
            return clsAsignacionInstructore.Consultar(IdAsignacionInstructore); ;
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar(AsignacionInstructore AsignacionInstructore)
        {
            clsAsignacionInstructores clsAsignacionInstructore = new clsAsignacionInstructores();
            clsAsignacionInstructore.asignacionInstructore = AsignacionInstructore;
            return clsAsignacionInstructore.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar(AsignacionInstructore AsignacionInstructore)
        {
            clsAsignacionInstructores clsAsignacionInstructore = new clsAsignacionInstructores();
            clsAsignacionInstructore.asignacionInstructore = AsignacionInstructore;
            return clsAsignacionInstructore.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int idAsignacionInstructore)
        {
            clsAsignacionInstructores clsAsignacionInstructore = new clsAsignacionInstructores();
            return clsAsignacionInstructore.Borrar();
        }
    }
}