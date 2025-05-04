using WebApiVeiculos.DTOs.VeiculoAssistenciaDTO;
using WebApiVeiculos.Models;

namespace WebApiVeiculos.Services.VeiculoAssistencia
{
    public interface IVeiculoAssistenciaService
    {
        Task<List<VeiculoAssistenciaDTO>> BuscarTodosAsync();
        Task<VeiculoAssistenciaDTO?> BuscarPorIdAsync(int id);
        Task<VeiculoAssistenciaDTO> CriarAsync(VeiculoAssistenciaDTO veiculoAssistencia);
        Task<VeiculoAssistenciaDTO?> AtualizarAsync(int id, VeiculoAssistenciaDTO veiculoAssistencia);
        Task<bool> DeletarAsync(int id);
    }
}
