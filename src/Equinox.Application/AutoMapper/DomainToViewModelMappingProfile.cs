using AutoMapper;
using Equinox.Application.ViewModels;
using Equinox.Domain.Dto;
using Equinox.Domain.Models;
using System.Collections.Generic;

namespace Equinox.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Aluno, AlunoViewModel>();
            CreateMap<AlunoContatoDto, AlunoContatoViewModel>();
            CreateMap<CursoEstatisticaDto, CursoEstatisticaViewModel>();
        }
    }
}
