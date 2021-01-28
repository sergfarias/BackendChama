using Equinox.Domain.Dto;
using Equinox.Domain.Interfaces;
using Equinox.Domain.Models;
using Equinox.Infra.Data.Context;
using System.Linq;

namespace Equinox.Infra.Data.Repository
{
    public class CursoEstatisticaRepository : Repository<Curso>, ICursoEstatisticaRepository
    {
        protected new readonly EquinoxContext Db;

        public CursoEstatisticaRepository(EquinoxContext context):base(context)
        {
            Db = context;
        }

        public CursoEstatisticaDto Estatistica(int cursoId)
        {
            var tabela = from cursoAluno in Db.CursoAluno
                        from curso in Db.Curso.Where(x => cursoAluno.CursoId == x.Id)
                        from aluno in Db.Aluno.Where(x => cursoAluno.AlunoId == x.Id)
                        where cursoAluno.CursoId == cursoId
            select new 
               {
                   cursoId = cursoAluno.CursoId, 
                   nome = curso.Nome, 
                   dataNascimento = aluno.DataNascimento 
               };

            var saida = tabela.GroupBy(r => r.cursoId)
                    .Select(grp => new CursoEstatisticaDto
                    {
                        cursoId = grp.Key,
                        nome = grp.Max(t=> t.nome),
                        idadeMaxima = System.DateTime.Now.Year - grp.Min(t => t.dataNascimento).Year,
                        idadeMinima = System.DateTime.Now.Year - grp.Max(t => t.dataNascimento).Year,
                        mediaIdade = System.Convert.ToDecimal(grp.Average(t => (System.DateTime.Now.Year - t.dataNascimento.Year)))
                    });

            return saida.FirstOrDefault();
        }

    }
}
