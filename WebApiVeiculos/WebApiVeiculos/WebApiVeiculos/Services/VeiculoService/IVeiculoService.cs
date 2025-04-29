using WebApiVeiculos.Models;

namespace WebApiVeiculos.Services.Veiculo
{
    public interface IVeiculoService
    {
        Task<IEnumerable<VeiculoModel>> BuscarTodosAsync();
        Task<VeiculoModel?> BuscarPorIdAsync(int id);
        Task<VeiculoModel> CriarAsync(VeiculoModel veiculo);
        Task<VeiculoModel?> AtualizarAsync(int id, VeiculoModel veiculo);
        Task<bool> DeletarAsync(int id);
    }
}
