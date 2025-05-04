using WebApiVeiculos.DTOs.PlanoAssistenciaDTO;
using WebApiVeiculos.Models;

namespace WebApiVeiculos.Services.PlanoAssistencia
{
    public interface IPlanoAssistenciaService
    {
        Task<List<PlanoAssistenciaDTO>> BuscarTodosAsync();
        Task<PlanoAssistenciaDTO?> BuscarPorIdAsync(int id);
        Task<PlanoAssistenciaDTO> CriarAsync(PlanoAssistenciaDTO plano);
        Task<PlanoAssistenciaDTO?> AtualizarAsync(int id, PlanoAssistenciaDTO plano);
        Task<bool> DeletarAsync(int id);
    }
}
