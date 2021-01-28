using System;
using System.Linq;
using Equinox.Domain.Interfaces;
using Equinox.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;


namespace Equinox.Infra.Data.Repository
{
    public class Repository<TEntity>: IRepository<TEntity> where TEntity: class
    {
        protected readonly EquinoxContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(EquinoxContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        
        public virtual void Add(TEntity obj)
        {
           DbSet.Add(obj);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }


        public virtual TEntity GetById(int id)
        {
            return DbSet.Find(id);
        }

        public virtual void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }

        public virtual void Remove(int id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
