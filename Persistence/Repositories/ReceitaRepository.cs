using Domain.Entities;
using Domain.Repositories;
using Domain.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class ReceitaRepository : IReceitaRepository
    {
        private readonly MuseuGastronomiaCapixabaDbContext _dbContext;

        public ReceitaRepository(MuseuGastronomiaCapixabaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Receita>> ObterReceitasAsync(BaseRequestViewModel request)
        {
            var query = _dbContext.Receitas
                        .AsQueryable()
                        .Where(x => x.Desativacao == null);

            if(request.OrderByRegistro)
            {
                query = query.OrderByDescending(x => x.Registro);
            }
            else
            {
                query = query.OrderBy(x => x.Nome);
            }

            query = query.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize);

            return await query.ToListAsync();
        }

        public async Task<ReceitaViewModel> ObterReceitaModelPeloIdAsync(Guid id)
        {

            var query = (from r in _dbContext.Receitas
                         join u in _dbContext.Usuarios on r.CriadorId equals u.Id
                         join ed in _dbContext.Usuarios on r.UltimoEditorId equals ed.Id
                         select new ReceitaViewModel()
                         {
                             Id = r.Id,
                             Nome = r.Nome,
                             UriImagem = r.UriImagem,
                             Ingredientes = r.Ingredientes,
                             ModoPreparo = r.ModoPreparo,
                             Historia = r.Historia,
                             Porcao = r.Porcao,
                             UnidadeMedidaPorcao = r.UnidadeMedidaPorcao,
                             Rendimento = r.Rendimento,
                             UnidadeMedidaRendimento = r.UnidadeMedidaRendimento,
                             TempoPreparo = r.TempoPreparo,
                             UnidadeTempoPreparo = r.UnidadeTempoPreparo,
                             PorcoesReceita = r.PorcoesReceita,
                             NomeCriador = u.Nome,
                             CriadorId = u.Id,
                             NomeEditor = ed.Nome,
                             EditorId = ed.Id,
                             Registro = r.Registro,
                             Atualizacao = r.Atualizacao,
                             Desativacao = r.Desativacao
                         })
                        .AsQueryable()
                        .Where(x => x.Desativacao == null && x.Id == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Receita> ObterReceitaPeloIdAsync(Guid id)
        {
            return await _dbContext.Receitas.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task InserirReceitaAsync(Receita request)
        {
            await _dbContext.AddAsync(request);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AtualizarReceitaAsync(Receita request)
        {
            request.Atualizacao = DateTime.Now;
            _dbContext.Update(request);
            await _dbContext.SaveChangesAsync();
        }
    }
}
