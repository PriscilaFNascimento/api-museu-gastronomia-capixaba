using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IInformacaoNutricionalRepository
    {
        Task<IEnumerable<InformacaoNutricional>> ObterInformacoesPorReceitaIdAsync(Guid receitaId);
        Task InserirInformacaoNutricionalRangeAsync(IEnumerable<InformacaoNutricional> request);
        Task AtualizarInformacaoNutricionalRangeAsync(IEnumerable<InformacaoNutricional> request);
        Task RemoverInformacoesPorReceitaIdAsync(Guid receitaId);
    }
}
