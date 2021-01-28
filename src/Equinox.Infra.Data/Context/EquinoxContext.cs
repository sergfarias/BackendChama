using Equinox.Domain.Models;
using Equinox.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace Equinox.Infra.Data.Context
{
    public  class EquinoxContext : DbContext 
    {
     
        public EquinoxContext(DbContextOptions<EquinoxContext> options) 
            : base(options)
        {
        }

        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<AlunoContato> AlunoContato { get; set; }
        public DbSet<Curso> Curso { get; set; }
        public DbSet<CursoAluno> CursoAluno { get; set; }
        public DbSet<TipoContato> TipoContato { get; set; }
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseNpgsql(config.GetConnectionString("DefaultConnection"));

            //optionsBuilder.UseNpgsql(config.GetConnectionString("DefaultConnection"),
            //   options => options.SetPostgresVersion(new Version(9, 6)));  //para versão 9.6 do PostGree

            optionsBuilder.UseLazyLoadingProxies();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AlunoMap());
            modelBuilder.ApplyConfiguration(new AlunoContatoMap());
            modelBuilder.ApplyConfiguration(new CursoMap());
            modelBuilder.ApplyConfiguration(new TipoContatoMap());
            modelBuilder.ApplyConfiguration(new CursoAlunoMap());
        }

    }

}
