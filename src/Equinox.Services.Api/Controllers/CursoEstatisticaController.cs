using Equinox.Application.Interfaces;
using Equinox.Application.ViewModels;
using Equinox.Domain.Core.Bus;
using Equinox.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Equinox.Services.Api.Controllers
{
    //[Authorize]
    [Route("api/")]
    public class CursoEstatisticaController : ApiController
    {
        private readonly ICursoEstatisticaAppService _cursoEstatisticaAppService;

        public CursoEstatisticaController(
            ICursoEstatisticaAppService cursoEstatisticaAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator): base(notifications, mediator)
        {
            _cursoEstatisticaAppService = cursoEstatisticaAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("pesquisa/estatistica")]
        public CursoEstatisticaViewModel Estatistica(int cursoId)
        {
            return _cursoEstatisticaAppService.Estatistica(cursoId);
        }

    }
}
