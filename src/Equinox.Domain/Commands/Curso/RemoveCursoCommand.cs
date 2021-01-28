using System;

namespace Equinox.Domain.Commands.Curso
{
    public class RemoveCursoCommand : CursoCommand
    {
        public RemoveCursoCommand(int id)
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