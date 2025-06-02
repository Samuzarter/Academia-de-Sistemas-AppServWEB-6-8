using Academia_Sistemas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Academia_Sistemas.DTOs
{
    public class EstudianteUsuarioCursoDTO
    {
        public Estudiante Estudiante { get; set; }
        public Usuario Usuario { get; set; }
        public int IdCurso { get; set; }
        public int? IdSede { get; set; }
        public string MetodoPago { get; set; }
        public decimal Monto { get; set; }
    }
}
