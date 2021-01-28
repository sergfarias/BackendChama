using System;
using System.Collections.Generic;
using Equinox.Domain.Core.Commands;
using Equinox.Domain.Models;

namespace Equinox.Domain.Commands.Aluno
{
    public abstract class AlunoCommand : Command
    {
        public int Id { get; protected set; }
        public string Nome { get; protected set; }
        public string Email { get; protected set; }
        public DateTime DataNascimento { get; protected set; }
        public DateTime? DataCadastro { get; protected set; }
        public string Cpf { get; protected set; }
        public string Observacao { get; protected set; }
        public virtual ICollection<AlunoContato> Contatos { get; set; }
    }
}