using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class InformacaoNutricionalRepository : IInformacaoNutricionalRepository
    {
        private readonly MuseuGastronomiaCapixabaDbContext _dbContext;
        public InformacaoNutricionalRepository(MuseuGastronomiaCapixabaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<InformacaoNutricional>> ObterInformacoesPorReceitaIdAsync(Guid receitaId)
        {
            var query = _dbContext.InformacoesNutricionais
                                    .Where(x => x.ReceitaId == receitaId && x.Desativacao == null);

            return await query.ToListAsync();
        }

        public async Task AtualizarInformacaoNutricionalRangeAsync(IEnumerable<InformacaoNutricional> request)
        {
            _dbContext.UpdateRange(request);
            await _dbContext.SaveChangesAsync();
        }

        public async Task InserirInformacaoNutricionalRangeAsync(IEnumerable<InformacaoNutricional> request)
        {
            await _dbContext.AddRangeAsync(request);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoverInformacoesPorReceitaIdAsync(Guid receitaId)
        {
            var informacoes = _dbContext.InformacoesNutricionais
                                    .Where(x => x.ReceitaId == receitaId)
                                    .ToListAsync();

            _dbContext.RemoveRange(informacoes);
            await _dbContext.SaveChangesAsync();
        }
    }
}
