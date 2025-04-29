using Microsoft.EntityFrameworkCore;
using WebApiVeiculos.DataContext;
using WebApiVeiculos.Models;
using WebApiVeiculos.Services.VeiculoAssistencia;

namespace WebApiVeiculos.Services.VeiculoAssistenciaService
{
    public class VeiculoAssistenciaService : IVeiculoAssistenciaService
    {
        private readonly ApplicationDbContext _context;

        public VeiculoAssistenciaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VeiculoAssistenciaModel>> BuscarTodosAsync()
        {
            return await _context.VeiculoAssistencias
                .Include(v => v.Veiculo)
                .Include(p => p.PlanoAssistencia)
                .ToListAsync();
        }

        public async Task<VeiculoAssistenciaModel?> BuscarPorIdAsync(int id)
        {
            return await _context.VeiculoAssistencias
                .Include(v => v.Veiculo)
                .Include(p => p.PlanoAssistencia)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<VeiculoAssistenciaModel> CriarAsync(VeiculoAssistenciaModel veiculoAssistencia)
        {
            _context.VeiculoAssistencias.Add(veiculoAssistencia);
            await _context.SaveChangesAsync();
            return veiculoAssistencia;
        }

        public async Task<VeiculoAssistenciaModel?> AtualizarAsync(int id, VeiculoAssistenciaModel veiculoAssistencia)
        {
            var existente = await _context.VeiculoAssistencias.FindAsync(id);
            if (existente == null) return null;

            existente.VeiculoId = veiculoAssistencia.VeiculoId;
            existente.PlanoId = veiculoAssistencia.PlanoId;

            await _context.SaveChangesAsync();
            return existente;
        }

        public async Task<bool> DeletarAsync(int id)
        {
            var existente = await _context.VeiculoAssistencias.FindAsync(id);
            if (existente == null) return false;

            _context.VeiculoAssistencias.Remove(existente);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
