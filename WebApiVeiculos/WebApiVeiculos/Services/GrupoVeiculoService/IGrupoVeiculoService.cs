using WebApiVeiculos.DTOs.GrupoVeiculoDTO;

namespace WebApiVeiculos.Services.GrupoVeiculo
{
    public interface IGrupoVeiculoService
    {
        Task<List<GrupoVeiculoDTO>> GetAllAsync();
        Task<GrupoVeiculoDTO?> GetByIdAsync(int id);
        Task<GrupoVeiculoDTO> CreateAsync(GrupoVeiculoDTO dto);
        Task<GrupoVeiculoDTO?> UpdateAsync(int id, GrupoVeiculoDTO dto);
        Task<bool> DeletarAsync(int id);
    }
}
