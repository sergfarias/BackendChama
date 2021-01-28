using Equinox.Domain.Dto;
using Equinox.Domain.Models;
using System.Collections.Generic;

namespace Equinox.Domain.Interfaces
{
    public interface ICursoRepository : IRepository<Curso>
    {
        Curso GetByIdCurso(int id);
    }
}