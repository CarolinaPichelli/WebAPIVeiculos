using Microsoft.AspNetCore.Mvc;
using WebApiVeiculos.Models;
using WebApiVeiculos.Services;

namespace WebApiVeiculos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoService _veiculoService;

        public VeiculoController(IVeiculoService veiculoService)
        {
            _veiculoService = veiculoService;
        }

        // GET: api/veiculo
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<IEnumerable<VeiculoModel>>>> GetAllAsync()
        {
            var result = await _veiculoService.GetAllAsync();
            if (result.sucesso)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        // GET: api/veiculo/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<VeiculoModel>>> GetByIdAsync(int id)
        {
            var result = await _veiculoService.GetByIdAsync(id);
            if (result.sucesso)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        // POST: api/veiculo
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<VeiculoModel>>> CreateAsync(VeiculoModel veiculo)
        {
            var result = await _veiculoService.CreateAsync(veiculo);
            if (result.sucesso)
            {
                return CreatedAtAction(nameof(GetByIdAsync), new { id = veiculo.id }, result);
            }
            return BadRequest(result);
        }

        // PUT: api/veiculo
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<bool>>> UpdateAsync(VeiculoModel veiculo)
        {
            var result = await _veiculoService.UpdateAsync(veiculo);
            if (result.sucesso)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        // DELETE: api/veiculo/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteAsync(int id)
        {
            var result = await _veiculoService.DeleteAsync(id);
            if (result.sucesso)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        // GET: api/veiculo/grupo/{grupoId}
        [HttpGet("grupo/{grupoId}")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<VeiculoModel>>>> GetByGrupoAsync(int grupoId)
        {
            var result = await _veiculoService.GetByGrupoAsync(grupoId);
            if (result.sucesso)
            {
                return Ok(result);
            }
            return NotFound(result);
        }
    }
}
