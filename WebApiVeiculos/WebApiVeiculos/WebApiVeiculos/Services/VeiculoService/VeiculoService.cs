using Microsoft.EntityFrameworkCore;
using Serilog;
using WebApiVeiculos.DataContext;
using WebApiVeiculos.Models;

namespace WebApiVeiculos.Services
{
    public class VeiculoService : IVeiculoService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<VeiculoService> _logger;

        public VeiculoService(ApplicationDbContext context, ILogger<VeiculoService> logger)
        {
            _context = context;
            _logger = logger;  // Injeção do ILogger
        }

        public async Task<ServiceResponse<IEnumerable<VeiculoModel>>> GetAllAsync()
        {
            var response = new ServiceResponse<IEnumerable<VeiculoModel>>();
            try
            {
                _logger.LogInformation("Tentando recuperar todos os veículos.");
                response.dados = await _context.Veiculos.Include(v => v.GrupoVeiculo).ToListAsync();
                response.sucesso = true;
                response.mensagem = "Veículos encontrados com sucesso.";
                _logger.LogInformation("Veículos recuperados com sucesso.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao recuperar veículos.");
                response.sucesso = false;
                response.mensagem = $"Erro ao recuperar veículos: {ex.Message}";
            }
            return response;
        }

        public async Task<ServiceResponse<VeiculoModel>> GetByIdAsync(int id)
        {
            var response = new ServiceResponse<VeiculoModel>();
            try
            {
                _logger.LogInformation("Tentando recuperar veículo com ID {VeiculoId}.", id);
                var veiculo = await _context.Veiculos.Include(v => v.GrupoVeiculo).FirstOrDefaultAsync(v => v.id == id);

                if (veiculo == null)
                {
                    _logger.LogWarning("Veículo com ID {VeiculoId} não encontrado.", id);
                    response.sucesso = false;
                    response.mensagem = "Veículo não encontrado.";
                }
                else
                {
                    response.dados = veiculo;
                    response.sucesso = true;
                    response.mensagem = "Veículo encontrado com sucesso.";
                    _logger.LogInformation("Veículo com ID {VeiculoId} encontrado.", id);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao recuperar o veículo com ID {VeiculoId}.", id);
                response.sucesso = false;
                response.mensagem = $"Erro ao recuperar o veículo: {ex.Message}";
            }
            return response;
        }

        public async Task<ServiceResponse<VeiculoModel>> CreateAsync(VeiculoModel veiculo)
        {
            var response = new ServiceResponse<VeiculoModel>();
            try
            {
                _logger.LogInformation("Tentando criar um novo veículo.");
                _context.Veiculos.Add(veiculo);
                await _context.SaveChangesAsync();

                response.dados = veiculo;
                response.sucesso = true;
                response.mensagem = "Veículo criado com sucesso.";
                _logger.LogInformation("Veículo criado com sucesso: {VeiculoId}.", veiculo.id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao criar veículo.");
                response.sucesso = false;
                response.mensagem = $"Erro ao criar veículo: {ex.Message}";
            }
            return response;
        }

        public async Task<ServiceResponse<bool>> UpdateAsync(VeiculoModel veiculo)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                _logger.LogInformation("Tentando atualizar o veículo com ID {VeiculoId}.", veiculo.id);
                _context.Veiculos.Update(veiculo);
                await _context.SaveChangesAsync();

                response.dados = true;
                response.sucesso = true;
                response.mensagem = "Veículo atualizado com sucesso.";
                _logger.LogInformation("Veículo com ID {VeiculoId} atualizado com sucesso.", veiculo.id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar o veículo com ID {VeiculoId}.", veiculo.id);
                response.dados = false;
                response.sucesso = false;
                response.mensagem = $"Erro ao atualizar veículo: {ex.Message}";
            }
            return response;
        }

        public async Task<ServiceResponse<bool>> DeleteAsync(int id)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                _logger.LogInformation("Tentando deletar o veículo com ID {VeiculoId}.", id);
                var veiculo = await _context.Veiculos.FindAsync(id);
                if (veiculo == null)
                {
                    _logger.LogWarning("Veículo com ID {VeiculoId} não encontrado.", id);
                    response.sucesso = false;
                    response.mensagem = "Veículo não encontrado.";
                    response.dados = false;
                    return response;
                }

                _context.Veiculos.Remove(veiculo);
                await _context.SaveChangesAsync();

                response.sucesso = true;
                response.mensagem = "Veículo deletado com sucesso.";
                response.dados = true;
                _logger.LogInformation("Veículo com ID {VeiculoId} deletado com sucesso.", id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao deletar o veículo com ID {VeiculoId}.", id);
                response.sucesso = false;
                response.mensagem = $"Erro ao deletar veículo: {ex.Message}";
                response.dados = false;
            }
            return response;
        }

        public async Task<ServiceResponse<IEnumerable<VeiculoModel>>> GetByGrupoAsync(int grupoId)
        {
            var response = new ServiceResponse<IEnumerable<VeiculoModel>>();
            try
            {
                _logger.LogInformation("Tentando recuperar veículos do grupo com ID {GrupoId}.", grupoId);
                response.dados = await _context.Veiculos
                    .Where(v => v.grupoId == grupoId)
                    .Include(v => v.GrupoVeiculo)
                    .ToListAsync();

                if (response.dados.Any())
                {
                    response.sucesso = true;
                    response.mensagem = "Veículos do grupo encontrados com sucesso.";
                    _logger.LogInformation("Veículos do grupo com ID {GrupoId} encontrados.", grupoId);
                }
                else
                {
                    response.sucesso = false;
                    response.mensagem = "Nenhum veículo encontrado para este grupo.";
                    _logger.LogWarning("Nenhum veículo encontrado para o grupo com ID {GrupoId}.", grupoId);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao recuperar veículos do grupo com ID {GrupoId}.", grupoId);
                response.sucesso = false;
                response.mensagem = $"Erro ao recuperar veículos do grupo: {ex.Message}";
            }
            return response;
        }
    }
}
