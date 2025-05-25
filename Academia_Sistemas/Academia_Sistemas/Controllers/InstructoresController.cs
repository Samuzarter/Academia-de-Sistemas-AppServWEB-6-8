using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Academia_Sistemas.Clases;
using Academia_Sistemas.Models;
using System.Web.Http;

namespace Academia_Sistemas.Controllers
{
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
                if(datos.Usuario == null || datos.Instructor == null)
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
    }
}