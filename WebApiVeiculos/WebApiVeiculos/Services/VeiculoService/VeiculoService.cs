using Microsoft.EntityFrameworkCore;
using Serilog;
using WebApiVeiculos.DataContext;
using WebApiVeiculos.DTOs.VeiculoDTO;
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

        public async Task<IEnumerable<VeiculoDTO>> BuscarTodosAsync()
        {
            try
            {
                var veiculos = await _context.Veiculos.ToListAsync();

                return veiculos.Select(v => new VeiculoDTO
                {
                    Id = v.Id,
                    Modelo = v.Modelo,
                    Placa = v.Placa,
                    GrupoId = v.GrupoId
                });
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Erro ao buscar todos os veículos");
                throw new Exception("Erro interno ao buscar veículos");
            }
        }

        public async Task<VeiculoDTO?> BuscarPorIdAsync(int id)
        {
            try
            {
                var veiculo = await _context.Veiculos
                    .AsNoTracking()
                    .Include(v => v.GrupoVeiculo)
                    .FirstOrDefaultAsync(v => v.Id == id);

                return veiculo == null ? null : MapearParaDTO(veiculo);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Erro ao buscar veículo por ID: {Id}", id);
                throw new Exception("Erro interno ao buscar veículo por ID");
            }
        }

        public async Task<VeiculoDTO> CriarAsync(VeiculoDTO veiculoDto)
        {
            try
            {
                var veiculo = new VeiculoModel
                {
                    Modelo = veiculoDto.Modelo,
                    Placa = veiculoDto.Placa,
                    GrupoId = veiculoDto.GrupoId
                };

                _context.Veiculos.Add(veiculo);
                await _context.SaveChangesAsync();

                _logger.Information("Veículo criado: {@Veiculo}", veiculo);
                return MapearParaDTO(veiculo);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Erro ao criar veículo");
                throw new Exception("Erro interno ao criar veículo");
            }
        }

        public async Task<VeiculoDTO?> AtualizarAsync(int id, VeiculoDTO veiculoDto)
        {
            try
            {
                var veiculo = await _context.Veiculos.FindAsync(id);
                if (veiculo == null)
                {
                    _logger.Warning("Veículo com ID {Id} não encontrado para atualização", id);
                    return null;
                }

                veiculo.Modelo = veiculoDto.Modelo;
                veiculo.Placa = veiculoDto.Placa;
                veiculo.GrupoId = veiculoDto.GrupoId;

                await _context.SaveChangesAsync();

                _logger.Information("Veículo atualizado: {@Veiculo}", veiculo);
                return MapearParaDTO(veiculo);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Erro ao atualizar veículo com ID {Id}", id);
                throw new Exception("Erro interno ao atualizar veículo");
            }
        }

        public async Task<bool> DeletarAsync(int id)
        {
            try
            {
                var veiculo = await _context.Veiculos.FindAsync(id);
                if (veiculo == null)
                {
                    _logger.Warning("Veículo com ID {Id} não encontrado para exclusão", id);
                    return false;
                }

                _context.Veiculos.Remove(veiculo);
                await _context.SaveChangesAsync();

                _logger.Information("Veículo deletado: {@Veiculo}", veiculo);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Erro ao deletar veículo com ID {Id}", id);
                throw new Exception("Erro interno ao deletar veículo");
            }
        }

        private VeiculoDTO MapearParaDTO(VeiculoModel veiculo)
        {
            return new VeiculoDTO
            {
                Id = veiculo.Id,
                Modelo = veiculo.Modelo,
                Placa = veiculo.Placa,
                GrupoId = veiculo.GrupoId
            };
        }
    }
}