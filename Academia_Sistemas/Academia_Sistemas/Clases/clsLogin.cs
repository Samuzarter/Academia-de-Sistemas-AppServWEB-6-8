using Academia_Sistemas.Clases;
using Academia_Sistemas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Academia_Sistemas.Clases
{
    public class clsLogin
    {
        public clsLogin()
        {
            loginRespuesta = new LoginRespuesta();
        }
        public Academia_SistemasEntities dbSuper = new Academia_SistemasEntities();
        public Login login { get; set; }
        public LoginRespuesta loginRespuesta { get; set; }
        private bool ValidarUsuario()
        {
            try
            {
                //Se instancia un objeto de la clase Cypher
                clsCypher cifrar = new clsCypher();
                //Se consulta el Usuario, sólo con el nombre, para obtener la información básica del Usuario: Salt y clave encriptada
                Usuario Usuario = dbSuper.Usuarios.FirstOrDefault(u => u.Username == login.Usuario);
                if (Usuario == null)
                {
                    //El Usuario no existe, se retorna un error
                    loginRespuesta.Autenticado = false;
                    loginRespuesta.Mensaje = "Usuario no existe";
                    return false;
                }
                //El Usuario existe, se lee la información del Salt y se traduce a un arreglo de bytes y se cifra la clave que envió el Usuario
                byte[] arrBytesSalt = Convert.FromBase64String(Usuario.Salt);
                //login.clave tiene la clave plana
                string ClaveCifrada = cifrar.HashPassword(login.Clave, arrBytesSalt);
                //Se obtiene la clave cifrada
                login.Clave = ClaveCifrada;
                return true;
            }
            catch (Exception ex)
            {
                loginRespuesta.Autenticado = false;
                loginRespuesta.Mensaje = ex.Message;
                return false;
            }
        }
        private bool ValidarClave()
        {
            try
            {
                //Se consulta el Usuario con la clave encriptada y el Usuario para validar si existe
                Usuario Usuario = dbSuper.Usuarios.FirstOrDefault(u => u.Username == login.Usuario && u.Clave == login.Clave);
                if (Usuario == null)
                {
                    //Si no existe la clave es incorrecta
                    loginRespuesta.Autenticado = false;
                    loginRespuesta.Mensaje = "La clave no coincide";
                    return false;
                }
                //La clave y el Usuario son correctos
                return true;
            }
            catch (Exception ex)
            {
                loginRespuesta.Autenticado = false;
                loginRespuesta.Mensaje = ex.Message;
                return false;
            }
        }
        public IQueryable<LoginRespuesta> Ingresar()
        {
            //Si la validación es simple, en este punto se pone el código: if (user = "admin"){ token=...;}else{error;}
            if (ValidarUsuario() && ValidarClave())
            {
                //Si el Usuario y la clave son correctas, se genera el token
                string token = TokenGenerator.GenerateTokenJwt(login.Usuario);

                Usuario Usuario = dbSuper.Usuarios.FirstOrDefault(u => u.Username == login.Usuario);

                // Buscar si es Instructor o Estudiante
                var estudiante = dbSuper.Estudiantes.FirstOrDefault(e => e.IdUsuario == Usuario.IdUsuario);
                var instructor = dbSuper.Instructores.FirstOrDefault(i => i.IdUsuario == Usuario.IdUsuario);

                // Determinar ID de persona
                int idPersona = estudiante != null ? estudiante.IdEstudiante :
                                instructor != null ? instructor.Idinstructor : 0;

                //Consulta la información del usuario y el perfil
                return from U in dbSuper.Set<Usuario>()
                       join UP in dbSuper.Set<Usuario_Perfil>() on U.IdUsuario equals UP.IdUsuario
                       join P in dbSuper.Set<Perfile>() on UP.IdPerfil equals P.IdPerfil
                       where U.Username == login.Usuario && U.Clave == login.Clave
                       select new LoginRespuesta
                       {
                           Usuario = U.Username,
                           Autenticado = true,
                           Perfil = P.Nombre,
                           PaginaInicio = P.PaginaNavegar,
                           Token = token,
                           Mensaje = "",
                           IdPersona = idPersona 
                       };

            }
            else
            {
                List<LoginRespuesta> List = new List<LoginRespuesta>();
                List.Add(loginRespuesta);
                return List.AsQueryable();
            }
        }
    }
}