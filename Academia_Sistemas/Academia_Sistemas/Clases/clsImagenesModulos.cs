using Academia_Sistemas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Academia_Sistemas.Clases
{
    public class clsImagenesModulo
    {
        private Academia_SistemasEntities dbSuper = new Academia_SistemasEntities();
        public string idModulo { get; set; }
        public List<string> Archivos { get; set; }
        public string GrabarImagenes()
        {
            try
            {
                if (Archivos.Count > 0)
                {
                    foreach (string Archivo in Archivos)
                    {
                        ImagenesModulo Imagen = new ImagenesModulo();
                        Imagen.IdModulo = Convert.ToInt32(idModulo);
                        Imagen.NombreImagen = Archivo;
                        dbSuper.ImagenesModulos.Add(Imagen);
                        dbSuper.SaveChanges();
                    }
                    return "Imagenes guardadas correctamente";
                }
                else
                {
                    return "No se enviaron archivos para guardar";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}