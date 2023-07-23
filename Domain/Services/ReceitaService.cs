using Domain.Entities;
using Domain.Repositories;
using Domain.Services.Interfaces;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ReceitaService : IReceitaService
    {
        private readonly IReceitaRepository _receitaRepository;

        public ReceitaService(IReceitaRepository receitaRepository)
        {
            _receitaRepository = receitaRepository;
        }

        public async Task<IEnumerable<ReceitaViewModel>> ObterReceitasAsync()
        {
            IEnumerable<ReceitaViewModel> models = await _receitaRepository.ObterReceitasAsync();
            return models;
        }

        public async Task<ReceitaViewModel> ObterReceitaPeloIdAsync(Guid id)
        {
            ReceitaViewModel model = await _receitaRepository.ObterReceitaModelPeloIdAsync(id);
            return model;
        }

        public Task AtualizarReceitaAsync(Guid id, InserirReceitaViewModel request)
        {
            throw new NotImplementedException();
        }

        public Task InserirReceitaAsync(InserirReceitaViewModel request)
        {
            throw new NotImplementedException();
        }

        public async Task RemoverReceitaAsync(Guid id)
        {
            Receita receita = await _receitaRepository.ObterReceitaPeloIdAsync(id);
            receita.Desativacao = DateTime.Now;
            await _receitaRepository.AtualizarReceitaAsync(receita);
        }
    }
}
