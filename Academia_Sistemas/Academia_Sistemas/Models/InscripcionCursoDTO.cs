using Academia_Sistemas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Academia_Sistemas.DTOs
{
    public class InscripcionCursoDTO
    {
        public int IdEstudiante { get; set; }
        public int IdCurso { get; set; }
        public int IdSede { get; set; }
        public decimal Monto { get; set; }
        public string MetodoPago { get; set; }
    }
}
