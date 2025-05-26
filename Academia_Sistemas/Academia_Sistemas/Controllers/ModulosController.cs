using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Academia_Sistemas.Clases;
using Academia_Sistemas.Models;
using System.Web.Http;

namespace Academia_Sistemas.Controllers
{
    [RoutePrefix("api/Modulos")]
    public class ModulosController : ApiController
    {

        [HttpGet]
        [Route("Consultar")]
        public Modulo Consultar(int IdModulo)
        {
            clsModulos clsModulo = new clsModulos();
            return clsModulo.Consultar(IdModulo); ;
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar(Modulo Modulo)
        {
            clsModulos clsModulo = new clsModulos();
            clsModulo.modulo = Modulo;
            return clsModulo.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar(Modulo Modulo)
        {
            clsModulos clsModulo = new clsModulos();
            clsModulo.modulo = Modulo;
            return clsModulo.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int idModulo)
        {
            clsModulos clsModulo = new clsModulos();
            return clsModulo.Borrar(idModulo);
        }
    }
}