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
        public AsignacionInstructore asignacion { get; set; }
        public ProgramacionesCurso programacion { get; set; }

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

        public string Borrar(int Idinstructor)
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

        public string EditarCursoAsignado(int idInstructor, int idCurso, string nuevaDescripcion, int nuevaDuracion)
        {
            try
            {
                // Verificar si el instructor está asignado a una programación que contenga ese curso
                var asignacionValida = (from ai in dbinstructores.AsignacionInstructores
                                        join pc in dbinstructores.ProgramacionesCursos on ai.IdProgramacion equals pc.IdProgramacion
                                        where ai.IdInstructor == idInstructor && pc.IdCurso == idCurso
                                        select ai).FirstOrDefault();

                if (asignacionValida == null)
                {
                    return "El instructor no tiene asignado este curso.";
                }

                // Buscar el curso
                Curso curso = dbinstructores.Cursos.Where(c => c.IdCurso == idCurso).FirstOrDefault();
                if (curso == null)
                {
                    return "Curso no encontrado.";
                }

                // Actualizar los campos permitidos
                curso.Descripcion = nuevaDescripcion;
                curso.Duracion = nuevaDuracion;

                dbinstructores.SaveChanges();
                return "Curso actualizado correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al actualizar el curso: " + ex.Message;
            }
        }

        public List<Curso> VerCursosAsignados(int idInstructor)
        {
            try
            {
                // Buscar todas las programaciones de cursos asignadas a este instructor
                var cursosAsignados = (from ai in dbinstructores.AsignacionInstructores
                                       join pc in dbinstructores.ProgramacionesCursos on ai.IdProgramacion equals pc.IdProgramacion
                                       join c in dbinstructores.Cursos on pc.IdCurso equals c.IdCurso
                                       where ai.IdInstructor == idInstructor
                                       select c).Distinct().ToList();

                return cursosAsignados;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los cursos asignados: " + ex.Message);
            }
        }


            public string EditarCalificacion(int idInstructor, int idCurso, int idEstudiante, decimal nuevaNota, string observaciones)
            {
                try
                {
                    // Validar si el instructor tiene asignado ese curso
                    var asignacionValida = (from ai in dbinstructores.AsignacionInstructores
                                            join pc in dbinstructores.ProgramacionesCursos on ai.IdProgramacion equals pc.IdProgramacion
                                            where ai.IdInstructor == idInstructor && pc.IdCurso == idCurso
                                            select pc.IdProgramacion).ToList();

                    if (!asignacionValida.Any())
                    {
                        return "El instructor no tiene asignado este curso.";
                    }

                    // Buscar inscripción válida del estudiante en una programación del curso asignado
                    var inscripcion = dbinstructores.Inscripciones
                        .Where(i => i.IdEstudiante == idEstudiante && asignacionValida.Contains((int)i.IdProgramacion))
                        .FirstOrDefault();

                    if (inscripcion == null)
                    {
                        return "El estudiante no está inscrito en este curso impartido por el instructor.";
                    }

                    // Buscar la calificación
                    var calificacion = dbinstructores.Calificaciones
                        .Where(c => c.IdInscripcion == inscripcion.IdInscripcion)
                        .FirstOrDefault();

                    if (calificacion == null)
                    {
                        // Si no existe, se crea
                        calificacion = new Calificacione
                        {
                            IdInscripcion = inscripcion.IdInscripcion,
                            Nota = nuevaNota,
                            Observaciones = observaciones
                        };
                        dbinstructores.Calificaciones.Add(calificacion);
                    }
                    else
                    {
                        // Si ya existe, se actualiza
                        calificacion.Nota = nuevaNota;
                        calificacion.Observaciones = observaciones;
                    }

                    dbinstructores.SaveChanges();
                    return "Calificación actualizada correctamente.";
                }
                catch (Exception ex)
                {
                    return "Error al editar calificación: " + ex.Message;
                }
            }
        }


    }


