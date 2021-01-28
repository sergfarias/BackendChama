using AutoMapper;
using Equinox.Application.Interfaces;
using Equinox.Application.ViewModels;
using Equinox.Domain.Commands.Aluno;
using Equinox.Domain.Core.Bus;
using Equinox.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace Equinox.Application.Services
{
    public class AlunoAppService : IAlunoAppService
    {
        private readonly IMapper _mapper;
        private readonly IAlunoRepository _alunoRepository;
        private readonly IMediatorHandler _mediator;

        public AlunoAppService(IMapper mapper,
                                  IAlunoRepository alunoRepository,
                                  IMediatorHandler mediator
            )
        {
            _mapper = mapper;
            _alunoRepository = alunoRepository;
            _mediator = mediator;
        }

        public AlunoViewModel GetByIdAluno(int id)
        {
            return _mapper.Map<AlunoViewModel>(_alunoRepository.GetByIdAluno(id));
        }

        public AlunoViewModel GetByCPFAluno(string termo)
        {
            return _mapper.Map<AlunoViewModel>(_alunoRepository.GetByCPFAluno(termo));
        }

        public AlunoViewModel GetByCPFAlunoAsNoTracking(string termo)
        {
            return _mapper.Map<AlunoViewModel>(_alunoRepository.GetByCPFAlunoAsNoTracking(termo));
        }

        public dynamic RecuperarDropDownTipoContato()
        {
            return _alunoRepository.RecuperarDropDownTipoContato(); 
        }

        public IEnumerable<AlunoContatoViewModel> GetByAlunoContato(string termo)
        {
            var testee = _alunoRepository.GetByAlunoContato(termo);
            var teste = _mapper.Map<IEnumerable<AlunoContatoViewModel>>(testee);
            return teste;
        }

        public void Register(AlunoViewModel clienteViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewAlunoCommand>(clienteViewModel);
            _mediator.SendCommand(registerCommand);
        }

        public void Updated(AlunoViewModel alunoViewModel)
        {
            var updateCommand = _mapper.Map<UpdateAlunoCommand>(alunoViewModel);
            _mediator.SendCommand(updateCommand);
        }

        public ICollection<AlunoViewModel> GetByCodigoAluno(string codigo)
        {
            return _mapper.Map<ICollection<AlunoViewModel>>(_alunoRepository.GetByCodigoAluno(codigo));
        }

        public ICollection<AlunoViewModel> GetByTermoAluno(string termo, string campo)
        {
            return _mapper.Map<ICollection<AlunoViewModel>>(_alunoRepository.GetByTermoAluno(termo, campo));
        }


        public bool ValidaCPF(string vrCPF)
        {
            string valor = vrCPF.Replace(".", "");
            valor = valor.Replace("-", "");

            if (valor.Length != 11)
                return false;

            bool igual = true;

            for (int i = 1; i < 11 && igual; i++)
                if (valor[i] != valor[0])
                    igual = false;

            if (igual || valor == "12345678909")
                return false;

            int[] numeros = new int[11];

            for (int i = 0; i < 11; i++)
                numeros[i] = int.Parse(valor[i].ToString());

            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += (10 - i) * numeros[i];

            int resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                    return false;
            }
            else if (numeros[9] != 11 - resultado)
                return false;

            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += (11 - i) * numeros[i];

            resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                    return false;
            }
            else
                if (numeros[10] != 11 - resultado)
                return false;

            return true;
        }

    public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
