using Equinox.Domain.Dto;
using Equinox.Domain.Interfaces;
using Equinox.Domain.Models;
using Equinox.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Equinox.Infra.Data.Repository
{
    public class CursoRepository : Repository<Curso>, ICursoRepository
    {
        protected new readonly EquinoxContext Db;

        public CursoRepository(EquinoxContext context):base(context)
        {
            Db = context;
        }

        public Curso GetByIdCurso(int id)
        {
            return DbSet.Find(id);
        }

    }
}
