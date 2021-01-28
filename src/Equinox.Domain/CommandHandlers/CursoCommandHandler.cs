using MediatR;
using Equinox.Domain.Commands.Curso;
using Equinox.Domain.Core.Bus;
using Equinox.Domain.Core.Notifications;
using Equinox.Domain.Interfaces;
using Equinox.Domain.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Equinox.Domain.CommandHandlers
{
    public class CursoCommandHandler: CommandHandler,
        IRequestHandler<RegisterNewCursoCommand, bool>,
        IRequestHandler<UpdateCursoCommand, bool>
    {

        private readonly ICursoRepository _cursoRepository;
        private readonly IMediatorHandler Bus;
    
    public CursoCommandHandler(ICursoRepository cursoRepository, IUnitOfWork uow, IMediatorHandler bus,
                                 INotificationHandler<DomainNotification> notifications): base(uow, bus, notifications)
    {
         _cursoRepository = cursoRepository;
         Bus = bus;
    }
    
    public Task<bool> Handle(RegisterNewCursoCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }
            
            var curso =  new Curso(message.Id, message.Nome, message.Capacidade, message.NumeroAlunos);
            _cursoRepository.Add(curso);
            Commit();

            return Task.FromResult(true);

        }

        public Task<bool> Handle(UpdateCursoCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var curso = new Curso(message.Id, message.Nome, message.Capacidade, message.NumeroAlunos); 
            _cursoRepository.Update(curso);
            Commit();

            return Task.FromResult(true);

        }

        public void Dispose()
        {
            _cursoRepository.Dispose();
        }

    }
}
