using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Academia_Sistemas.Models;

namespace Academia_Sistemas.Clases
{
    public class clsinscripcione
    {
        private Academia_SistemasEntities dbInscripcione = new Academia_SistemasEntities();
        public Inscripcione inscripcione { get; set; }

        public string Insertar()
        {
            try
            {
                dbInscripcione.Inscripciones.Add(inscripcione);
                dbInscripcione.SaveChanges();
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
                Inscripcione ins = dbInscripcione.Inscripciones.Where(e => e.IdInscripcion == inscripcione.IdInscripcion).FirstOrDefault();
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
            dbInscripcione.Inscripciones.AddOrUpdate(inscripcione);
            dbInscripcione.SaveChanges();
            return "Inscripcion actualizada correctamente";
        }

        public string Borrar(int IdInscripcion)
        {
            Inscripcione ins = Consultar(inscripcione.IdInscripcion);
            if (ins == null)
            {
                return "Inscripcion no existe";
            }
            dbInscripcione.Inscripciones.Remove(ins);
            dbInscripcione.SaveChanges();
            return "Inscripcione eliminada correctamente";
        }
    }
}