using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Academia_Sistemas.Models;

namespace Academia_Sistemas.Clases
{
    public class clsInventarioEquipos
    {
        private Academia_SistemasEntities dbInventario = new Academia_SistemasEntities();
        public InventarioEquipos inventario { get; set; }

        public string Insertar()
        {
            try
            {
                dbInventario.InventarioEquipos.Add(inventario);
                dbInventario.SaveChanges();
                return "Inventario insertada correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar el inventario: " + ex.Message;
            }
        }

        public InventarioEquipos Consultar(int IdInventarioEquipos)
        {
            try
            {
                InventarioEquipos inv = dbInventario.InventarioEquipos.Where(e => e.IdInventario == IdInventarioEquipos).FirstOrDefault();
                return inv;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar inventario: " + ex.Message);
            }
        }

        public string Actualizar()
        {
            InventarioEquipos inv = Consultar(inventario.IdInventario);
            if (inv == null)
            {
                return "Inventario no existe";
            }
            dbInventario.InventarioEquipos.AddOrUpdate(inventario);
            dbInventario.SaveChanges();
            return "Inventario actualizado correctamente";
        }

        public string Borrar(int IdInventarioEquipos)
        {
            InventarioEquipos inv = Consultar(inventario.IdInventario);
            if (inv == null)
            {
                return "Inventario no existe";
            }
            dbInventario.InventarioEquipos.Remove(inv);
            dbInventario.SaveChanges();
            return "Inventario eliminado correctamente";
        }
    }
}