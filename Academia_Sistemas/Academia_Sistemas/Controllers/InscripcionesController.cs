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
    [RoutePrefix("api/Inscripciones")]
    public class InscripcionesController : ApiController
    {

        [HttpGet]
        [Route("Consultar")]
        public Inscripcione Consultar(int IdInscripcione)
        {
            clsInscripciones clsInscripcione = new clsInscripciones();
            return clsInscripcione.Consultar(IdInscripcione); ;
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar(Inscripcione Inscripcione)
        {
            clsInscripciones clsInscripcione = new clsInscripciones();
            clsInscripcione.inscripcione = Inscripcione;
            return clsInscripcione.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar(Inscripcione Inscripcione)
        {
            clsInscripciones clsInscripcione = new clsInscripciones();
            clsInscripcione.inscripcione = Inscripcione;
            return clsInscripcione.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int idInscripcione)
        {
            clsInscripciones clsInscripcione = new clsInscripciones();
            return clsInscripcione.Borrar(idInscripcione);
        }
    }
}