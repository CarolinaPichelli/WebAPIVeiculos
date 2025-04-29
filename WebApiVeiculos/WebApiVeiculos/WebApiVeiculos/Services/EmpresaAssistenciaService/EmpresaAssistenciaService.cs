using Microsoft.EntityFrameworkCore;
using WebApiVeiculos.DataContext;
using WebApiVeiculos.Models;
using WebApiVeiculos.Services.EmpresaAssistencia;


namespace WebApiVeiculos.Services
{
    public class EmpresaAssistenciaService : IEmpresaAssistenciaService
    {
        private readonly ApplicationDbContext _context;

        public EmpresaAssistenciaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EmpresaAssistenciaModel>> BuscarTodosAsync()
        {
            return await _context.EmpresaAssistencias.ToListAsync();
        }

        public async Task<EmpresaAssistenciaModel?> BuscarPorIdAsync(int id)
        {
            return await _context.EmpresaAssistencias.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<EmpresaAssistenciaModel> CriarAsync(EmpresaAssistenciaModel empresa)
        {
            _context.EmpresaAssistencias.Add(empresa);
            await _context.SaveChangesAsync();
            return empresa;
        }

        public async Task<EmpresaAssistenciaModel?> AtualizarAsync(int id, EmpresaAssistenciaModel empresa)
        {
            var existente = await _context.EmpresaAssistencias.FindAsync(id);
            if (existente == null)
                return null;

            existente.Nome = empresa.Nome;
            existente.Endereco = empresa.Endereco;

            _context.EmpresaAssistencias.Update(existente);
            await _context.SaveChangesAsync();
            return existente;
        }

        public async Task<bool> DeletarAsync(int id)
        {
            var empresa = await _context.EmpresaAssistencias.FindAsync(id);
            if (empresa == null)
                return false;

            _context.EmpresaAssistencias.Remove(empresa);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
