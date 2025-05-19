using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Academia_Sistemas.Models;

namespace Academia_Sistemas.Clases
{
    public class clsProveedores
    {
        private Academia_SistemasEntities dbProveedores = new Academia_SistemasEntities();
        public Proveedore proveedore { get; set; }

        public string Insertar()
        {
            try
            {
                dbProveedores.Proveedores.Add(proveedore);
                dbProveedores.SaveChanges();
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
                Proveedore pro = dbProveedores.Proveedores.Where(e => e.IdProveedor == Idproveedor).FirstOrDefault();
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
            dbProveedores.Proveedores.AddOrUpdate(proveedore);
            dbProveedores.SaveChanges();
            return "Proveedor actualizado correctamente";
        }

        public string Borrar()
        {
            Proveedore pro = Consultar(proveedore.IdProveedor);
            if (pro == null)
            {
                return "Proveedore no existe";
            }
            dbProveedores.Proveedores.Remove(pro);
            dbProveedores.SaveChanges();
            return "Proveedore eliminada correctamente";

        }
    }
}
