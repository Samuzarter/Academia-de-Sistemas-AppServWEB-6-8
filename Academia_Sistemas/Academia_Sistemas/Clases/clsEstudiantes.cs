using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Academia_Sistemas.DTOs;
using Academia_Sistemas.Models;

namespace Academia_Sistemas.Clases
{
    public class clsEstudiantes
    {
        private Academia_SistemasEntities dbEstudiantes = new Academia_SistemasEntities();
        public Estudiante estudiante { get; set; }

        public string Insertar()
        {
            try
            {
                dbEstudiantes.Estudiantes.Add(estudiante);
                dbEstudiantes.SaveChanges();
                return "Estudiante insertado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar el estudiante: " + ex.Message;
            }
        }

        public Estudiante Consultar(int IdEstudiante)
        {
            try
            {
                Estudiante es = dbEstudiantes.Estudiantes.Where(e => e.IdEstudiante == IdEstudiante).FirstOrDefault();
                return es;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar estudiante: " + ex.Message);
            }
        }

        public string Actualizar()
        {
            Estudiante es = Consultar(estudiante.IdEstudiante);
            if (es == null)
            {
                return "Estudiante no existe";
            }
            dbEstudiantes.Estudiantes.AddOrUpdate(estudiante);
            dbEstudiantes.SaveChanges();
            return "Estudiante actualizado correctamente";
        }

        public string Borrar(int IdEstudiante)
        {
            Estudiante es = Consultar(IdEstudiante);
            if (es == null)
            {
                return "Estudiante no existe";
            }
            dbEstudiantes.Estudiantes.Remove(es);
            dbEstudiantes.SaveChanges();
            return "Estudiante eliminado correctamente";
        }

        public Estudiante ConsultarPorUsuario(int idUsuario)
        {
            try
            {
                return dbEstudiantes.Estudiantes.FirstOrDefault(e => e.IdUsuario == idUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar estudiante por usuario: " + ex.Message);
            }
        }

        public string InscribirseACurso(InscripcionCursoDTO datos)
        {
            using (var db = new Academia_SistemasEntities())
            {
                try
                {
                    // 1. Crear la programación del curso
                    var nuevaProgramacion = new ProgramacionesCurso
                    {
                        IdCurso = datos.IdCurso,
                        IdSede = datos.IdSede,
                        FechaInicio = datos.fecha_inicio,
                        FechaFin = datos.fecha_fin,
                        Cupos = 20 // puedes ajustar según necesidad
                    };

                    db.ProgramacionesCursos.Add(nuevaProgramacion);
                    db.SaveChanges();

                    // 2. Crear la inscripción
                    var nuevaInscripcion = new Inscripcione
                    {
                        IdEstudiante = datos.IdEstudiante,
                        IdProgramacion = nuevaProgramacion.IdProgramacion,
                        FechaInscripcion = DateTime.Now
                    };

                    db.Inscripciones.Add(nuevaInscripcion);
                    db.SaveChanges();

                    // 3. Crear el pago
                    var nuevoPago = new Pago
                    {
                        IdInscripcion = nuevaInscripcion.IdInscripcion,
                        FechaPago = DateTime.Now,
                        Monto = datos.Monto > 0 ? datos.Monto : 100,
                        MetodoPago = string.IsNullOrEmpty(datos.MetodoPago) ? "Efectivo" : datos.MetodoPago
                    };

                    db.Pagos.Add(nuevoPago);
                    db.SaveChanges();

                    return "Inscripción realizada correctamente";
                }
                catch (Exception ex)
                {
                    return "Error al inscribirse: " + ex.Message;
                }
            }
        }

        public List<Curso> ObtenerCursosInscritos(int idEstudiante)
        {
            using (var db = new Academia_SistemasEntities())
            {
                var cursos = db.Inscripciones
                    .Where(i => i.IdEstudiante == idEstudiante)
                    .Select(i => i.ProgramacionesCurso.Curso)
                    .Distinct()
                    .ToList();

                return cursos;
            }
        }
        public List<Estudiante> ListarTodos()
        {
            try
            {
                return dbEstudiantes.Estudiantes.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar estudiantes: " + ex.Message);
            }
        }



    }
}