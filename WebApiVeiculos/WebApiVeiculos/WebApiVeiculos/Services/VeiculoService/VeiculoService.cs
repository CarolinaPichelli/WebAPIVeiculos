using Microsoft.EntityFrameworkCore;
using Serilog;
using WebApiVeiculos.DataContext;
using WebApiVeiculos.Models;
using WebApiVeiculos.Services.Veiculo;
using ILogger = Serilog.ILogger;

namespace WebApiVeiculos.Services
{
    public class VeiculoService : IVeiculoService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        public VeiculoService(ApplicationDbContext context)
        {
            _context = context;
            _logger = Log.ForContext<VeiculoService>();
        }

        public async Task<IEnumerable<VeiculoModel>> BuscarTodosAsync()
        {
            try
            {
                return await _context.Veiculos
                    .Include(v => v.GrupoVeiculo)
                    .Include(v => v.VeiculoAssistencias)
                        .ThenInclude(va => va.PlanoAssistencia)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Erro ao buscar todos os veículos");
                throw;
            }
        }

        public async Task<VeiculoModel?> BuscarPorIdAsync(int id)
        {
            try
            {
                return await _context.Veiculos
                    .Include(v => v.GrupoVeiculo)
                    .Include(v => v.VeiculoAssistencias)
                        .ThenInclude(va => va.PlanoAssistencia)
                    .FirstOrDefaultAsync(v => v.Id == id);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Erro ao buscar veículo por ID: {Id}", id);
                throw;
            }
        }

        public async Task<VeiculoModel> CriarAsync(VeiculoModel veiculo)
        {
            try
            {
                _context.Veiculos.Add(veiculo);
                await _context.SaveChangesAsync();
                _logger.Information("Veículo criado com sucesso: {@Veiculo}", veiculo);
                return veiculo;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Erro ao criar veículo");
                throw;
            }
        }

        public async Task<VeiculoModel?> AtualizarAsync(int id, VeiculoModel veiculo)
        {
            try
            {
                var veiculoExistente = await _context.Veiculos.FindAsync(id);

                if (veiculoExistente == null)
                {
                    _logger.Warning("Tentativa de atualizar veículo inexistente com ID: {Id}", id);
                    return null;
                }

                veiculoExistente.Modelo = veiculo.Modelo;
                veiculoExistente.Placa = veiculo.Placa;
                veiculoExistente.GrupoId = veiculo.GrupoId;

                await _context.SaveChangesAsync();

                _logger.Information("Veículo atualizado: {@Veiculo}", veiculoExistente);
                return veiculoExistente;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Erro ao atualizar veículo com ID: {Id}", id);
                throw;
            }
        }

        public async Task<bool> DeletarAsync(int id)
        {
            try
            {
                var veiculo = await _context.Veiculos.FindAsync(id);

                if (veiculo == null)
                {
                    _logger.Warning("Tentativa de deletar veículo inexistente com ID: {Id}", id);
                    return false;
                }

                _context.Veiculos.Remove(veiculo);
                await _context.SaveChangesAsync();

                _logger.Information("Veículo deletado com sucesso: {@Veiculo}", veiculo);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Erro ao deletar veículo com ID: {Id}", id);
                throw;
            }
        }
    }
}
