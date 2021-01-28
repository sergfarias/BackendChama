using System;
using Equinox.Domain.Core.Models;

namespace Equinox.Domain.Models
{
    public class AlunoContato : Entity<AlunoContato> 
    {
        
        public int AlunoId { get; private set; }
        public int TipoContatoId { get; private set; }

        public TipoContato TipoContato
        {
            get => TipoContato.ObterPorId(TipoContatoId);
            set => TipoContatoId = value.Id;
        }

        public string NomeContato { get; private set; }
        public virtual Aluno  Aluno { get; private set; }

        public AlunoContato(int id, string nomeContato, int tipoContatoId, int alunoId, Aluno aluno)
        {
            Id = id;
            TipoContatoId = tipoContatoId;
            NomeContato = nomeContato;
            AlunoId=alunoId;
            Aluno = aluno;
        }

        // Empty constructor for EF
        protected AlunoContato() { }

        public override bool IsValid()
        {
            return true;
        }

    }
}