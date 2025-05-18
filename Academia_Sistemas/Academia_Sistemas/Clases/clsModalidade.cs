using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Academia_Sistemas.Models;

namespace Academia_Sistemas.Clases
{
    public class clsModalidade
    {
        private Academia_SistemasEntities dbModalidad = new Academia_SistemasEntities();
        public Modalidade modalidade { get; set; }

        public string Insertar()
        {
            try
            {
                dbModalidad.Modalidades.Add(modalidade);
                dbModalidad.SaveChanges();
                return "Modalidad insertada correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar el modalidad: " + ex.Message;
            }
        }

        public Modalidade Consultar(int IdModalidad)
        {
            try
            {
                Modalidade mod = dbModalidad.Modalidades.Where(e => e.IdModalidad == modalidade.IdModalidad).FirstOrDefault();
                return mod;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar modalidad: " + ex.Message);
            }
        }

        public string Actualizar()
        {
            Modalidade mod = Consultar(modalidade.IdModalidad);
            if (mod == null)
            {
                return "Modalidad no existe";
            }
            dbModalidad.Modalidades.AddOrUpdate(modalidade);
            dbModalidad.SaveChanges();
            return "Modalidad actualizada correctamente";
        }

        public string Borrar()
        {
            Modalidade mod = Consultar(modalidade.IdModalidad);
            if (mod == null)
            {
                return "Modalidade no existe";
            }
            dbModalidad.Modalidades.Remove(mod);
            dbModalidad.SaveChanges();
            return "Modalidad eliminadoa correctamente";
        }
    }
}