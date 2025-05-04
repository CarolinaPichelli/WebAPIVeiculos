using Microsoft.EntityFrameworkCore;
using WebApiVeiculos.DataContext;
using WebApiVeiculos.DTOs.PlanoAssistenciaDTO;
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

        public async Task<List<PlanoAssistenciaDTO>> BuscarTodosAsync()
        {
            return await _context.PlanoAssistencias.Select(p => new PlanoAssistenciaDTO{
               Id = p.Id,
               Descricao = p.Descricao,
               Cobertura = p.Cobertura,
               EmpresaId = p.EmpresaId,
            }).ToListAsync();
        }

        public async Task<PlanoAssistenciaDTO?> BuscarPorIdAsync(int id)
        {
            var plano = await _context.PlanoAssistencias.FindAsync(id);
            if (plano == null) return null;

            return new PlanoAssistenciaDTO
            {
                Id = plano.Id,
                Descricao = plano.Descricao,
                Cobertura = plano.Cobertura,
                EmpresaId= plano.EmpresaId,

            };
        }

        public async Task<PlanoAssistenciaDTO> CriarAsync(PlanoAssistenciaDTO plano)
        {
            var model = new PlanoAssistenciaModel
            {
                Descricao = plano.Descricao,
                Cobertura = plano.Cobertura,
                EmpresaId = plano.EmpresaId,
            };

            _context.PlanoAssistencias.Add(model);
            await _context.SaveChangesAsync();

            plano.Id = model.Id;
            return plano;
        }

        public async Task<PlanoAssistenciaDTO?> AtualizarAsync(int id, PlanoAssistenciaDTO plano)
        {
            var existente = await _context.PlanoAssistencias.FindAsync(id);
            if (existente == null)
                return null;

            existente.Descricao = plano.Descricao;
            existente.Cobertura = plano.Cobertura;
            existente.EmpresaId = plano.EmpresaId;

            await _context.SaveChangesAsync();
            return new PlanoAssistenciaDTO
            {
                Id = existente.Id,
                Descricao = existente.Descricao,
                EmpresaId = existente.EmpresaId,
            };
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
