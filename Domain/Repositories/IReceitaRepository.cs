using Domain.Entities;
using Domain.ViewModels;

namespace Domain.Repositories
{
    public interface IReceitaRepository
    {
        Task<IEnumerable<ReceitaViewModel>> ObterReceitasAsync();
        Task<ReceitaViewModel> ObterReceitaModelPeloIdAsync(Guid id);
        Task<Receita> ObterReceitaPeloIdAsync(Guid id);
        Task InserirReceitaAsync(Receita request);
        Task AtualizarReceitaAsync(Receita request);
    }
}
