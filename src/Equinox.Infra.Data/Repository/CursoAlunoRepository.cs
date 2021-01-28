using Equinox.Domain.Dto;
using Equinox.Domain.Interfaces;
using Equinox.Domain.Models;
using Equinox.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Equinox.Infra.Data.Repository
{
    public class CursoAlunoRepository : Repository<CursoAluno>, ICursoAlunoRepository
    {
        protected new readonly EquinoxContext Db;

        public CursoAlunoRepository(EquinoxContext context):base(context)
        {
            Db = context;
        }

      
       
    }
}
