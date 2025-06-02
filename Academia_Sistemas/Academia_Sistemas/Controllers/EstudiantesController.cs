using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Academia_Sistemas.Clases;
using Academia_Sistemas.Models;
using System.Web.Http;
using System.Security.Claims;
using Academia_Sistemas.DTOs;

namespace Academia_Sistemas.Controllers
{
    [RoutePrefix("api/Estudiantes")]
    public class EstudiantesController : ApiController
    {

        [HttpGet]
        [Route("Consultar")]
        [Authorize]
        public Estudiante Consultar(int IdEstudiante)
        {
            clsEstudiantes clsEstudiante = new clsEstudiantes();
            return clsEstudiante.Consultar(IdEstudiante); ;
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar(EstudianteUsuarioDTO datos)
        {
            try
            {
                if (datos.Usuario == null || datos.Estudiante == null)
                {
                    return $"Usuario o Estudiante no fueron ingresados";
                }
                clsUsuario UsuarioNuevo = new clsUsuario();
                UsuarioNuevo.usuario = datos.Usuario;

                string UsuarioCreado = UsuarioNuevo.CrearUsuario(2);

                if (!UsuarioCreado.Contains("exitosamente"))
                {
                    return $"Error al crear el usuario: {UsuarioCreado}";
                }



                clsEstudiantes clsEstudiante = new clsEstudiantes();
                clsEstudiante.estudiante = datos.Estudiante;
                clsEstudiante.estudiante.IdUsuario = UsuarioNuevo.usuario.IdUsuario;
                return clsEstudiante.Insertar();
            }
            catch (Exception ex)
            {
                return $"Error al insertar Estudiante con usuario: {ex.Message}";
            }

        }

        [HttpPost]
        [Route("InscribirseCurso")]
        public string InscribirseCurso(InscripcionCursoDTO datos)
        {
            clsEstudiantes clsEstudiante = new clsEstudiantes();
            return clsEstudiante.InscribirseACurso(datos);
        }



        [HttpPut]
        [Route("Actualizar")]
        [Authorize]
        public string Actualizar(Estudiante Estudiante)
        {
            clsEstudiantes clsEstudiante = new clsEstudiantes();
            clsEstudiante.estudiante = Estudiante;
            return clsEstudiante.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        [Authorize]
        public string Eliminar(int idEstudiante)
        {
            clsEstudiantes clsEstudiante = new clsEstudiantes();
            return clsEstudiante.Borrar(idEstudiante);
        }

        // GET api/Estudiantes/MiPerfil
        [HttpGet]
        [Route("MiPerfil")]
        public IHttpActionResult MiPerfil()
        {
            try
            {
                // Obtener el IdUsuario del usuario autenticado
                var claimsIdentity = User.Identity as ClaimsIdentity;
                if (claimsIdentity == null)
                    return Unauthorized();

                var idUsuarioClaim = claimsIdentity.FindFirst("IdUsuario");
                if (idUsuarioClaim == null)
                    return Unauthorized();

                int idUsuario = int.Parse(idUsuarioClaim.Value);

                clsEstudiantes clsEstudiante = new clsEstudiantes();
                var estudiante = clsEstudiante.ConsultarPorUsuario(idUsuario);

                if (estudiante == null)
                    return NotFound();

                return Ok(estudiante);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("CursosInscritos")]
        public List<Curso> CursosInscritos(int idEstudiante)
        {
            clsEstudiantes clsEstudiante = new clsEstudiantes();
            return clsEstudiante.ObtenerCursosInscritos(idEstudiante);
        }


    }
}