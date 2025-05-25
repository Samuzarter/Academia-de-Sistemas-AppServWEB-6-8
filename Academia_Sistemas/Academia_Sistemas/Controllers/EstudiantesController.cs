using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Academia_Sistemas.Clases;
using Academia_Sistemas.Models;
using System.Web.Http;

namespace Academia_Sistemas.Controllers
{
    [RoutePrefix("api/Estudiantes")]
    public class EstudiantesController : ApiController
    {

        [HttpGet]
        [Route("Consultar")]
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
            } catch (Exception ex)
            {
                return $"Error al insertar Estudiante con usuario: {ex.Message}";
            }
            
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar(Estudiante Estudiante)
        {
            clsEstudiantes clsEstudiante = new clsEstudiantes();
            clsEstudiante.estudiante = Estudiante;
            return clsEstudiante.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int idEstudiante)
        {
            clsEstudiantes clsEstudiante = new clsEstudiantes();
            return clsEstudiante.Borrar(idEstudiante);
        }
    }
}