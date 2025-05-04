using WebApiVeiculos.DTOs.EmpresaAssistenciaDTO;

namespace WebApiVeiculos.Services.EmpresaAssistencia
{
    public interface IEmpresaAssistenciaService
    {
        Task<IEnumerable<EmpresaAssistenciaDTO>> BuscarTodosAsync();
        Task<EmpresaAssistenciaDTO?> BuscarPorIdAsync(int id);
        Task<EmpresaAssistenciaDTO> CriarAsync(EmpresaAssistenciaDTO empresa);
        Task<EmpresaAssistenciaDTO?> AtualizarAsync(int id, EmpresaAssistenciaDTO empresa);
        Task<bool> DeletarAsync(int id);
    }
}
