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
            base.OnModelCreating(modelBuilder);
        }
    }
}
