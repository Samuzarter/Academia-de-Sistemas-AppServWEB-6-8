using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Academia_Sistemas.Clases;
using Academia_Sistemas.Models;
using System.Web.Http;

namespace Academia_Sistemas.Controllers
{
    [RoutePrefix("api/Equipos")]
    public class EquiposController : ApiController
    {

        [HttpGet]
        [Route("Consultar")]
        public Equipos Consultar(int IdEquipo)
        {
            clsEquipos clsEquipo = new clsEquipos();
            return clsEquipo.Consultar(IdEquipo); ;
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar(Equipos Equipo)
        {
            clsEquipos clsEquipo = new clsEquipos();
            clsEquipo.equipo = Equipo;
            return clsEquipo.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar(Equipos Equipo)
        {
            clsEquipos clsEquipo = new clsEquipos();
            clsEquipo.equipo = Equipo;
            return clsEquipo.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int idEquipo)
        {
            clsEquipos clsEquipo = new clsEquipos();
            return clsEquipo.Borrar(idEquipo);
        }
    }
}