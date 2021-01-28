using System;

namespace Equinox.Domain.Commands.Aluno
{
    public class RemoveAlunoCommand : AlunoCommand
    {
        public RemoveAlunoCommand(int id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            //ValidationResult = new RemoveClienteCommandValidation().Validate(this);
            //return ValidationResult.IsValid;
            return true;
        }
    }
}