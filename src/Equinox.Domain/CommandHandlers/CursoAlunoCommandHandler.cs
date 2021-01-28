using MediatR;
using Equinox.Domain.Commands.CursoAluno;
using Equinox.Domain.Core.Bus;
using Equinox.Domain.Core.Notifications;
using Equinox.Domain.Interfaces;
using Equinox.Domain.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Equinox.Domain.CommandHandlers
{
    public class CursoAlunoCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewCursoAlunoCommand, bool>
    {
        private readonly ICursoAlunoRepository _cursoAlunoRepository;
        private readonly ICursoRepository _cursoRepository;
        private readonly IAlunoRepository _alunoRepository;
        private readonly IEmailSender _emailSender;
        private readonly IMediatorHandler Bus;
    
    public CursoAlunoCommandHandler(ICursoAlunoRepository cursoAlunoRepository,
                                    ICursoRepository cursoRepository,
                                    IAlunoRepository alunoRepository,
                                    IEmailSender emailSender,
                                    IUnitOfWork uow, IMediatorHandler bus,
                                     INotificationHandler<DomainNotification> notifications): base(uow, bus, notifications)
    {
            _cursoAlunoRepository = cursoAlunoRepository;
            _cursoRepository = cursoRepository;
            _alunoRepository = alunoRepository;
            _emailSender = emailSender;
            Bus = bus;
    }
    
    public Task<bool> Handle(RegisterNewCursoAlunoCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var curso = _cursoRepository.GetById(message.CursoId);
            curso.AcrescentaNumeroAluno(); 
            if (curso.NumeroAlunos > curso.Capacidade) {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "Número de alunos ultrapassa capacidade do curso."));
                return Task.FromResult(false);
            }

            var cursoAluno = new CursoAluno(message.Id, message.CursoId, message.AlunoId, curso);  ;
            _cursoAlunoRepository.Add(cursoAluno);
            if (Commit()) {
                var aluno = _alunoRepository.GetById(message.AlunoId);
                _emailSender.Enviar(aluno.Email, "Cadastro", "Aluno " + aluno.Nome + " cadstrado no curso "+  curso.Nome + ".");
            }
            return Task.FromResult(true);
        }

        public void Dispose()
        {
            _cursoAlunoRepository.Dispose();
        }

    }
}
