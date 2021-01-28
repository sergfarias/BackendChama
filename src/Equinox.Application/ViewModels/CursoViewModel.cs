using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Equinox.Application.ViewModels
{
    public class CursoViewModel
    {
        [Key]
        public int id { get; set; }
        public string nome { get; set; }
        public int capacidade { get; set; }
        public int numeroAlunos { get; set; }

    }
}
