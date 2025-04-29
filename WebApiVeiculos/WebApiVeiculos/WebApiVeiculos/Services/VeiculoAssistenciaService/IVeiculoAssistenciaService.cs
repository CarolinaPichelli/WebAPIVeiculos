using WebApiVeiculos.Models;

namespace WebApiVeiculos.Services.VeiculoAssistencia
{
    public interface IVeiculoAssistenciaService
    {
        Task<IEnumerable<VeiculoAssistenciaModel>> BuscarTodosAsync();
        Task<VeiculoAssistenciaModel?> BuscarPorIdAsync(int id);
        Task<VeiculoAssistenciaModel> CriarAsync(VeiculoAssistenciaModel veiculoAssistencia);
        Task<VeiculoAssistenciaModel?> AtualizarAsync(int id, VeiculoAssistenciaModel veiculoAssistencia);
        Task<bool> DeletarAsync(int id);
    }
}
