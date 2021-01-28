using Equinox.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace Equinox.Application.Interfaces
{
    public interface ICursoEstatisticaAppService : IDisposable
    {
        CursoEstatisticaViewModel Estatistica(int cursoId);
    }
}
