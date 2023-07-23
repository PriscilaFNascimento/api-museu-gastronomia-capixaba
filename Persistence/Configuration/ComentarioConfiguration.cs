using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    public class ComentarioConfiguration : IEntityTypeConfiguration<Comentario>
    {
        public void Configure(EntityTypeBuilder<Comentario> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Conteudo).IsRequired().HasMaxLength(500);

            builder
                .HasOne(x => x.Comentarista)
                .WithMany(x => x.Comentarios)
                .HasForeignKey(x => x.ComentaristaId);
            builder
                .HasOne(x => x.Receita)
                .WithMany(x => x.Comentarios)
                .HasForeignKey(x => x.ReceitaId);
        }
    }
}
