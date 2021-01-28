using Equinox.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace Equinox.Application.Interfaces
{
    public interface IAlunoAppService : IDisposable
    {
        AlunoViewModel GetByIdAluno(int id);
        void Register(AlunoViewModel alunoViewModel);
        void Updated(AlunoViewModel alunoViewModel);
        ICollection<AlunoViewModel> GetByCodigoAluno(string codigo);
        ICollection<AlunoViewModel> GetByTermoAluno(string termo, string campo);
        bool ValidaCPF(string vrCPF);
        AlunoViewModel GetByCPFAlunoAsNoTracking(string termo);
        IEnumerable<AlunoContatoViewModel> GetByAlunoContato(string termo);
        dynamic RecuperarDropDownTipoContato();
        AlunoViewModel GetByCPFAluno(string termo);
    }
}
