using WebApiVeiculos.Models;

namespace WebApiVeiculos.Services.EmpresaAssistencia
{
    public interface IEmpresaAssistenciaService
    {
        Task<IEnumerable<EmpresaAssistenciaModel>> BuscarTodosAsync();
        Task<EmpresaAssistenciaModel?> BuscarPorIdAsync(int id);
        Task<EmpresaAssistenciaModel> CriarAsync(EmpresaAssistenciaModel empresa);
        Task<EmpresaAssistenciaModel?> AtualizarAsync(int id, EmpresaAssistenciaModel empresa);
        Task<bool> DeletarAsync(int id);
    }
}
