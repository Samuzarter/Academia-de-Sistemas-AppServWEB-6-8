using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Academia_Sistemas.Models;
using Academia_Sistemas.Clases;

namespace Academia_Sistemas.Controllers
{
    [RoutePrefix("api/Sedes")]
    public class SedesController : ApiController
    {

        [HttpGet]
        [Route("Consultar")]
        public Sede Consultar(int IdSede)
        {
            clsSedes clsSede = new clsSedes();
            return clsSede.Consultar(IdSede); ;
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar(Sede sede)
        {
            clsSedes clsSede = new clsSedes();
            clsSede.sede = sede;
            return clsSede.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar(Sede sede)
        {
            clsSedes clsSede = new clsSedes();
            clsSede.sede = sede;
            return clsSede.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int idsede)
        {
            clsSedes clsSede = new clsSedes();
            return clsSede.Borrar();
        }
    }
}