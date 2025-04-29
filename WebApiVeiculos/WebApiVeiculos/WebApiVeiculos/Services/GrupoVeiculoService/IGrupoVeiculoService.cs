using WebApiVeiculos.Models;

namespace WebApiVeiculos.Services.GrupoVeiculo
{
    public interface IGrupoVeiculoService
    {
        Task<IEnumerable<GrupoVeiculoModel>> BuscarTodosAsync();
        Task<GrupoVeiculoModel?> BuscarPorIdAsync(int id);
        Task<GrupoVeiculoModel> CriarAsync(GrupoVeiculoModel grupo);
        Task<GrupoVeiculoModel?> AtualizarAsync(int id, GrupoVeiculoModel grupo);
        Task<bool> DeletarAsync(int id);
    }
}
