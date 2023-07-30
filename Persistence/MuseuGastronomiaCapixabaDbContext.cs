using Data.Configuration;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class MuseuGastronomiaCapixabaDbContext : DbContext
    {
        public MuseuGastronomiaCapixabaDbContext(DbContextOptions<MuseuGastronomiaCapixabaDbContext> options) : base(options)
        {

        }

        public DbSet<Receita> Receitas { get; set; }
        public DbSet<InformacaoNutricional> InformacoesNutricionais { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.ApplyConfiguration(new ReceitaConfiguration());
            modelBuilder.ApplyConfiguration(new InformacaoNutricionalConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new ReceitaConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
