using Equinox.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace Equinox.Application.Interfaces
{
    public interface ICursoAppService : IDisposable
    {
        CursoViewModel GetByIdCurso(int id);
        void Register(CursoViewModel cursoViewModel);
        void Updated(CursoViewModel cursoViewModel);
      }
}
