using System;
using System.Collections.Generic;
using Equinox.Domain.Core.Commands;
using Equinox.Domain.Models;

namespace Equinox.Domain.Commands.Curso
{
    public abstract class CursoCommand : Command
    {
        public int Id { get; protected set; }
        public string Nome { get; protected set; }
        public int Capacidade { get; protected set; }
        public int NumeroAlunos { get; protected set; }
    }
}