using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    public class ReceitaConfiguration : IEntityTypeConfiguration<Receita>
    {
        public void Configure(EntityTypeBuilder<Receita> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Ingredientes).IsRequired().HasMaxLength(1500);
            builder.Property(x => x.ModoPreparo).IsRequired().HasMaxLength(3000);
            builder.Property(x => x.Historia).IsRequired().HasMaxLength(3000);
            builder.Property(x => x.Porcao).IsRequired().HasMaxLength(50);
            builder.Property(x => x.PorcoesReceita).IsRequired();

            builder
                .HasOne(x => x.Criador)
                .WithMany(x => x.ReceitasCriadas)
                .HasForeignKey(x => x.CriadorId);
            builder
                .HasOne(x => x.UltimoEditor)
                .WithMany(x => x.ReceitasEditadas)
                .HasForeignKey(x => x.UltimoEditorId);
        }
    }
}
