using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Academia_Sistemas.Models;
using Academia_Sistemas.Clases;

namespace Academia_Sistemas.Controllers
{
    [RoutePrefix("api/Sede")]
    [Authorize]
    public class SedeController : ApiController
    {

        [HttpGet]
        [Route("Consultar")]
        public Sede Consultar(int IdSede)
        {
            clsSede clsSede = new clsSede();
            return clsSede.Consultar(IdSede); ;
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar(Sede sede)
        {
            clsSede clsSede = new clsSede();
            clsSede.sede = sede;
            return clsSede.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar(Sede sede)
        {
            clsSede clsSede = new clsSede();
            clsSede.sede = sede;
            return clsSede.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int idsede)
        {
            clsSede clsSede = new clsSede();
            return clsSede.Borrar(idsede);
        }
    }
}