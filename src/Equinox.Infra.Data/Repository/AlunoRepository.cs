using Equinox.Domain.Dto;
using Equinox.Domain.Interfaces;
using Equinox.Domain.Models;
using Equinox.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Equinox.Infra.Data.Repository
{
    public class AlunoRepository : Repository<Aluno>, IAlunoRepository
    {
        protected new readonly EquinoxContext Db;

        public AlunoRepository(EquinoxContext context):base(context)
        {
            Db = context;
        }

        public Aluno GetByIdAluno(int id)
        {
            return DbSet.Find(id);
        }

        public Aluno GetByCPFAluno(string termo)
        {
            return DbSet.Where(c=> c.Cpf.Contains(termo)).FirstOrDefault() ;
        }

        public Aluno GetByCPFAlunoAsNoTracking(string termo)
        {
            return DbSet.Where(c => c.Cpf.Contains(termo)).AsNoTracking().FirstOrDefault();
        }

        public ICollection<Aluno> GetByCodigoAluno(string codigo)
        {
            int.TryParse(codigo, out int ID);

            var alunos = from aluno in Db.Aluno
                           where aluno.Id == ID || aluno.Cpf == codigo
                           select aluno;

            return alunos.ToList();
        }

        public ICollection<Aluno> GetByTermoAluno(string termo, string campo = null)
        {
            ICollection<Aluno> alunos = null;

            termo = termo.Trim().ToUpper();

            if (campo == "2")
            {
                alunos = (from aluno in Db.Aluno
                            where aluno.Nome.ToUpper().Trim().Contains(termo)
                            //|| aluno.NM_FANTASIA.ToUpper().Trim().Contains(Termo) )
                            select aluno).Take(100).ToList();
            }
            if (campo == "4")
            {
                alunos = (from aluno in Db.Aluno
                           from clicontato in Db.AlunoContato.Where(e => aluno.Id == e.AlunoId)
                           where clicontato.NomeContato.Contains(termo) 
                           select aluno).ToList();
            }

            return alunos;

        }

        
        public IEnumerable<AlunoContatoDto> GetByAlunoContato(string Termo)
        {
            var query = from aluno in Db.Aluno
                        from alunocontato in Db.AlunoContato.Where(x => aluno.Id == x.AlunoId)
                        where aluno.Cpf == Termo
                        select new AlunoContatoDto
                        {
                          id_contato =   alunocontato.Id,
                          id_aluno =  alunocontato.AlunoId,
                          id_tipo_contato =  alunocontato.TipoContatoId,
                          ds_contato =  alunocontato.NomeContato
                        };

            return query.ToList();
        }

        public dynamic RecuperarDropDownTipoContato()
        {
            var query = from tpContato in Db.TipoContato
                        orderby tpContato.Id ascending
                        select new
                        {
                            id_tipo_contato = tpContato.Id,
                            ds_tipo_contato = tpContato.Nome
                        };

            return query.ToList();
        }

      
    }
}
