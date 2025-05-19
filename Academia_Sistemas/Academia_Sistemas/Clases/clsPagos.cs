using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Academia_Sistemas.Models;

namespace Academia_Sistemas.Clases
{
    public class clsPagos
    {
        private Academia_SistemasEntities dbPagos = new Academia_SistemasEntities();
        public Pago pago { get; set; }

        public string Insertar()
        {
            try
            {
                dbPagos.Pagos.Add(pago);
                dbPagos.SaveChanges();
                return "Pago insertado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar el pago: " + ex.Message;
            }
        }

        public Pago Consultar(int IdCPago)
        {
            try
            {
                Pago pa = dbPagos.Pagos.Where(e => e.IdCPago == IdCPago).FirstOrDefault();
                return pa;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar pago: " + ex.Message);
            }
        }

        public string Actualizar()
        {
            Pago pa = Consultar(pago.IdCPago);
            if (pa == null)
            {
                return "Pago no existe";
            }
            dbPagos.Pagos.AddOrUpdate(pago);
            dbPagos.SaveChanges();
            return "Pago actualizado correctamente";
        }

        public string Borrar()
        {
            Pago pa = Consultar(pago.IdCPago);
            if (pa == null)
            {
                return "Pago no existe";
            }
            dbPagos.Pagos.Remove(pa);
            dbPagos.SaveChanges();
            return "Pago eliminado correctamente";
        }
    }
}