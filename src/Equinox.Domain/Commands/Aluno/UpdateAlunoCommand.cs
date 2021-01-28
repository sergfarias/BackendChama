using System;
using System.Collections.Generic;
using Equinox.Domain.Models;

namespace Equinox.Domain.Commands.Aluno
{
    public class UpdateAlunoCommand : AlunoCommand
    {
        public UpdateAlunoCommand(int id,
        string nome,
        DateTime? dataCadastro,
        string cpf,
        string observacao,
        ICollection<AlunoContato> contatos
     )
        {
            Id = id;
            Nome = nome;
            DataCadastro = dataCadastro;
            Cpf = cpf;
            Observacao = observacao;
            Contatos = contatos;
        }

        public override bool IsValid()
        {
            //ValidationResult = new UpdateCustomerCommandValidation().Validate(this);
            //return ValidationResult.IsValid;
            return true;
        }
    }
}