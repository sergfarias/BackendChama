using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Equinox.Application.ViewModels
{
    public class AlunoViewModel
    {
        [Key]
        public int id { get; set; }
        public string nome { get;  set; }
        public string email { get; set; }
        public DateTime? dataCadastro { get; set; }
        public DateTime dataNascimento { get; set; }
        public string cpf { get;  set; }
        public string observacao { get; set; }
        public virtual ICollection<AlunoContatoViewModel> contatos { get;  set; }
    }
}
