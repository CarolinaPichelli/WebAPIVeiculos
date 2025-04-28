using WebApiVeiculos.Models;

namespace WebApiVeiculos.Services
{
    public interface IVeiculoService
    {
        Task<ServiceResponse<IEnumerable<VeiculoModel>>> GetAllAsync();
        Task<ServiceResponse<VeiculoModel>> GetByIdAsync(int id);
        Task<ServiceResponse<VeiculoModel>> CreateAsync(VeiculoModel veiculo);
        Task<ServiceResponse<bool>> UpdateAsync(VeiculoModel veiculo);
        Task<ServiceResponse<bool>> DeleteAsync(int id);
        Task<ServiceResponse<IEnumerable<VeiculoModel>>> GetByGrupoAsync(int grupoId);
    }
}
