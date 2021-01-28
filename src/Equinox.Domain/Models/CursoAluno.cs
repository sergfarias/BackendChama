using Equinox.Domain.Core.Models;
using System;

namespace Equinox.Domain.Models
{
    public class CursoAluno : Entity<CursoAluno> 
    {
       
        public int CursoId { get; private set; }
        public int AlunoId { get; private set; }
        public virtual Aluno Aluno { get; private set; }
        public virtual Curso Curso { get; private set; }

        public CursoAluno(int id, int cursoId, int alunoId, Curso curso)
        {
            Id = id;
            CursoId = cursoId;
            AlunoId = alunoId;
            Curso = curso;
        }

        // Empty constructor for EF
        protected CursoAluno() { }

        public override bool IsValid()
        {
            return true;
        }

    }
}