using Microsoft.EntityFrameworkCore;
using WebApiVeiculos.DataContext;
using WebApiVeiculos.Models;
using WebApiVeiculos.Services.GrupoVeiculo;

namespace WebApiVeiculos.Services
{
    public class GrupoVeiculoService : IGrupoVeiculoService
    {
        private readonly ApplicationDbContext _context;

        public GrupoVeiculoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GrupoVeiculoModel>> BuscarTodosAsync()
        {
            return await _context.GrupoVeiculos.Include(g => g.Veiculos).ToListAsync();
        }

        public async Task<GrupoVeiculoModel?> BuscarPorIdAsync(int id)
        {
            return await _context.GrupoVeiculos
                .Include(g => g.Veiculos)
                .FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task<GrupoVeiculoModel> CriarAsync(GrupoVeiculoModel grupo)
        {
            _context.GrupoVeiculos.Add(grupo);
            await _context.SaveChangesAsync();
            return grupo;
        }

        public async Task<GrupoVeiculoModel?> AtualizarAsync(int id, GrupoVeiculoModel grupo)
        {
            var existente = await _context.GrupoVeiculos.FindAsync(id);
            if (existente == null)
                return null;

            existente.Nome = grupo.Nome;
            existente.Descricao = grupo.Descricao;

            _context.GrupoVeiculos.Update(existente);
            await _context.SaveChangesAsync();
            return existente;
        }

        public async Task<bool> DeletarAsync(int id)
        {
            var grupo = await _context.GrupoVeiculos.FindAsync(id);
            if (grupo == null)
                return false;

            _context.GrupoVeiculos.Remove(grupo);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
