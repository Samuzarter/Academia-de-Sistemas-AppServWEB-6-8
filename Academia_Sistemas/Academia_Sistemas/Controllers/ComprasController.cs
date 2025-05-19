using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Academia_Sistemas.Clases;
using Academia_Sistemas.Models;
using System.Web.Http;

namespace Academia_Sistemas.Controllers
{
    [RoutePrefix("api/Compras")]
    public class CompraController : ApiController
    {

        [HttpGet]
        [Route("Consultar")]
        public Compra Consultar(int IdCompra)
        {
            clsCompras clsCompra = new clsCompras();
            return clsCompra.Consultar(IdCompra); ;
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar(Compra Compra)
        {
            clsCompras clsCompra = new clsCompras();
            clsCompra.compra = Compra;
            return clsCompra.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar(Compra Compra)
        {
            clsCompras clsCompra = new clsCompras();
            clsCompra.compra = Compra;
            return clsCompra.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int idCompra)
        {
            clsCompras clsCompra = new clsCompras();
            return clsCompra.Borrar();
        }
    }
}