using Equinox.Domain.Dto;
using Equinox.Domain.Models;
using System.Collections.Generic;

namespace Equinox.Domain.Interfaces
{
    public interface IAlunoRepository : IRepository<Aluno>
    {
        Aluno GetByIdAluno(int id);
        Aluno GetByCPFAluno(string termo);
        IEnumerable<AlunoContatoDto> GetByAlunoContato(string Termo);
        dynamic RecuperarDropDownTipoContato();
        ICollection<Aluno> GetByTermoAluno(string termo, string campo = null);
        ICollection<Aluno> GetByCodigoAluno(string codigo);
        Aluno GetByCPFAlunoAsNoTracking(string termo);
    }
}