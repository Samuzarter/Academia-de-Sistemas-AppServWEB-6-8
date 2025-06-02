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
            Instructore inst = Consultar(Idinstructor);
            if (inst == null)
            {
                return "Instructor no existe";
            }
            dbinstructores.Instructores.Remove(inst);
            dbinstructores.SaveChanges();
            return "Instructor eliminado correctamente";
        }

        public string EditarCursoAsignado(int idInstructor, Curso cursoEditado)
        {
            try
            {
                // Verificar si el instructor está asignado a una programación que contenga ese curso
                var asignacionValida = (from ai in dbinstructores.AsignacionInstructores
                                        join pc in dbinstructores.ProgramacionesCursos on ai.IdProgramacion equals pc.IdProgramacion
                                        where ai.IdInstructor == idInstructor && pc.IdCurso == cursoEditado.IdCurso
                                        select ai).FirstOrDefault();

                if (asignacionValida == null)
                {
                    return "El instructor no tiene asignado este curso.";
                }

                // Buscar el curso
                Curso curso = dbinstructores.Cursos.Where(c => c.IdCurso == cursoEditado.IdCurso).FirstOrDefault();
                if (curso == null)
                {
                    return "Curso no encontrado.";
                }

                // Actualizar solo los campos que no son null
                if (!string.IsNullOrEmpty(cursoEditado.Descripcion))
                {
                    curso.Descripcion = cursoEditado.Descripcion;
                }

                if (cursoEditado.Duracion > 0)
                {
                    curso.Duracion = cursoEditado.Duracion;
                }

                // Puedes agregar más campos aquí si se necesitan validar

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

        public string EditarCalificacion(int idInstructor, int idCurso, int idEstudiante, Calificacione calificacionEditada)
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

                // Buscar la calificación existente
                var calificacion = dbinstructores.Calificaciones
                    .Where(c => c.IdInscripcion == inscripcion.IdInscripcion)
                    .FirstOrDefault();

                if (calificacion == null)
                {
                    // Si no existe, crear una nueva calificación con los valores recibidos (si existen)
                    calificacion = new Calificacione
                    {
                        IdInscripcion = inscripcion.IdInscripcion,
                        Nota = calificacionEditada.Nota,
                        Observaciones = calificacionEditada.Observaciones
                    };
                    dbinstructores.Calificaciones.Add(calificacion);
                }
                else
                {
                    // Solo actualiza si los campos no son nulos o vacíos
                    if (calificacionEditada.Nota > 0)
                    {
                        calificacion.Nota = calificacionEditada.Nota;
                    }

                    if (!string.IsNullOrEmpty(calificacionEditada.Observaciones))
                    {
                        calificacion.Observaciones = calificacionEditada.Observaciones;
                    }
                }

                dbinstructores.SaveChanges();
                return "Calificación actualizada correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al editar calificación: " + ex.Message;
            }
        }

        public string CrearModulo(int idInstructor, Modulo nuevoModulo)
        {
            try
            {
                // Validar si el instructor está asignado al curso 
                var asignacionValida = (from ai in dbinstructores.AsignacionInstructores
                                        join pc in dbinstructores.ProgramacionesCursos on ai.IdProgramacion equals pc.IdProgramacion
                                        where ai.IdInstructor == idInstructor && pc.IdCurso == nuevoModulo.IdCurso
                                        select ai).FirstOrDefault();

                if (asignacionValida == null)
                {
                    return "El instructor no tiene asignado este curso, no puede crear módulos.";
                }

                // Agregar el nuevo módulo
                dbinstructores.Modulos.Add(nuevoModulo);
                dbinstructores.SaveChanges(); // para obtener IdModulo

                return "Módulo creado correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al crear el módulo: " + ex.Message;
            }
        }



        public List<InventarioEquipos> VerEquiposAsignados(int idInstructor)
        {
            try
            {
                // Buscar los equipos en las sedes donde el instructor tiene asignaciones
                var equiposAsignados = (from ai in dbinstructores.AsignacionInstructores
                                        join pc in dbinstructores.ProgramacionesCursos on ai.IdProgramacion equals pc.IdProgramacion
                                        join eq in dbinstructores.InventarioEquipos on pc.IdSede equals eq.IdSede
                                        where ai.IdInstructor == idInstructor
                                        select eq).Distinct().ToList();

                // Retornar lista vacía si no hay equipos asignados (sin lanzar excepción)
                return equiposAsignados;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los equipos asignados: " + ex.Message);
            }
        }

        public List<Estudiante> VerEstudiantesPorCurso(int idInstructor, int idCurso)
        {
            try
            {
                // Buscar las programaciones del curso asignadas al instructor
                var programacionesAsignadas = (from ai in dbinstructores.AsignacionInstructores
                                               join pc in dbinstructores.ProgramacionesCursos on ai.IdProgramacion equals pc.IdProgramacion
                                               where ai.IdInstructor == idInstructor && pc.IdCurso == idCurso
                                               select pc.IdProgramacion).ToList();

                if (!programacionesAsignadas.Any())
                {
                    return new List<Estudiante>();
                }

                // Buscar estudiantes inscritos en esas programaciones (evitando nulos)
                var estudiantes = (from ins in dbinstructores.Inscripciones
                                   where ins.IdProgramacion.HasValue && programacionesAsignadas.Contains(ins.IdProgramacion.Value)
                                   join est in dbinstructores.Estudiantes on ins.IdEstudiante equals est.IdEstudiante
                                   select est).Distinct().ToList();

                return estudiantes;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los estudiantes del curso: " + ex.Message);
            }
        }

    }

}


