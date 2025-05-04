using Microsoft.EntityFrameworkCore;
using WebApiVeiculos.DataContext;
using WebApiVeiculos.DTOs.VeiculoAssistenciaDTO;
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

        // Método para buscar todos os VeiculoAssistencias
        public async Task<List<VeiculoAssistenciaDTO>> BuscarTodosAsync()
        {
            return await _context.VeiculoAssistencias
                .Select(v => new VeiculoAssistenciaDTO
                {
                    Id = v.Id,
                    VeiculoId = v.VeiculoId,
                    PlanoId = v.PlanoId,
                }).ToListAsync();
        }

        // Método para buscar por ID
        public async Task<VeiculoAssistenciaDTO?> BuscarPorIdAsync(int id)
        {
            var veiculoAssistencia = await _context.VeiculoAssistencias
                .Include(v => v.Plano) // se quiser incluir os dados relacionados
                .FirstOrDefaultAsync(v => v.Id == id);

            if (veiculoAssistencia == null) return null;

            return new VeiculoAssistenciaDTO
            {
                Id = veiculoAssistencia.Id,
                VeiculoId = veiculoAssistencia.VeiculoId,
                PlanoId = veiculoAssistencia.PlanoId,
            };
        }

        // Método para criar uma nova VeiculoAssistencia
        public async Task<VeiculoAssistenciaDTO> CriarAsync(VeiculoAssistenciaDTO dto)
        {
            try
            {
                // Verifica se os IDs de Veículo e Plano são válidos (existem no banco)
                var veiculoExistente = await _context.Veiculos.FindAsync(dto.VeiculoId);
                var planoExistente = await _context.PlanoAssistencias.FindAsync(dto.PlanoId);

                if (veiculoExistente == null || planoExistente == null)
                {
                    throw new Exception("Veículo ou Plano inválido.");
                }

                // Verifica duplicidade da associação VeiculoId + PlanoId
                bool existe = await _context.VeiculoAssistencias
                    .AnyAsync(x => x.VeiculoId == dto.VeiculoId && x.PlanoId == dto.PlanoId);

                if (existe)
                {
                    throw new Exception("Essa associação entre veículo e plano já existe.");
                }

                var model = new VeiculoAssistenciaModel
                {
                    VeiculoId = dto.VeiculoId,
                    PlanoId = dto.PlanoId,
                };

                _context.VeiculoAssistencias.Add(model);
                await _context.SaveChangesAsync();

                return new VeiculoAssistenciaDTO
                {
                    Id = model.Id,
                    VeiculoId = model.VeiculoId,
                    PlanoId = model.PlanoId,
                };
            }
            catch (Exception ex)
            {
                var errorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                throw new Exception($"Erro interno ao criar associação: {errorMessage}");
            }
        }


        // Método para atualizar um VeiculoAssistencia
        public async Task<VeiculoAssistenciaDTO?> AtualizarAsync(int id, VeiculoAssistenciaDTO dto)
        {
            var existente = await _context.VeiculoAssistencias.FindAsync(id);
            if (existente == null) return null;

            // Verifica se os IDs de Veículo e Plano são válidos (existem no banco)
            var veiculoExistente = await _context.Veiculos.FindAsync(dto.VeiculoId);
            var planoExistente = await _context.PlanoAssistencias.FindAsync(dto.PlanoId);

            if (veiculoExistente == null || planoExistente == null)
            {
                throw new Exception("Veículo ou Plano inválido.");
            }

            existente.VeiculoId = dto.VeiculoId;
            existente.PlanoId = dto.PlanoId;

            await _context.SaveChangesAsync();

            return new VeiculoAssistenciaDTO
            {
                Id = existente.Id,
                VeiculoId = existente.VeiculoId,
                PlanoId = existente.PlanoId,
            };
        }

        // Método para deletar uma VeiculoAssistencia
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
