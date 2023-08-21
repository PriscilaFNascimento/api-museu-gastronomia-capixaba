using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using Domain.Services.Interfaces;
using Domain.ViewModels;

namespace Domain.Services
{
    public class ReceitaService : IReceitaService
    {
        private readonly IReceitaRepository _receitaRepository;
        private readonly IInformacaoNutricionalRepository _informacaoNutricionalRepository;
        private readonly IMapper _mapper;

        public ReceitaService(IReceitaRepository receitaRepository, IInformacaoNutricionalRepository informacaoNutricionalRepository, IMapper mapper)
        {
            _receitaRepository = receitaRepository;
            _informacaoNutricionalRepository = informacaoNutricionalRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReceitaListViewModel>> ObterReceitasAsync()
        {
            IEnumerable<Receita> entities = await _receitaRepository.ObterReceitasAsync();

            IEnumerable<ReceitaListViewModel> models = _mapper.Map<IEnumerable<ReceitaListViewModel>>(entities);

            return models;
        }

        public async Task<ReceitaViewModel> ObterReceitaPeloIdAsync(Guid id)
        {
            ReceitaViewModel model = await _receitaRepository.ObterReceitaModelPeloIdAsync(id);
            return model;
        }

        public async Task InserirReceitaAsync(InserirReceitaViewModel request)
        {
            Receita novaReceita = _mapper.Map<Receita>(request);
            novaReceita.CriadorId = Guid.Parse("36752bc4-6c13-4624-bff4-48ee97f129da");
            novaReceita.UltimoEditorId = Guid.Parse("36752bc4-6c13-4624-bff4-48ee97f129da");

            IEnumerable<InformacaoNutricional> informacoesNutricionais = _mapper.Map<IEnumerable<InformacaoNutricional>>(request.InformacoesNutricionais);

            foreach (var informacaoNutricional in informacoesNutricionais)
            {
                informacaoNutricional.ReceitaId = novaReceita.Id;
            }

            await _receitaRepository.InserirReceitaAsync(novaReceita);
            await _informacaoNutricionalRepository.InserirInformacaoNutricionalRangeAsync(informacoesNutricionais);
        }

        public async Task AtualizarReceitaAsync(Guid id, InserirReceitaViewModel request)
        {
            Receita receitaAtualizada = await _receitaRepository.ObterReceitaPeloIdAsync(id);
            _mapper.Map(request, receitaAtualizada);

            await _receitaRepository.AtualizarReceitaAsync(receitaAtualizada);

            await _informacaoNutricionalRepository.RemoverInformacoesPorReceitaIdAsync(id);

            IEnumerable<InformacaoNutricional> informacoesNutricionais = _mapper.Map<IEnumerable<InformacaoNutricional>>(request.InformacoesNutricionais);

            foreach (var informacaoNutricional in informacoesNutricionais)
            {
                informacaoNutricional.ReceitaId = receitaAtualizada.Id;
            }

            await _informacaoNutricionalRepository.InserirInformacaoNutricionalRangeAsync(informacoesNutricionais);
        }

        public async Task RemoverReceitaAsync(Guid id)
        {
            Receita receita = await _receitaRepository.ObterReceitaPeloIdAsync(id);
            receita.Desativacao = DateTime.Now;
            await _receitaRepository.AtualizarReceitaAsync(receita);
        }
    }
}
