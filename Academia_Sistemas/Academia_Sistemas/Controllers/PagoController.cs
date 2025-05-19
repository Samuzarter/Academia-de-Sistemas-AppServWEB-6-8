using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Academia_Sistemas.Clases;
using Academia_Sistemas.Models;
using System.Web.Http;

namespace Academia_Sistemas.Controllers
{
    [RoutePrefix("api/Pago")]
    [Authorize]
    public class PagoController : ApiController
    {

        [HttpGet]
        [Route("Consultar")]
        public Pago Consultar(int IdPago)
        {
            clsPago clsPago = new clsPago();
            return clsPago.Consultar(IdPago); ;
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar(Pago pago)
        {
            clsPago clsPago = new clsPago();
            clsPago.pago = pago;
            return clsPago.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar(Pago pago)
        {
            clsPago clsPago = new clsPago();
            clsPago.pago = pago;
            return clsPago.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int idpago)
        {
            clsPago clsPago = new clsPago();
            return clsPago.Borrar(idpago);
        }
    }
}