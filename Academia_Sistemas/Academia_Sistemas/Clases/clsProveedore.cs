using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Academia_Sistemas.Models;

namespace Academia_Sistemas.Clases
{
    public class clsProveedore
    {
        private Academia_SistemasEntities dbProveedore = new Academia_SistemasEntities();
        public Proveedore proveedore { get; set; }

        public string Insertar()
        {
            try
            {
                dbProveedore.Proveedores.Add(proveedore);
                dbProveedore.SaveChanges();
                return "Proveedor insertado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar el proveedor: " + ex.Message;
            }
        }

        public Proveedore Consultar(int Idproveedor)
        {
            try
            {
                Proveedore pro = dbProveedore.Proveedores.Where(e => e.IdProveedor == proveedore.IdProveedor).FirstOrDefault();
                return pro;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar proveedor: " + ex.Message);
            }
        }

        public string Actualizar()
        {
            Proveedore pro = Consultar(proveedore.IdProveedor);
            if (pro == null)
            {
                return "Proveedor no existe";
            }
            dbProveedore.Proveedores.AddOrUpdate(proveedore);
            dbProveedore.SaveChanges();
            return "Proveedor actualizado correctamente";
        }

        public string Borrar(int IdProveedor)
        {
            Proveedore pro = Consultar(proveedore.IdProveedor);
            if (pro == null)
            {
                return "Proveedore no existe";
            }
            dbProveedore.Proveedores.Remove(pro);
            dbProveedore.SaveChanges();
            return "Proveedore eliminada correctamente";

        }
    }
}
