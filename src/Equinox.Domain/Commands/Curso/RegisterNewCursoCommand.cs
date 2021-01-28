using System;
using System.Collections.Generic;
using Equinox.Domain.Models;

namespace Equinox.Domain.Commands.Curso
{
    public class RegisterNewCursoCommand : CursoCommand
    {
        public RegisterNewCursoCommand(
        int id,
        string nome,
        int capacidade,
        int numeroAlunos
)
        {
            Id = id;
            Nome = nome;
            Capacidade = capacidade;
            NumeroAlunos = numeroAlunos;
    }

    public override bool IsValid()
        {
            //ValidationResult = new RegisterNewClienteCommandValidation().Validate(this);
            //return ValidationResult.IsValid;
            return true;
        }
    }
}