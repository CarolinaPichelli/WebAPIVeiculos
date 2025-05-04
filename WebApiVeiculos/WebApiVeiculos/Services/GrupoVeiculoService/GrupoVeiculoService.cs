using Microsoft.EntityFrameworkCore;
using WebApiVeiculos.DataContext;
using WebApiVeiculos.DTOs.GrupoVeiculoDTO;
using WebApiVeiculos.Models;

namespace WebApiVeiculos.Services.GrupoVeiculo
{
    public class GrupoVeiculoService : IGrupoVeiculoService
    {
        private readonly ApplicationDbContext _context;

        public GrupoVeiculoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GrupoVeiculoDTO>> GetAllAsync()
        {
            return await _context.GrupoVeiculo
                .Select(g => new GrupoVeiculoDTO
                {
                    Id = g.Id,
                    Nome = g.Nome,
                    Descricao = g.Descricao
                })
                .ToListAsync();
        }

        public async Task<GrupoVeiculoDTO?> GetByIdAsync(int id)
        {
            var grupo = await _context.GrupoVeiculo.FindAsync(id);
            if (grupo == null) return null;

            return new GrupoVeiculoDTO
            {
                Id = grupo.Id,
                Nome = grupo.Nome,
                Descricao = grupo.Descricao
            };
        }

        public async Task<GrupoVeiculoDTO> CreateAsync(GrupoVeiculoDTO dto)
        {
            var model = new GrupoVeiculoModel
            {
                Nome = dto.Nome,
                Descricao = dto.Descricao
            };

            _context.GrupoVeiculo.Add(model);
            await _context.SaveChangesAsync();

            dto.Id = model.Id;
            return dto;
        }

        public async Task<GrupoVeiculoDTO?> UpdateAsync(int id, GrupoVeiculoDTO dto)
        {
            var grupo = await _context.GrupoVeiculo.FindAsync(id);
            if (grupo == null) return null;

            grupo.Nome = dto.Nome;
            grupo.Descricao = dto.Descricao;

            await _context.SaveChangesAsync();

            return new GrupoVeiculoDTO
            {
                Id = grupo.Id,
                Nome = grupo.Nome,
                Descricao = grupo.Descricao
            };
        }

        public async Task<bool> DeletarAsync(int id)
        {
            var grupo = await _context.GrupoVeiculo.FindAsync(id);
            if (grupo == null) return false;

            _context.GrupoVeiculo.Remove(grupo);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
