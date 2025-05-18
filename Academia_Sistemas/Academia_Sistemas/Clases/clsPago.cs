using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Academia_Sistemas.Models;

namespace Academia_Sistemas.Clases
{
    public class clsPago
    {
        private Academia_SistemasEntities dbPago = new Academia_SistemasEntities();
        public Pago pago { get; set; }

        public string Insertar()
        {
            try
            {
                dbPago.Pagos.Add(pago);
                dbPago.SaveChanges();
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
                Pago pa = dbPago.Pagos.Where(e => e.IdCPago == pago.IdCPago).FirstOrDefault();
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
            dbPago.Pagos.AddOrUpdate(pago);
            dbPago.SaveChanges();
            return "Pago actualizado correctamente";
        }

        public string Borrar()
        {
            Pago pa = Consultar(pago.IdCPago);
            if (pa == null)
            {
                return "Pago no existe";
            }
            dbPago.Pagos.Remove(pa);
            dbPago.SaveChanges();
            return "Pago eliminado correctamente";
        }
    }
}