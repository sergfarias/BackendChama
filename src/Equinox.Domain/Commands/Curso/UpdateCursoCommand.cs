using System;
using System.Collections.Generic;
using Equinox.Domain.Models;

namespace Equinox.Domain.Commands.Curso
{
    public class UpdateCursoCommand : CursoCommand
    {
        public UpdateCursoCommand(int id,
            int capacidade,
            int numeroAlunos
        )
        {
            Id = id;
            Capacidade = capacidade;
            NumeroAlunos = numeroAlunos;
        }

    public override bool IsValid()
        {
            //ValidationResult = new UpdateCustomerCommandValidation().Validate(this);
            //return ValidationResult.IsValid;
            return true;
        }
    }
}