using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configuration
{
    public class InformacaoNutricionalConfiguration : IEntityTypeConfiguration<InformacaoNutricional>
    {
        public void Configure(EntityTypeBuilder<InformacaoNutricional> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.QuantidadePorcao).IsRequired().HasColumnType("decimal(6,3)");
            builder.Property(x => x.ValorDiario).IsRequired().HasColumnType("decimal(6,3)");


            builder
                .HasOne(x => x.Receita)
                .WithMany(x => x.InformacoesNutricionais)
                .HasForeignKey(x => x.ReceitaId);
        }
    }
}
