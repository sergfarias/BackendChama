using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Equinox.Domain.Models;

namespace Equinox.Infra.Data.Mappings
{    
    public class AlunoContatoMap : IEntityTypeConfiguration<AlunoContato>
    {
        public void Configure(EntityTypeBuilder<AlunoContato> builder)
        {

            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.AlunoId)
                .HasColumnName("AlunoId");

            builder.Property(c => c.TipoContatoId)
                .HasColumnName("TipoContatoId");

            builder.Ignore(c => c.TipoContato);

            builder.Property(c => c.NomeContato)
                .HasColumnType("varchar(150)")
                .HasMaxLength(150)
                .IsRequired();

            builder.HasOne(cc => cc.Aluno)
           .WithMany(e=> e.AlunoContato)
           .HasForeignKey(cc => cc.AlunoId);

            builder.Ignore(c => c.CascadeMode);
            builder.Ignore(c => c.ValidationResult);
        }
    }
}
