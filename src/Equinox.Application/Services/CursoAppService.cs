using AutoMapper;
using Equinox.Application.Interfaces;
using Equinox.Application.ViewModels;
using Equinox.Domain.Commands.Curso;
using Equinox.Domain.Core.Bus;
using Equinox.Domain.Interfaces;
using System;

namespace Equinox.Application.Services
{
    public class CursoAppService : ICursoAppService
    {
        private readonly IMapper _mapper;
        private readonly ICursoRepository _cursoRepository;
        private readonly IMediatorHandler _mediator;

        public CursoAppService(IMapper mapper,
                                  ICursoRepository cursoRepository,
                                  IMediatorHandler mediator
            )
        {
            _mapper = mapper;
            _cursoRepository = cursoRepository;
            _mediator = mediator;
        }

        public CursoViewModel GetByIdCurso(int id)
        {
            return _mapper.Map<CursoViewModel>(_cursoRepository.GetByIdCurso(id));
        }

        public void Register(CursoViewModel cursoViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewCursoCommand>(cursoViewModel);
            _mediator.SendCommand(registerCommand);
        }

        public void Updated(CursoViewModel cursoViewModel)
        {
            var updateCommand = _mapper.Map<UpdateCursoCommand>(cursoViewModel);
            _mediator.SendCommand(updateCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
