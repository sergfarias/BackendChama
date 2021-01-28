using System;
using Equinox.Domain.Core.Models;
using System.Collections.Generic;

namespace Equinox.Domain.Models
{
    public class Curso : Entity<Curso> 
    {
        public string Nome { get; private set; }
        public int Capacidade { get; private set; }
        public int NumeroAlunos { get;private set; }

        public Curso(int id, string nome,  int capacidade, int numeroAlunos)
        {
            Id = id;
            Nome = nome;
            Capacidade = capacidade;
            NumeroAlunos = numeroAlunos;
        }

        public void AcrescentaNumeroAluno()
        {
            NumeroAlunos += 1;
        }

        // Empty constructor for EF
        protected Curso() { }

        public override bool IsValid()
        {
            return true;
        }


    }
}