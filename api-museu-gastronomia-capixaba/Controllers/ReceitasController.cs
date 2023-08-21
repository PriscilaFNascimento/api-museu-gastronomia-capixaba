using Domain.Services.Interfaces;
using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace api_museu_gastronomia_capixaba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceitasController : ControllerBase
    {
        private readonly IReceitaService _receitaService;
        public ReceitasController(IReceitaService receitaService)
        {
            _receitaService = receitaService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ReceitaListViewModel>), 200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<IEnumerable<ReceitaListViewModel>>> ListarReceitas()
        {
            try
            {
                IEnumerable<ReceitaListViewModel> response = await _receitaService.ObterReceitasAsync();
                return Ok(response);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ReceitaViewModel), 200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<ReceitaViewModel>> ObterReceita(Guid id)
        {
            try 
            { 
                ReceitaViewModel response = await _receitaService.ObterReceitaPeloIdAsync(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> InserirReceita([FromBody] InserirReceitaViewModel request)
        {
            try
            { 
                await _receitaService.InserirReceitaAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> AtualizarReceita(Guid id, [FromBody] InserirReceitaViewModel request)
        {
            try
            { 
                await _receitaService.AtualizarReceitaAsync(id, request);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> RemoverReceita(Guid id)
        {
            try
            {
                await _receitaService.RemoverReceitaAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
