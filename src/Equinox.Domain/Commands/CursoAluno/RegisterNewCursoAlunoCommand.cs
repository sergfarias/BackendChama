using System;

namespace Equinox.Domain.Commands.CursoAluno
{
    public class RegisterNewCursoAlunoCommand : CursoAlunoCommand
    {
        public RegisterNewCursoAlunoCommand(
         int id,
        int cursoId, 
        int alunoId
        )
        {
            Id = id;
            CursoId = cursoId;
            AlunoId = alunoId;
        }

        public override bool IsValid()
        {
            //ValidationResult = new RegisterNewClienteCommandValidation().Validate(this);
            //return ValidationResult.IsValid;
            return true;
        }
    }
}