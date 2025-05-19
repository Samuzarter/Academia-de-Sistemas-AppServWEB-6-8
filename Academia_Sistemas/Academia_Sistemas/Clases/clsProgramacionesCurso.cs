using System;
using System.Data.Entity.Migrations;
using System.Linq;
using Academia_Sistemas.Models;

namespace Academia_Sistemas.Clases
{
    public class clsProgramacionesCurso
    {
        private Academia_SistemasEntities dbProCurso = new Academia_SistemasEntities();
        public ProgramacionesCurso procurso { get; set; }

        public string Insertar()
        {
            try
            {
                dbProCurso.ProgramacionesCursos.Add(procurso);
                dbProCurso.SaveChanges();
                return "Programacion insertada correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar el programcion: " + ex.Message;
            }
        }

        public ProgramacionesCurso Consultar(int IdProgramacion)
        {
            try
            {
                ProgramacionesCurso procu = dbProCurso.ProgramacionesCursos.Where(e => e.IdProgramacion == procurso.IdProgramacion).FirstOrDefault();
                return procu;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar proveedor: " + ex.Message);
            }
        }

        public string Actualizar()
        {
            ProgramacionesCurso procu = Consultar(procurso.IdProgramacion);
            if (procu == null)
            {
                return "Proveedor no existe";
            }
            dbProCurso.ProgramacionesCursos.AddOrUpdate(procurso);
            dbProCurso.SaveChanges();
            return "Proveedor actualizado correctamente";
        }

        public string Borrar(int IdProgramacion)
        {
            ProgramacionesCurso procu = Consultar(procurso.IdProgramacion);
            if (procu == null)
            {
                return "Proveedore no existe";
            }
            dbProCurso.ProgramacionesCursos.Remove(procu);
            dbProCurso.SaveChanges();
            return "Proveedore eliminada correctamente";

        }
    }
}
