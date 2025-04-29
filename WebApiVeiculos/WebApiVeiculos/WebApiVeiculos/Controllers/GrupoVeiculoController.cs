using Microsoft.AspNetCore.Mvc;
using Serilog;
using WebApiVeiculos.Models;
using WebApiVeiculos.Services.GrupoVeiculo;
using WebApiVeiculos.Services.GrupoVeiculo;
using ILogger = Serilog.ILogger;

namespace WebApiVeiculos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrupoVeiculoController : ControllerBase
    {
        private readonly IGrupoVeiculoService _grupoService;
        private readonly ILogger _logger;

        public GrupoVeiculoController(IGrupoVeiculoService grupoService)
        {
            _grupoService = grupoService;
            _logger = Log.ForContext<GrupoVeiculoController>();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GrupoVeiculoModel>>> GetTodos()
        {
            try
            {
                var grupos = await _grupoService.BuscarTodosAsync();
                return Ok(grupos);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Erro ao buscar todos os grupos de veículos");
                return StatusCode(500, "Erro interno");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GrupoVeiculoModel>> GetPorId(int id)
        {
            try
            {
                var grupo = await _grupoService.BuscarPorIdAsync(id);
                if (grupo == null)
                    return NotFound($"Grupo com ID {id} não encontrado");

                return Ok(grupo);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Erro ao buscar grupo com ID: {Id}", id);
                return StatusCode(500, "Erro interno");
            }
        }

        [HttpPost]
        public async Task<ActionResult<GrupoVeiculoModel>> Criar(GrupoVeiculoModel grupo)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var novo = await _grupoService.CriarAsync(grupo);
                return CreatedAtAction(nameof(GetPorId), new { id = novo.Id }, novo);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Erro ao criar grupo de veículo");
                return StatusCode(500, "Erro interno");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GrupoVeiculoModel>> Atualizar(int id, GrupoVeiculoModel grupo)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var atualizado = await _grupoService.AtualizarAsync(id, grupo);
                if (atualizado == null)
                    return NotFound($"Grupo com ID {id} não encontrado");

                return Ok(atualizado);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Erro ao atualizar grupo com ID: {Id}", id);
                return StatusCode(500, "Erro interno");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            try
            {
                var sucesso = await _grupoService.DeletarAsync(id);
                if (!sucesso)
                    return NotFound($"Grupo com ID {id} não encontrado");

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Erro ao deletar grupo com ID: {Id}", id);
                return StatusCode(500, "Erro interno");
            }
        }
    }
}
