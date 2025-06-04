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
    [RoutePrefix("api/Pagos")]
    public class PagosController : ApiController
    {

        [HttpGet]
        [Route("Consultar")]
        public Pago Consultar(int IdPago)
        {
            clsPagos clsPago = new clsPagos();
            return clsPago.Consultar(IdPago); ;
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar(Pago pago)
        {
            clsPagos clsPago = new clsPagos();
            clsPago.pago = pago;
            return clsPago.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar(Pago pago)
        {
            clsPagos clsPago = new clsPagos();
            clsPago.pago = pago;
            return clsPago.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int idpago)
        {
            clsPagos clsPago = new clsPagos();
            return clsPago.Borrar(idpago);
        }
    }
}