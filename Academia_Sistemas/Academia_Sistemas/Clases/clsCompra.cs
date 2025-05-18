using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Academia_Sistemas.Models;

namespace Academia_Sistemas.Clases
{
    public class clsCompra
    {
        private Academia_SistemasEntities dbCompra = new Academia_SistemasEntities();
        public Compra compra { get; set; }

        public string Insertar()
        {
            try
            {
                dbCompra.Compras.Add(compra);
                dbCompra.SaveChanges();
                return "Compra insertada correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar la compra: " + ex.Message;
            }
        }

        public Compra Consultar(int IdCompra)
        {
            try
            {
                Compra co = dbCompra.Compras.Where(e => e.IdCompra == compra.IdCompra).FirstOrDefault();
                return co;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar compra: " + ex.Message);
            }
        }

        public string Actualizar()
        {
            Compra co = Consultar(compra.IdCompra);
            if (co == null)
            {
                return "Compra no existe";
            }
            dbCompra.Compras.AddOrUpdate(compra);
            dbCompra.SaveChanges();
            return "Compra actualizada correctamente";
        }

        public string Borrar()
        {
            Compra co = Consultar(compra.IdCompra);
            if (co == null)
            {
                return "Compra no existe";
            }
            dbCompra.Compras.Remove(co);
            dbCompra.SaveChanges();
            return "Compra eliminada correctamente";
        }
    }
}