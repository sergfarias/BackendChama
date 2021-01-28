using AutoMapper;
using Equinox.Application.Interfaces;
using Equinox.Application.ViewModels;
using Equinox.Domain.Commands.CursoAluno;
using Equinox.Domain.Core.Bus;
using Equinox.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace Equinox.Application.Services
{
    public class CursoAlunoAppService : ICursoAlunoAppService
    {
        private readonly IMapper _mapper;
        private readonly ICursoAlunoRepository _cursoAlunoRepository;
        private readonly IMediatorHandler _mediator;

        public CursoAlunoAppService(IMapper mapper,
                                  ICursoAlunoRepository cursoAlunoRepository,
                                  IMediatorHandler mediator
            )
        {
            _mapper = mapper;
            _cursoAlunoRepository = cursoAlunoRepository;
            _mediator = mediator;
        }

        public void Register(CursoAlunoViewModel cursoAlunoViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewCursoAlunoCommand>(cursoAlunoViewModel);
            _mediator.SendCommand(registerCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
