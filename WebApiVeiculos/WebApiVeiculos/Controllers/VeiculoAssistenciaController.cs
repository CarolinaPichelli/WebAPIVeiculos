using Microsoft.AspNetCore.Mvc;
using Serilog;
using WebApiVeiculos.DTOs.VeiculoAssistenciaDTO;
using WebApiVeiculos.Services.VeiculoAssistencia;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using WebApiVeiculos.Controllers;

namespace WebApiVeiculos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VeiculoAssistenciaController : ControllerBase
    {
        private readonly IVeiculoAssistenciaService _service;
        private readonly Serilog.ILogger _logger;

        public VeiculoAssistenciaController(IVeiculoAssistenciaService service, ILogger<VeiculoAssistenciaController> logger)
        {
            _service = service;
            _logger = Log.ForContext<VeiculoAssistenciaController>();


        }

        // GET api/veiculoassistencia
        [HttpGet]
        public async Task<IActionResult> GetTodos()
        {
            try
            {
                var lista = await _service.BuscarTodosAsync();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Erro ao buscar todos os veículos de assistência");
                return StatusCode(500, "Erro interno ao buscar os dados.");
            }
        }

        // GET api/veiculoassistencia/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPorId(int id)
        {
            try
            {
                var item = await _service.BuscarPorIdAsync(id);
                if (item == null)
                {
                    return NotFound("Veículo-assistência não encontrado.");
                }

                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Erro ao buscar veículo-assistência com ID {id}");
                return StatusCode(500, "Erro interno ao buscar o item.");
            }
        }

        // POST api/veiculoassistencia
        [HttpPost]
        public async Task<IActionResult> CriarAsync([FromBody] VeiculoAssistenciaDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // Criando o veículo-assistência
                var criado = await _service.CriarAsync(model);
                return CreatedAtAction(nameof(GetPorId), new { id = criado.Id }, criado);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Erro ao criar veículo-assistência");
                var errorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return StatusCode(500, $"Erro interno: {errorMessage}");

            }
        }

        // PUT api/veiculoassistencia/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarAsync(int id, [FromBody] VeiculoAssistenciaDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var atualizado = await _service.AtualizarAsync(id, model);
                if (atualizado == null)
                {
                    return NotFound("Veículo-assistência não encontrado para atualização.");
                }

                return Ok(atualizado);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Erro ao atualizar veículo-assistência com ID {id}");
                return StatusCode(500, "Erro interno ao atualizar o item.");
            }
        }

        // DELETE api/veiculoassistencia/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarAsync(int id)
        {
            try
            {
                var sucesso = await _service.DeletarAsync(id);
                if (!sucesso)
                {
                    return NotFound("Veículo-assistência não encontrado para exclusão.");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Erro ao excluir veículo-assistência com ID {id}");
                return StatusCode(500, "Erro interno ao excluir o item.");
            }
        }
    }
}
