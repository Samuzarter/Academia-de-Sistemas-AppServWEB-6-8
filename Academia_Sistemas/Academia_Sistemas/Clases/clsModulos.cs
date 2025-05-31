using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Academia_Sistemas.Models;

namespace Academia_Sistemas.Clases
{
    public class clsModulos
    {
        private Academia_SistemasEntities dbModulos = new Academia_SistemasEntities();
        public Modulo modulo { get; set; }

        public string Insertar()
        {
            try
            {
                dbModulos.Modulos.Add(modulo);
                dbModulos.SaveChanges();
                return "Modulo insertado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar el modulo: " + ex.Message;
            }
        }

        public Modulo Consultar(int Idmodulo)
        {
            try
            {
                Modulo es = dbModulos.Modulos.Where(e => e.IdModulo == Idmodulo).FirstOrDefault();
                return es;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar Modulo: " + ex.Message);
            }
        }

        public string Actualizar()
        {
            Modulo es = Consultar(modulo.IdModulo);
            if (es == null)
            {
                return "Modulo no existe";
            }
            dbModulos.Modulos.AddOrUpdate(modulo);
            dbModulos.SaveChanges();
            return "Modulo actualizado correctamente";
        }

        public string Borrar(int Idmodulo)
        {
            Modulo es = Consultar(Idmodulo);
            if (es == null)
            {
                return "Modulo no existe";
            }
            dbModulos.Modulos.Remove(es);
            dbModulos.SaveChanges();
            return "Modulo eliminado correctamente";
        }
    }
}