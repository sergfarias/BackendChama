using Equinox.Domain.Core.Commands;
using System;

namespace Equinox.Domain.Commands.CursoAluno
{
    public abstract class CursoAlunoCommand : Command
    {
        public int Id { get; protected set; }
        public int CursoId { get; protected set; }
        public int AlunoId { get; protected set; }
    }
}