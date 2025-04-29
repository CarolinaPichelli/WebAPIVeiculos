using WebApiVeiculos.Models;

namespace WebApiVeiculos.Services.PlanoAssistencia
{
    public interface IPlanoAssistenciaService
    {
        Task<IEnumerable<PlanoAssistenciaModel>> BuscarTodosAsync();
        Task<PlanoAssistenciaModel?> BuscarPorIdAsync(int id);
        Task<PlanoAssistenciaModel> CriarAsync(PlanoAssistenciaModel plano);
        Task<PlanoAssistenciaModel?> AtualizarAsync(int id, PlanoAssistenciaModel plano);
        Task<bool> DeletarAsync(int id);
    }
}
