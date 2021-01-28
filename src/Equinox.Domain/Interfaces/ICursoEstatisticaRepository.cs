using Equinox.Domain.Dto;
using Equinox.Domain.Models;
using System.Collections.Generic;

namespace Equinox.Domain.Interfaces
{
    public interface ICursoEstatisticaRepository : IRepository<Curso>
    {
        CursoEstatisticaDto Estatistica(int cursoId);

    }
}