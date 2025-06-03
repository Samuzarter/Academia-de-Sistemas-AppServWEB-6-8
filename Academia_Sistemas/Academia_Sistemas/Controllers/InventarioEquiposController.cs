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
    [RoutePrefix("api/InventarioEquipos")]
    public class InventarioEquiposController : ApiController
    {

        [HttpGet]
        [Route("Consultar")]
        public InventarioEquipos Consultar(int IdInventarioEquipo)
        {
            clsInventarioEquipos clsInventarioEquipo = new clsInventarioEquipos();
            return clsInventarioEquipo.Consultar(IdInventarioEquipo); ;
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar(InventarioEquipos InventarioEquipo)
        {
            clsInventarioEquipos clsInventarioEquipo = new clsInventarioEquipos();
            clsInventarioEquipo.inventario = InventarioEquipo;
            return clsInventarioEquipo.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar(InventarioEquipos InventarioEquipo)
        {
            clsInventarioEquipos clsInventarioEquipo = new clsInventarioEquipos();
            clsInventarioEquipo.inventario = InventarioEquipo;
            return clsInventarioEquipo.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int idInventarioEquipo)
        {
            clsInventarioEquipos clsInventarioEquipo = new clsInventarioEquipos();
            return clsInventarioEquipo.Borrar(idInventarioEquipo);
        }
    }
}