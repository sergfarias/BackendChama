using System;
using System.ComponentModel.DataAnnotations;

namespace Equinox.Application.ViewModels
{
    public class CursoAlunoViewModel
    {
        [Key]
        public int id { get; set; }
        public int cursoid { get; set; }
        public int alunoid { get; set; }
       
    }
}
