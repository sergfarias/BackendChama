using MediatR;
using Equinox.Domain.Commands.Aluno;
using Equinox.Domain.Core.Bus;
using Equinox.Domain.Core.Notifications;
using Equinox.Domain.Interfaces;
using Equinox.Domain.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Equinox.Domain.CommandHandlers
{
    public class AlunoCommandHandler: CommandHandler,
        IRequestHandler<RegisterNewAlunoCommand, bool>,
        IRequestHandler<UpdateAlunoCommand, bool>
    {

        private readonly IAlunoRepository _alunoRepository;
        private readonly IMediatorHandler Bus;
    
    public AlunoCommandHandler(IAlunoRepository alunoRepository, IUnitOfWork uow, IMediatorHandler bus,
                                 INotificationHandler<DomainNotification> notifications): base(uow, bus, notifications)
    {
         _alunoRepository = alunoRepository;
         Bus = bus;
    }
    
    public Task<bool> Handle(RegisterNewAlunoCommand  message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }
            
            var aluno =  new Aluno(message.Id, message.Nome, message.Email, message.DataNascimento,
                                       message.DataCadastro, message.Cpf, message.Observacao, message.Contatos);
            _alunoRepository.Add(aluno);
            Commit();

            return Task.FromResult(true);

        }

        public Task<bool> Handle(UpdateAlunoCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }
            
            var aluno = new Aluno(message.Id, message.Nome, message.Email, message.DataNascimento,
                                       message.DataCadastro, message.Cpf, message.Observacao, message.Contatos);
            _alunoRepository.Update(aluno);
            Commit();

            return Task.FromResult(true);

        }

        public void Dispose()
        {
            _alunoRepository.Dispose();
        }

    }
}
