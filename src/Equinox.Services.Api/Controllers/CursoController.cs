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
    public class CursoController : ApiController
    {
        private readonly ICursoAppService _cursoAppService;

        public CursoController(
            ICursoAppService cursoAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator): base(notifications, mediator)
        {
            _cursoAppService = cursoAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("Curso/CursoId")]
        public CursoViewModel GetByIdCurso(int idCurso)
        {
            return _cursoAppService.GetByIdCurso(idCurso);
        }

        [HttpPost]
        [Route("cadastro/curso")]
        public IActionResult Post([FromBody] CursoViewModel curso)
        {
            if (curso.id > 0)
            {
                _cursoAppService.Updated(curso);
            }
            else
            {
                _cursoAppService.Register(curso);
            }
            return Response(this.Notifications);
        }
       
    }
}
