using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Academia_Sistemas.Clases;
using Academia_Sistemas.Models;
using System.Web.Http;

namespace Academia_Sistemas.Controllers
{
    [RoutePrefix("api/Instructore")]
    public class InstructoresController : ApiController
    {

        [HttpGet]
        [Route("Consultar")]
        public Instructore Consultar(int IdInstructore)
        {
            clsInstructores clsInstructore = new clsInstructores();
            return clsInstructore.Consultar(IdInstructore); ;
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar(Instructore Instructore)
        {
            clsInstructores clsInstructore = new clsInstructores();
            clsInstructore.instructore = Instructore;
            return clsInstructore.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar(Instructore Instructore)
        {
            clsInstructores clsInstructore = new clsInstructores();
            clsInstructore.instructore = Instructore;
            return clsInstructore.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int idInstructore)
        {
            clsInstructores clsInstructore = new clsInstructores();
            return clsInstructore.Borrar(idInstructore);
        }
    }
}