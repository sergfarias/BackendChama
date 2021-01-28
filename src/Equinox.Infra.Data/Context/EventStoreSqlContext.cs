using Equinox.Domain.Models;
using Equinox.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Equinox.Domain.Core.Events;

namespace Equinox.Infra.Data.Context
{
    public  class EventStoreSqlContext : DbContext 
    {
     
        public EventStoreSqlContext(
            DbContextOptions<EventStoreSqlContext> options) 
            : base(options)
        {
        }

        public DbSet<StoredEvent> StoredEvent { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseNpgsql(config.GetConnectionString("DefaultConnection"));
            //optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new StoredEventMap());

            base.OnModelCreating(modelBuilder);



        }

    }

}
