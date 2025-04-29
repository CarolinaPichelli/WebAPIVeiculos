using Microsoft.AspNetCore.Mvc;
using Serilog;
using WebApiVeiculos.Models;
using WebApiVeiculos.Services.VeiculoAssistencia;
using ILogger = Serilog.ILogger;

namespace WebApiVeiculos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoAssistenciaController : ControllerBase
    {
        private readonly IVeiculoAssistenciaService _service;
        private readonly ILogger _logger;

        public VeiculoAssistenciaController(IVeiculoAssistenciaService service)
        {
            _service = service;
            _logger = Log.ForContext<VeiculoAssistenciaController>();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VeiculoAssistenciaModel>>> GetTodos()
        {
            try
            {
                var lista = await _service.BuscarTodosAsync();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Erro ao buscar todos os veículos de assistência");
                return StatusCode(500, "Erro interno");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VeiculoAssistenciaModel>> GetPorId(int id)
        {
            try
            {
                var item = await _service.BuscarPorIdAsync(id);
                if (item == null)
                    return NotFound($"ID {id} não encontrado");

                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Erro ao buscar item ID {Id}", id);
                return StatusCode(500, "Erro interno");
            }
        }

        [HttpPost]
        public async Task<ActionResult<VeiculoAssistenciaModel>> Criar(VeiculoAssistenciaModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var criado = await _service.CriarAsync(model);
                return CreatedAtAction(nameof(GetPorId), new { id = criado.Id }, criado);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Erro ao criar veículo-assistência");
                return StatusCode(500, "Erro interno");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<VeiculoAssistenciaModel>> Atualizar(int id, VeiculoAssistenciaModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var atualizado = await _service.AtualizarAsync(id, model);
                if (atualizado == null)
                    return NotFound($"ID {id} não encontrado");

                return Ok(atualizado);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Erro ao atualizar ID {Id}", id);
                return StatusCode(500, "Erro interno");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            try
            {
                var sucesso = await _service.DeletarAsync(id);
                if (!sucesso)
                    return NotFound($"ID {id} não encontrado");

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Erro ao deletar ID {Id}", id);
                return StatusCode(500, "Erro interno");
            }
        }
    }
}
