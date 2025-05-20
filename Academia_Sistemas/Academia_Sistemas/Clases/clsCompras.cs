using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Academia_Sistemas.Models;

namespace Academia_Sistemas.Clases
{
    public class clsCompras
    {
        private Academia_SistemasEntities dbCompras = new Academia_SistemasEntities();
        public Compra compra { get; set; }

        public string Insertar()
        {
            try
            {
                dbCompras.Compras.Add(compra);
                dbCompras.SaveChanges();
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
                Compra co = dbCompras.Compras.Where(e => e.IdCompra == IdCompra).FirstOrDefault();
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
            dbCompras.Compras.AddOrUpdate(compra);
            dbCompras.SaveChanges();
            return "Compra actualizada correctamente";
        }

        public string Borrar(int IdCompra)
        {
            Compra co = Consultar(compra.IdCompra);
            if (co == null)
            {
                return "Compra no existe";
            }
            dbCompras.Compras.Remove(co);
            dbCompras.SaveChanges();
            return "Compra eliminada correctamente";
        }
    }
}