using Microsoft.AspNetCore.Mvc;
using Serilog;
using WebApiVeiculos.DTOs.PlanoAssistenciaDTO;
using WebApiVeiculos.Models;
using WebApiVeiculos.Services.PlanoAssistencia;
using ILogger = Serilog.ILogger;

namespace WebApiVeiculos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanoAssistenciaController : ControllerBase
    {
        private readonly IPlanoAssistenciaService _planoService;
        private readonly ILogger _logger;

        public PlanoAssistenciaController(IPlanoAssistenciaService planoService)
        {
            _planoService = planoService;
            _logger = Log.ForContext<PlanoAssistenciaController>();
        }

        [HttpGet]
        public async Task<IActionResult> GetTodos()
        {
            try
            {
                var planos = await _planoService.BuscarTodosAsync();
                return Ok(planos);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Erro ao buscar todos os planos de assistência");
                return StatusCode(500, "Erro interno");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPorId(int id)
        {
            try
            {
                var plano = await _planoService.BuscarPorIdAsync(id);
                if (plano == null)
                    return NotFound($"Plano com ID {id} não encontrado");

                return Ok(plano);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Erro ao buscar plano com ID: {Id}", id);
                return StatusCode(500, "Erro interno");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] PlanoAssistenciaDTO plano)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var novo = await _planoService.CriarAsync(plano);
                return CreatedAtAction(nameof(GetPorId), new { id = novo.Id }, novo);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Erro ao criar plano de assistência");
                return StatusCode(500, "Erro interno");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] PlanoAssistenciaDTO plano)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var atualizado = await _planoService.AtualizarAsync(id, plano);
                if (atualizado == null)
                    return NotFound($"Plano com ID {id} não encontrado");

                return Ok(atualizado);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Erro ao atualizar plano com ID: {Id}", id);
                return StatusCode(500, "Erro interno");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            try
            {
                var sucesso = await _planoService.DeletarAsync(id);
                if (!sucesso)
                    return NotFound($"Plano com ID {id} não encontrado");

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Erro ao deletar plano com ID: {Id}", id);
                return StatusCode(500, "Erro interno");
            }
        }
    }
}
