using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Equinox.Domain.Dto
{
    public class AlunoContatoDto
    {
        [Key]
        public int id_aluno { get; set; }
        public int id_contato { get; set; }
        public int id_tipo_contato  { get; set; }
        public string ds_contato { get; set; }
    }
}
