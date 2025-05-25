using Academia_Sistemas.Clases;
using Academia_Sistemas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Academia_Sistemas.Clases
{
    public class clsUsuario
    {
        private Academia_SistemasEntities DBSuper = new Academia_SistemasEntities();
        public Usuario usuario { get; set; }
        public string CrearUsuario(int idPerfil)
        {
            //Se van a crear el usuario y el usuario perfil
            clsCypher cypher = new clsCypher();
            string ClaveCifrada;
            cypher.Password = usuario.Clave;
            if (cypher.CifrarClave())
            {
                ClaveCifrada = cypher.PasswordCifrado;
            }
            else
            {
                return "Error al cifrar la clave";
            }
            //Graba el usuario
            usuario.Clave = ClaveCifrada;
            usuario.Salt = cypher.Salt;
            DBSuper.Usuarios.Add(usuario);
            DBSuper.SaveChanges();
            //Graba el usuario perfil
            Usuario_Perfil usuarioPerfil = new Usuario_Perfil();
            usuarioPerfil.IdUsuario = usuario.IdUsuario;
            usuarioPerfil.IdPerfil = idPerfil;
            usuarioPerfil.Activo = true; //Cuando se crea normalmente, debe ser activo
            DBSuper.Usuario_Perfil.Add(usuarioPerfil);
            DBSuper.SaveChanges();
            return "Se creó el usuario exitosamente";
        }
    }
}