using Equinox.Application.Interfaces;
using Equinox.Application.Services;
using Equinox.Domain.CommandHandlers;
using Equinox.Domain.Commands.Aluno;
using Equinox.Domain.Commands.Curso;
using Equinox.Domain.Core.Bus;
using Equinox.Domain.Core.Events;
using Equinox.Domain.Core.Notifications;
using Equinox.Domain.Interfaces;
using Equinox.Infra.CrossCutting.Bus;
using Equinox.Infra.Data.Context;
using Equinox.Infra.Data.EventSourcing;
using Equinox.Infra.Data.Repository;
using Equinox.Infra.Data.Repository.EventSourcing;
using Equinox.Infra.Data.UoW;
using Equinox.Infra.Email;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;
using Equinox.Domain.Commands.CursoAluno;

namespace Equinox.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            //ASP .NET Authorization polices
            //services.AddSingleton<IAuthorizationHandler,ClaimsRequirementHandler>();

            // Application
            services.AddScoped<IAlunoAppService, AlunoAppService>();
            services.AddScoped<ICursoAppService, CursoAppService>();
            services.AddScoped<ICursoAlunoAppService, CursoAlunoAppService>();
            services.AddScoped<ICursoEstatisticaAppService, CursoEstatisticaAppService>();


            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
           
            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewAlunoCommand, bool>, AlunoCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateAlunoCommand, bool>, AlunoCommandHandler>();

            services.AddScoped<IRequestHandler<RegisterNewCursoCommand, bool>, CursoCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateCursoCommand, bool>, CursoCommandHandler>();
            services.AddScoped<IRequestHandler<RegisterNewCursoAlunoCommand, bool>, CursoAlunoCommandHandler>();

            services.AddScoped<IRequestHandler<RegisterNewCursoAlunoCommand, bool>, CursoAlunoCommandHandler>();
            
            // Infra - Data
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<ICursoRepository, CursoRepository>();
            services.AddScoped<ICursoAlunoRepository, CursoAlunoRepository>();
            services.AddScoped<ICursoEstatisticaRepository, CursoEstatisticaRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<EquinoxContext>();

            services.AddScoped<IEmailSender, EnviarEmail>();


            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSqlRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSqlContext>();
        
        }
    }
}