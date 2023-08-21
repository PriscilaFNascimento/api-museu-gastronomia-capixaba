using Domain.ViewModels;

namespace Domain.Services.Interfaces
{
    public interface IInformacaoNutricionalService
    {
        Task<IEnumerable<InformacaoNutricionalViewModel>> ObterPorReceitaIdAsync(Guid receitaId);
    }
}
