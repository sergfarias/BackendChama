using Equinox.Application.Interfaces;
using Equinox.Application.ViewModels;
using Equinox.Domain.Core.Bus;
using Equinox.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Equinox.Services.Api.Controllers
{
    //[Authorize]
    [Route("api/")]
    public class AlunoController : ApiController
    {
        private readonly IAlunoAppService _alunoAppService;

        public AlunoController(
            IAlunoAppService alunoAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator): base(notifications, mediator)
        {
            _alunoAppService = alunoAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("Aluno/AlunoId")]
        public AlunoViewModel GetByIdaluno(int idAluno)
        {
            return _alunoAppService.GetByIdAluno(idAluno);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("pesquisa/aluno")]
        public AlunoViewModel GetByCPFAluno(string Termo)
        {
            return _alunoAppService.GetByCPFAluno(Termo);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("pesquisa/tipocontato")]
        public dynamic RecuperarDropDownTipoContato()
        {
            return _alunoAppService.RecuperarDropDownTipoContato();
        }

        [HttpGet]
        [Route("pesquisa/alunocontato")]
        public IEnumerable<AlunoContatoViewModel> GetByAlunoContato(string Termo)
        {
            return _alunoAppService.GetByAlunoContato(Termo);
        }

        [HttpPost]
        [Route("cadastro/aluno")]
        public IActionResult Post([FromBody] AlunoViewModel aluno)
        {
            var cli = _alunoAppService.GetByCPFAlunoAsNoTracking(aluno.cpf);
            if (cli != null) aluno.id = cli.id;

            if (!_alunoAppService.ValidaCPF(aluno.cpf))
            {
                NotifyError("Aluno", "Rollback executado, pois o CPF é inválido.");
                return Response(this.Notifications);
            }

            if (aluno.id > 0)
            {
                _alunoAppService.Updated(aluno);
            }
            else
            {
                aluno.dataCadastro = System.DateTime.Now;
                _alunoAppService.Register(aluno);
            }
            return Response(this.Notifications);
        }

        [HttpGet]
        [Route("pesquisa/codigoaluno")]
        public ICollection<AlunoViewModel> GetByCodigo([FromQuery] string codigo)
        {
            return _alunoAppService.GetByCodigoAluno(codigo);
        }

        [HttpGet]
        [Route("pesquisa/termoaluno")]
        public ICollection<AlunoViewModel> GetByTermo([FromQuery] string termo, string campo)
        {
            return _alunoAppService.GetByTermoAluno(termo, campo);
        }

    }
}
