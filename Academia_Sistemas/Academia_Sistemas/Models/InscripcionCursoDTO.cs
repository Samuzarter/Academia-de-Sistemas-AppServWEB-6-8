using Academia_Sistemas.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Academia_Sistemas.DTOs
{
    public class InscripcionCursoDTO
    {
        [Column("id")]
        public int IdEstudiante { get; set; }

        [Column("curso_id")]
        public int IdCurso { get; set; }

        [Column("sede_id")]
        public int IdSede { get; set; }

        public DateTime fecha_inicio { get; set; }

        public DateTime fecha_fin { get; set; }

        public decimal Monto { get; set; }
        public string MetodoPago { get; set; }
    }
}
