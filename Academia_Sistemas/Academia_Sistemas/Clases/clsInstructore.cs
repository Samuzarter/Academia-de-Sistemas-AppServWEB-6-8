using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Academia_Sistemas.Models;

namespace Academia_Sistemas.Clases
{
    public class clsInstructore

    {
        private Academia_SistemasEntities dbinstructore = new Academia_SistemasEntities();
        public Instructore instructore { get; set; }

        public string Insertar()
        {
            try
            {
                dbinstructore.Instructores.Add(instructore);
                dbinstructore.SaveChanges();
                return "Instructor insertado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar el instructor: " + ex.Message;
            }
        }

        public Instructore Consultar(int Idinstructor)
        {
            try
            {
                Instructore inst = dbinstructore.Instructores.Where(e => e.Idinstructor == instructore.Idinstructor).FirstOrDefault();
                return inst;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar instructor: " + ex.Message);
            }
        }

        public string Actualizar()
        {
            Instructore inst = Consultar(instructore.Idinstructor);
            if (inst == null)
            {
                return "Instructor no existe";
            }
            dbinstructore.Instructores.AddOrUpdate(instructore);
            dbinstructore.SaveChanges();
            return "Instructore actualizado correctamente";
        }

        public string Borrar(int Idinstructor)
        {
            Instructore inst = Consultar(instructore.Idinstructor);
            if (inst == null)
            {
                return "Instructor no existe";
            }
            dbinstructore.Instructores.Remove(inst);
            dbinstructore.SaveChanges();
            return "Instructor eliminado correctamente";
        }
    }
}