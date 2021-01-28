using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Equinox.Domain.Models;

namespace Equinox.Infra.Data.Mappings
{    
    public class CursoAlunoMap : IEntityTypeConfiguration<CursoAluno>
    {
        public void Configure(EntityTypeBuilder<CursoAluno> builder)
        {

            builder.Property(c => c.Id)
            .HasColumnName("Id");

            builder.Property(c => c.CursoId);

            builder.Property(c => c.AlunoId);

            builder.Ignore(c => c.Aluno);
            builder.Ignore(c => c.Curso);

            builder.Ignore(c => c.CascadeMode);
            builder.Ignore(c => c.ValidationResult);
        }
    }
}
