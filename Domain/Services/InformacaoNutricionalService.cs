using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using Domain.Services.Interfaces;
using Domain.ViewModels;

namespace Domain.Services
{
    public class InformacaoNutricionalService : IInformacaoNutricionalService
    {
        private readonly IInformacaoNutricionalRepository _informacaoNutricionalRepository;
        private readonly IMapper _mapper;

        public InformacaoNutricionalService(IInformacaoNutricionalRepository informacaoNutricionalRepository, IMapper mapper)
        {
            _informacaoNutricionalRepository = informacaoNutricionalRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<InformacaoNutricionalViewModel>> ObterPorReceitaIdAsync(Guid receitaId)
        {
            IEnumerable<InformacaoNutricional> entities = await _informacaoNutricionalRepository.ObterInformacoesPorReceitaIdAsync(receitaId);
        
            IEnumerable<InformacaoNutricionalViewModel> models = _mapper.Map<IEnumerable<InformacaoNutricionalViewModel>>(entities);

            return models;
        }
    }
}
