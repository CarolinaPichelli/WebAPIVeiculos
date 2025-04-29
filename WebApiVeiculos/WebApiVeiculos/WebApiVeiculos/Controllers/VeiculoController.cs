using Microsoft.AspNetCore.Mvc;
using WebApiVeiculos.Models;
using WebApiVeiculos.Services;
using Serilog;
using WebApiVeiculos.Services.Veiculo;
using ILogger = Serilog.ILogger;

namespace WebApiVeiculos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoService _veiculoService;
        private readonly ILogger _logger;

        public VeiculoController(IVeiculoService veiculoService)
        {
            _veiculoService = veiculoService;
            _logger = Log.ForContext<VeiculoController>();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VeiculoModel>>> GetTodos()
        {
            try
            {
                var veiculos = await _veiculoService.BuscarTodosAsync();
                return Ok(veiculos);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Erro ao buscar todos os veículos");
                return StatusCode(500, "Erro interno ao buscar veículos");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VeiculoModel>> GetPorId(int id)
        {
            try
            {
                var veiculo = await _veiculoService.BuscarPorIdAsync(id);
                if (veiculo == null)
                {
                    return NotFound($"Veículo com ID {id} não encontrado");
                }
                return Ok(veiculo);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Erro ao buscar veículo por ID: {Id}", id);
                return StatusCode(500, "Erro interno ao buscar veículo");
            }
        }

        [HttpPost]
        public async Task<ActionResult<VeiculoModel>> Criar(VeiculoModel veiculo)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var novoVeiculo = await _veiculoService.CriarAsync(veiculo);
                return CreatedAtAction(nameof(GetPorId), new { id = novoVeiculo.Id }, novoVeiculo);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Erro ao criar veículo");
                return StatusCode(500, "Erro interno ao criar veículo");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<VeiculoModel>> Atualizar(int id, VeiculoModel veiculo)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var veiculoAtualizado = await _veiculoService.AtualizarAsync(id, veiculo);
                if (veiculoAtualizado == null)
                    return NotFound($"Veículo com ID {id} não encontrado");

                return Ok(veiculoAtualizado);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Erro ao atualizar veículo com ID: {Id}", id);
                return StatusCode(500, "Erro interno ao atualizar veículo");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            try
            {
                var resultado = await _veiculoService.DeletarAsync(id);
                if (!resultado)
                    return NotFound($"Veículo com ID {id} não encontrado");

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Erro ao deletar veículo com ID: {Id}", id);
                return StatusCode(500, "Erro interno ao deletar veículo");
            }
        }
    }
}