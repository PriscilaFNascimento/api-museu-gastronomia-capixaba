using Domain.Entities;
using Domain.ViewModels;

namespace Domain.Repositories
{
    public interface IReceitaRepository
    {
        Task<IEnumerable<Receita>> ObterReceitasAsync(BaseRequestViewModel request);
        Task<ReceitaViewModel> ObterReceitaModelPeloIdAsync(Guid id);
        Task<Receita> ObterReceitaPeloIdAsync(Guid id);
        Task InserirReceitaAsync(Receita request);
        Task AtualizarReceitaAsync(Receita request);
    }
}
