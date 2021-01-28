using AutoMapper;
using Equinox.Application.Interfaces;
using Equinox.Application.ViewModels;
using Equinox.Domain.Core.Bus;
using Equinox.Domain.Interfaces;
using System;

namespace Equinox.Application.Services
{
    public class CursoEstatisticaAppService : ICursoEstatisticaAppService
    {
        private readonly IMapper _mapper;
        private readonly ICursoEstatisticaRepository _cursoEstatisticaRepository;
        private readonly IMediatorHandler _mediator;

        public CursoEstatisticaAppService(IMapper mapper,
                                  ICursoEstatisticaRepository cursoEstatisticaRepository,
                                  IMediatorHandler mediator
            )
        {
            _mapper = mapper;
            _cursoEstatisticaRepository = cursoEstatisticaRepository;
            _mediator = mediator;
        }

        public CursoEstatisticaViewModel Estatistica(int cursoId)
        {
            return _mapper.Map<CursoEstatisticaViewModel>(_cursoEstatisticaRepository.Estatistica(cursoId));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
