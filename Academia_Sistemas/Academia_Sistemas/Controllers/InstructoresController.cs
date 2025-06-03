using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Academia_Sistemas.Clases;
using Academia_Sistemas.Models;
using System.Web.Http;
using static Academia_Sistemas.Clases.clsInstructores;
using System.Net.Http;
using System.Web.Http.Cors;

namespace Academia_Sistemas.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Instructore")]
    public class InstructoresController : ApiController
    {

        [HttpGet]
        [Route("Consultar")]
        public Instructore Consultar(int IdInstructore)
        {
            clsInstructores clsInstructore = new clsInstructores();
            return clsInstructore.Consultar(IdInstructore); ;
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar(InstructorUsuarioDTO datos)
        {
            try
            {
                if (datos.Usuario == null || datos.Instructor == null)
                {
                    return $"Usuario o Instructor no fueron ingresados";
                }
                clsUsuario UsuarioNuevo = new clsUsuario();
                UsuarioNuevo.usuario = datos.Usuario;

                string UsuarioCreado = UsuarioNuevo.CrearUsuario(1);

                if (!UsuarioCreado.Contains("exitosamente"))
                {
                    return $"Error al crear el usuario: {UsuarioCreado}";
                }

                clsInstructores clsInstructore = new clsInstructores();
                clsInstructore.instructore = datos.Instructor;
                clsInstructore.instructore.IdUsuario = UsuarioNuevo.usuario.IdUsuario;

                return clsInstructore.Insertar();
            }
            catch (Exception ex)
            {
                return $"Error al insertar Instructor con usuario: {ex.Message}";
            }
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar(Instructore Instructore)
        {
            clsInstructores clsInstructore = new clsInstructores();
            clsInstructore.instructore = Instructore;
            return clsInstructore.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int idInstructore)
        {
            clsInstructores clsInstructore = new clsInstructores();
            return clsInstructore.Borrar(idInstructore);
        }

        [HttpPut]
        [Route("EditarCursoAsignado")]
        public string EditarCursoAsignado(int idInstructor, int idCurso, string nuevaDescripcion, int nuevaDuracion)
        {
            clsInstructores clsInstructores = new clsInstructores();
            Curso modCurso = new Curso
            {
                IdCurso = idCurso,
                Descripcion = nuevaDescripcion,
                Duracion = nuevaDuracion
            };
            return clsInstructores.EditarCursoAsignado(idInstructor, modCurso);
        }


        [HttpGet]
        [Route("VerCursosAsignados")]
        public List<Curso> VerCursosAsignados(int idInstructor)
        {
            clsInstructores clsInsdtructore = new clsInstructores();
            return clsInsdtructore.VerCursosAsignados(idInstructor);
        }


        [HttpPost]
        [Route("EditarCalificacionPorCurso")]
        public string EditarCalificacionPorCurso(int idInstructor, int idCurso, int idEstudiante, decimal nota, string observaciones)
        {
            clsInstructores clsInstructor = new clsInstructores();

            Calificacione calificacion = new Calificacione
            {
                Nota = nota,
                Observaciones = observaciones
            };

            return clsInstructor.EditarCalificacion(idInstructor, idCurso, idEstudiante, calificacion);
        }


        [HttpPost]
        [Route("CrearModulos")]
        public string CrearModulo(int idInstructor, Modulo nuevoModulo)
        {
            clsInstructores clsInstructores = new clsInstructores();
            return clsInstructores.CrearModulo(idInstructor, nuevoModulo);
        }

        [HttpGet]
        [Route("VerEquiposAsignados")]
        public List<InventarioEquipos> VerEquiposAsignados(int idInstructor)
        {
            clsInstructores clsInstructores = new clsInstructores();
            return clsInstructores.VerEquiposAsignados(idInstructor);
        }

        [HttpGet]
        [Route("VerEstudiantesPorCurso")]
        public List<Estudiante> VerEstudiantesPorCurso(int idInstructor, int idCurso)
        {
            clsInstructores clsInstructores = new clsInstructores();
            return clsInstructores.VerEstudiantesPorCurso(idInstructor, idCurso);
        }

    }

}