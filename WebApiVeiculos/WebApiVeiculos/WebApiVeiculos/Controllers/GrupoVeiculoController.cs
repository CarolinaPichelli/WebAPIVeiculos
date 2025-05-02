using Microsoft.AspNetCore.Mvc;
using WebApiVeiculos.DTOs.GrupoVeiculoDTO;
using WebApiVeiculos.Services.GrupoVeiculo;
using Serilog;

namespace WebApiVeiculos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GrupoVeiculoController : ControllerBase
    {
        private readonly IGrupoVeiculoService _grupoService;

        public GrupoVeiculoController(IGrupoVeiculoService grupoService)
        {
            _grupoService = grupoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var grupos = await _grupoService.GetAllAsync();
            return Ok(grupos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var grupo = await _grupoService.GetByIdAsync(id);
            if (grupo == null)
            {
                Log.Warning("GrupoVeiculo com ID {Id} não encontrado.", id);
                return NotFound();
            }

            return Ok(grupo);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] GrupoVeiculoDTO dto)
        {
            if (!ModelState.IsValid)
            {
                Log.Warning("Dados inválidos enviados para criação de GrupoVeiculo.");
                return BadRequest(ModelState);
            }

            var criado = await _grupoService.CreateAsync(dto);
            Log.Information("GrupoVeiculo criado com sucesso: {@Grupo}", criado);
            return CreatedAtAction(nameof(GetById), new { id = criado.Id }, criado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] GrupoVeiculoDTO dto)
        {
            var atualizado = await _grupoService.UpdateAsync(id, dto);
            if (atualizado == null)
            {
                Log.Warning("Tentativa de atualizar GrupoVeiculo inexistente com ID {Id}.", id);
                return NotFound();
            }

            Log.Information("GrupoVeiculo atualizado com sucesso: {@Grupo}", atualizado);
            return Ok(atualizado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletado = await _grupoService.DeletarAsync(id);
            if (!deletado)
            {
                Log.Warning("Tentativa de deletar GrupoVeiculo inexistente com ID {Id}.", id);
                return NotFound();
            }

            Log.Information("GrupoVeiculo com ID {Id} deletado com sucesso.", id);
            return NoContent();
        }
    }
}
