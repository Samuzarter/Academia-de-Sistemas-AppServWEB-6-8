using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Academia_Sistemas.Models;

namespace Academia_Sistemas.Clases
{
    public class clsInscripciones
    {
        private Academia_SistemasEntities dbInscripciones = new Academia_SistemasEntities();
        public Inscripcione inscripcione { get; set; }

        public string Insertar()
        {
            try
            {
                dbInscripciones.Inscripciones.Add(inscripcione);
                dbInscripciones.SaveChanges();
                return "Inscripcion insertada correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar la inscripcion: " + ex.Message;
            }
        }

        public Inscripcione Consultar(int IdInscripcion)
        {
            try
            {
                Inscripcione ins = dbInscripciones.Inscripciones.Where(e => e.IdInscripcion == IdInscripcion).FirstOrDefault();
                return ins;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar inscripcion: " + ex.Message);
            }
        }

        public string Actualizar()
        {
            Inscripcione ins = Consultar(inscripcione.IdInscripcion);
            if (ins == null)
            {
                return "Inscripcion no existe";
            }
            dbInscripciones.Inscripciones.AddOrUpdate(inscripcione);
            dbInscripciones.SaveChanges();
            return "Inscripcion actualizada correctamente";
        }

        public string Borrar()
        {
            Inscripcione ins = Consultar(inscripcione.IdInscripcion);
            if (ins == null)
            {
                return "Inscripcion no existe";
            }
            dbInscripciones.Inscripciones.Remove(ins);
            dbInscripciones.SaveChanges();
            return "Inscripcione eliminada correctamente";
        }
    }
}