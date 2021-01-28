using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Equinox.Domain.Dto
{
    public class CursoEstatisticaDto
    {
        [Key]
        public int cursoId { get; set; }
        public string nome { get; set; }
        public int idadeMinima { get; set; }
        public int idadeMaxima { get; set; }
        public decimal mediaIdade { get; set; }

    }
}
