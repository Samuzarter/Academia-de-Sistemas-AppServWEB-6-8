using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Academia_Sistemas.Models;

namespace Academia_Sistemas.Clases
{
    public class clsInstructores

    {
        private Academia_SistemasEntities dbinstructores = new Academia_SistemasEntities();
        public Instructore instructore { get; set; }

        public string Insertar()
        {
            try
            {
                dbinstructores.Instructores.Add(instructore);
                dbinstructores.SaveChanges();
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
                Instructore inst = dbinstructores.Instructores.Where(e => e.Idinstructor == Idinstructor).FirstOrDefault();
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
            dbinstructores.Instructores.AddOrUpdate(instructore);
            dbinstructores.SaveChanges();
            return "Instructore actualizado correctamente";
        }

        public string Borrar()
        {
            Instructore inst = Consultar(instructore.Idinstructor);
            if (inst == null)
            {
                return "Instructor no existe";
            }
            dbinstructores.Instructores.Remove(inst);
            dbinstructores.SaveChanges();
            return "Instructor eliminado correctamente";
        }
    }
}