using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Academia_Sistemas.Clases;
using Academia_Sistemas.Models;
using System.Web.Http;

namespace Academia_Sistemas.Controllers
{
    [RoutePrefix("api/Proveedores")]
    public class ProveedoresController : ApiController
    {

        [HttpGet]
        [Route("Consultar")]
        public Proveedore Consultar(int IdProveedore)
        {
            clsProveedores clsProveedore = new clsProveedores();
            return clsProveedore.Consultar(IdProveedore); ;
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar(Proveedore Proveedore)
        {
            clsProveedores clsProveedore = new clsProveedores();
            clsProveedore.proveedore = Proveedore;
            return clsProveedore.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar(Proveedore Proveedore)
        {
            clsProveedores clsProveedore = new clsProveedores();
            clsProveedore.proveedore = Proveedore;
            return clsProveedore.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int idProveedore)
        {
            clsProveedores clsProveedore = new clsProveedores();
            return clsProveedore.Borrar(idProveedore);
        }
    }
}