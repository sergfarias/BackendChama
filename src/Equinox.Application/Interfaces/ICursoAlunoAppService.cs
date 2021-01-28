using Equinox.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace Equinox.Application.Interfaces
{
    public interface ICursoAlunoAppService : IDisposable
    {
        void Register(CursoAlunoViewModel cursoAlunoViewModel);
    }
}
