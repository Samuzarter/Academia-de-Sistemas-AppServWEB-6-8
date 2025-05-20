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
        private bool ValidarEstudiante()
        {
            try
            {
                //Se instancia un objeto de la clase Cypher
                clsCypher cifrar = new clsCypher();
                //Se consulta el Estudiante, sólo con el nombre, para obtener la información básica del Estudiante: Salt y clave encriptada
                Estudiante Estudiante = dbSuper.Estudiantes.FirstOrDefault(u => u.userName == login.Estudiante);
                if (Estudiante == null)
                {
                    //El Estudiante no existe, se retorna un error
                    loginRespuesta.Autenticado = false;
                    loginRespuesta.Mensaje = "Estudiante no existe";
                    return false;
                }
                //El Estudiante existe, se lee la información del Salt y se traduce a un arreglo de bytes y se cifra la clave que envió el Estudiante
                byte[] arrBytesSalt = Convert.FromBase64String(Estudiante.Salt);
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
                //Se consulta el Estudiante con la clave encriptada y el Estudiante para validar si existe
                Estudiante Estudiante = dbSuper.Estudiantes.FirstOrDefault(u => u.userName == login.Estudiante && u.Clave == login.Clave);
                if (Estudiante == null)
                {
                    //Si no existe la clave es incorrecta
                    loginRespuesta.Autenticado = false;
                    loginRespuesta.Mensaje = "La clave no coincide";
                    return false;
                }
                //La clave y el Estudiante son correctos
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
            if (ValidarEstudiante() && ValidarClave())
            {
                //Si el Estudiante y la clave son correctas, se genera el token
                string token = TokenGenerator.GenerateTokenJwt(login.Estudiante);
                //Consulta la información del Estudiante y el perfil
                return from U in dbSuper.Set<Estudiante>()
                       join UP in dbSuper.Set<Estudiante_Perfil>()
                       on U.id equals UP.idEstudiante
                       join P in dbSuper.Set<Perfil>()
                       on UP.idPerfil equals P.id
                       where U.userName == login.Estudiante &&
                               U.Clave == login.Clave
                       select new LoginRespuesta
                       {
                           Estudiante = U.userName,
                           Autenticado = true,
                           Perfil = P.Nombre,
                           PaginaInicio = P.PaginaNavegar,
                           Token = token,
                           Mensaje = ""
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