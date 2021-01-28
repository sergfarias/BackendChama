using Equinox.Application.Interfaces;
using Equinox.Application.ViewModels;
using Equinox.Domain.Core.Bus;
using Equinox.Domain.Core.Notifications;
using Equinox.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Equinox.Services.Api.Controllers
{
    //[Authorize]
    [Route("api/")]
    public class CursoAlunoController : ApiController
    {
        private readonly ICursoAlunoAppService _cursoAlunoAppService;
      
        public CursoAlunoController(
            ICursoAlunoAppService cursoAlunoAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator): base(notifications, mediator)
        {
            _cursoAlunoAppService = cursoAlunoAppService;
        }

        [HttpPost]
        [Route("cadastro/cursoAluno")]
        public IActionResult Post([FromBody] CursoAlunoViewModel cursoAluno)
        {
            _cursoAlunoAppService.Register(cursoAluno);
            return Response(this.Notifications);
        }

    }
}
