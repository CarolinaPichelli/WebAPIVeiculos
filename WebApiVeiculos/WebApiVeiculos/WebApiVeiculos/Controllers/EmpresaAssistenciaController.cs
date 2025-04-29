using Microsoft.AspNetCore.Mvc;
using Serilog;
using WebApiVeiculos.Models;
using WebApiVeiculos.Services.EmpresaAssistencia;
using ILogger = Serilog.ILogger;

namespace WebApiVeiculos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaAssistenciaController : ControllerBase
    {
        private readonly IEmpresaAssistenciaService _empresaService;
        private readonly ILogger _logger;

        public EmpresaAssistenciaController(IEmpresaAssistenciaService empresaService)
        {
            _empresaService = empresaService;
            _logger = Log.ForContext<EmpresaAssistenciaController>();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpresaAssistenciaModel>>> GetTodos()
        {
            try
            {
                var empresas = await _empresaService.BuscarTodosAsync();
                return Ok(empresas);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Erro ao buscar todas as empresas de assistência");
                return StatusCode(500, "Erro interno");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmpresaAssistenciaModel>> GetPorId(int id)
        {
            try
            {
                var empresa = await _empresaService.BuscarPorIdAsync(id);
                if (empresa == null)
                    return NotFound($"Empresa com ID {id} não encontrada");

                return Ok(empresa);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Erro ao buscar empresa com ID: {Id}", id);
                return StatusCode(500, "Erro interno");
            }
        }

        [HttpPost]
        public async Task<ActionResult<EmpresaAssistenciaModel>> Criar(EmpresaAssistenciaModel empresa)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var novaEmpresa = await _empresaService.CriarAsync(empresa);
                return CreatedAtAction(nameof(GetPorId), new { id = novaEmpresa.Id }, novaEmpresa);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Erro ao criar empresa de assistência");
                return StatusCode(500, "Erro interno");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EmpresaAssistenciaModel>> Atualizar(int id, EmpresaAssistenciaModel empresa)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var atualizada = await _empresaService.AtualizarAsync(id, empresa);
                if (atualizada == null)
                    return NotFound($"Empresa com ID {id} não encontrada");

                return Ok(atualizada);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Erro ao atualizar empresa com ID: {Id}", id);
                return StatusCode(500, "Erro interno");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            try
            {
                var sucesso = await _empresaService.DeletarAsync(id);
                if (!sucesso)
                    return NotFound($"Empresa com ID {id} não encontrada");

                return NoContent();
            }
            catch (Exception ex)
            {   
                _logger.Error(ex, "Erro ao deletar empresa com ID: {Id}", id);
                return StatusCode(500, "Erro interno");
            }
        }
    }
}
