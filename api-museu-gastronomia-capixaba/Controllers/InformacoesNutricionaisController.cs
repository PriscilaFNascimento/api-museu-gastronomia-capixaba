using Domain.Services.Interfaces;
using Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_museu_gastronomia_capixaba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InformacoesNutricionaisController : ControllerBase
    {
        private readonly IInformacaoNutricionalService _informacaoNutricionalService;
        public InformacoesNutricionaisController(IInformacaoNutricionalService informacaoNutricionalService)
        {
            _informacaoNutricionalService = informacaoNutricionalService;
        }

        [HttpGet("{receitaId}")]
        [ProducesResponseType(typeof(IEnumerable<InformacaoNutricionalViewModel>), 200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<IEnumerable<InformacaoNutricionalViewModel>>> ListarInformacoesNutricionaisPorReceita(Guid receitaId)
        {
            try
            {
                IEnumerable<InformacaoNutricionalViewModel> response = await _informacaoNutricionalService.ObterPorReceitaIdAsync(receitaId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
