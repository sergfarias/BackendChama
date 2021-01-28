using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Equinox.Domain.Models;

namespace Equinox.Infra.Data.Mappings
{    
    public class AlunoMap : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {

            builder.Property(c => c.Id)
            .HasColumnName("Id");

            builder.Property(c => c.Nome)
            .HasColumnType("varchar(150)")
            .HasMaxLength(150)
            .IsRequired(false);

            builder.Property(c => c.Email)
            .HasColumnType("varchar(150)")
            .HasMaxLength(150)
            .IsRequired(false);

            builder.Property(c => c.DataNascimento)
           .HasColumnType("timestamp")
           .IsRequired(true);


            builder.Property(c => c.DataCadastro)
            .HasColumnType("timestamp")
            .IsRequired(false);

            builder.Property(c => c.Cpf)
            .HasColumnType("varchar(20)")
            .HasMaxLength(20)
            .IsRequired();

            builder.Property(c => c.Observacao)
           .HasColumnType("varchar(250)")
           .HasMaxLength(250)
           .IsRequired(false);

            builder.Ignore(c => c.Curso);


            builder.Ignore(c => c.CascadeMode);
            builder.Ignore(c => c.ValidationResult);
        }
    }
}
