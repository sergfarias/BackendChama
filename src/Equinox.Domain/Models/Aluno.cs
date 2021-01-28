using System;
using Equinox.Domain.Core.Models;
using System.Collections.Generic;

namespace Equinox.Domain.Models
{
    public class Aluno : Entity<Aluno> 
    {
       
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public DateTime? DataCadastro { get; private set; }
        public string Cpf { get; private set; }
        public string Observacao { get; private set; }
        public virtual ICollection<AlunoContato> AlunoContato { get; private set; }
        public virtual ICollection<CursoAluno> CursoAluno { get; private set; }

        public virtual Curso Curso { get; private set; }

        public Aluno(int id,  string nome, string email, DateTime dataNascimento, DateTime? dataCadastro, 
                       string cpf, string observacao,  ICollection<AlunoContato> alunoContato)
        {
            Id = id;
            Nome = nome;
            DataCadastro = dataCadastro;
            Email = email;
            DataNascimento = dataNascimento;
            Cpf = cpf;
            Observacao = observacao;
            AlunoContato = alunoContato;
        }

        // Empty constructor for EF
        protected Aluno() { }

        public override bool IsValid()
        {
            return true;
        }


    }
}