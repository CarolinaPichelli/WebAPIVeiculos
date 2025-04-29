using Microsoft.EntityFrameworkCore;
using WebApiVeiculos.DataContext;
using WebApiVeiculos.Models;
using WebApiVeiculos.Services.PlanoAssistencia;

namespace WebApiVeiculos.Services
{
    public class PlanoAssistenciaService : IPlanoAssistenciaService
    {
        private readonly ApplicationDbContext _context;

        public PlanoAssistenciaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PlanoAssistenciaModel>> BuscarTodosAsync()
        {
            return await _context.PlanoAssistencias.Include(p => p.EmpresaAssistencia).ToListAsync();
        }

        public async Task<PlanoAssistenciaModel?> BuscarPorIdAsync(int id)
        {
            return await _context.PlanoAssistencias
                .Include(p => p.EmpresaAssistencia)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<PlanoAssistenciaModel> CriarAsync(PlanoAssistenciaModel plano)
        {
            _context.PlanoAssistencias.Add(plano);
            await _context.SaveChangesAsync();
            return plano;
        }

        public async Task<PlanoAssistenciaModel?> AtualizarAsync(int id, PlanoAssistenciaModel plano)
        {
            var existente = await _context.PlanoAssistencias.FindAsync(id);
            if (existente == null)
                return null;

            existente.Descricao = plano.Descricao;
            existente.Cobertura = plano.Cobertura;
            existente.EmpresaId = plano.EmpresaId;

            _context.PlanoAssistencias.Update(existente);
            await _context.SaveChangesAsync();
            return existente;
        }

        public async Task<bool> DeletarAsync(int id)
        {
            var plano = await _context.PlanoAssistencias.FindAsync(id);
            if (plano == null)
                return false;

            _context.PlanoAssistencias.Remove(plano);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
