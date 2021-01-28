using System;
using System.Collections.Generic;
using Equinox.Domain.Models;

namespace Equinox.Domain.Commands.Aluno
{
    public class RegisterNewAlunoCommand : AlunoCommand
    {
        public RegisterNewAlunoCommand(
        int id,
        string nome,
        DateTime? dataCadastro,
        string cpf,
        string observacao,
        ICollection<AlunoContato> contatos
)
        {
            Id = id;
            Nome = nome;
            DataCadastro= dataCadastro;
            Cpf = cpf;
            Observacao = observacao;
            Contatos = contatos;
        }

        public override bool IsValid()
        {
            //ValidationResult = new RegisterNewClienteCommandValidation().Validate(this);
            //return ValidationResult.IsValid;
            return true;
        }
    }
}