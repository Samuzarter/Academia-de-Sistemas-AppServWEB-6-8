using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Academia_Sistemas.Models;

namespace Academia_Sistemas.Clases
{
    public class clsAsignacionInstructore
    {
        private Academia_SistemasEntities dbAsgInst = new Academia_SistemasEntities();
        public AsignacionInstructore asignacionInstructore { get; set; }

        public string Insertar()
        {
            try
            {
                dbAsgInst.AsignacionInstructores.Add(asignacionInstructore);
                dbAsgInst.SaveChanges();
                return "Asignacion insertada correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar la asignacion: " + ex.Message;
            }
        }

        public AsignacionInstructore Consultar(int IdAsignacion)
        {
            try
            {
                AsignacionInstructore asi = dbAsgInst.AsignacionInstructores.Where(e => e.IdAsignacion == asignacionInstructore.IdAsignacion).FirstOrDefault();
                return asi;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar asignacion: " + ex.Message);
            }
        }

        public string Actualizar()
        {
            AsignacionInstructore asi = Consultar(asignacionInstructore.IdAsignacion);
            if (asi == null)
            {
                return "AsignacionI no existe";
            }
            dbAsgInst.AsignacionInstructores.AddOrUpdate(asignacionInstructore);
            dbAsgInst.SaveChanges();
            return "Asignacion actualizada correctamente";
        }

        public string Borrar(int IdAsignacion)
        {
            AsignacionInstructore asi = Consultar(asignacionInstructore.IdAsignacion);
            if (asi == null)
            {
                return "Asignacion no existe";
            }
            dbAsgInst.AsignacionInstructores.Remove(asi);
            dbAsgInst.SaveChanges();
            return "Asignacion eliminada correctamente";
        }
    }
}