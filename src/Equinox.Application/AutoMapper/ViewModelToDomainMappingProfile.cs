using AutoMapper;
using Equinox.Application.ViewModels;
using Equinox.Domain.Commands.CursoAluno;
using Equinox.Domain.Commands.Aluno;
using Equinox.Domain.Commands.Curso;
using Equinox.Domain.Models;
using System.Collections.Generic;

namespace Equinox.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
          
            #region Cliente
            CreateMap<AlunoViewModel, Aluno>();
            CreateMap<AlunoContatoViewModel, AlunoContato>()
                .ConstructUsing(c => new AlunoContato(c.id_contato,c.ds_contato, c.id_tipo_contato, c.id_cliente, null));
            CreateMap<AlunoViewModel, RegisterNewAlunoCommand>();
            CreateMap<AlunoViewModel, UpdateAlunoCommand>();
            #endregion

            #region CursoAluno
            CreateMap<CursoAlunoViewModel, RegisterNewCursoAlunoCommand>();
            #endregion

            #region Curso
            CreateMap<CursoViewModel, RegisterNewCursoCommand>();
            #endregion
        }
    }
}
