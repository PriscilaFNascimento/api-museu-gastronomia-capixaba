using Domain.ViewModels;

namespace Domain.Services.Interfaces
{
    public interface IReceitaService
    {
        Task<IEnumerable<ReceitaViewModel>> ObterReceitasAsync();
        Task<ReceitaViewModel> ObterReceitaPeloIdAsync(Guid id);
        Task InserirReceitaAsync(InserirReceitaViewModel request);
        Task AtualizarReceitaAsync(Guid id, InserirReceitaViewModel request);
        Task RemoverReceitaAsync(Guid id);
    }
}
