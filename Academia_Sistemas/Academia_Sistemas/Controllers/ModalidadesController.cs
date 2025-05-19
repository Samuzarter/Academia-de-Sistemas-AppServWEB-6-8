using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Academia_Sistemas.Clases;
using Academia_Sistemas.Models;
using System.Web.Http;

namespace Academia_Sistemas.Controllers
{
    [RoutePrefix("api/Modalidades")]
    public class ModalidadeController : ApiController
    {

        [HttpGet]
        [Route("Consultar")]
        public Modalidade Consultar(int IdModalidade)
        {
            clsModalidades clsModalidade = new clsModalidades();
            return clsModalidade.Consultar(IdModalidade); ;
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar(Modalidade Modalidade)
        {
            clsModalidades clsModalidade = new clsModalidades();
            clsModalidade.modalidade = Modalidade;
            return clsModalidade.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar(Modalidade Modalidade)
        {
            clsModalidades clsModalidade = new clsModalidades();
            clsModalidade.modalidade = Modalidade;
            return clsModalidade.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int idModalidade)
        {
            clsModalidades clsModalidade = new clsModalidades();
            return clsModalidade.Borrar();
        }
    }
}