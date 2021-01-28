using Equinox.Domain.Dto;
using Equinox.Domain.Models;
using System.Collections.Generic;

namespace Equinox.Domain.Interfaces
{
    public interface ICursoAlunoRepository : IRepository<CursoAluno>
    {
       // ICollection<AgendamentoGridDto> CarregarAgendamentos(string data);
       // ICollection<AtendimentoGridDto> CarregarAtendimentos(string data);
     }
}