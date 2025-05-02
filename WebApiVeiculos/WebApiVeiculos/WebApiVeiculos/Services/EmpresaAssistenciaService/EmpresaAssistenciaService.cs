// Service
using Microsoft.EntityFrameworkCore;
using WebApiVeiculos.DataContext;
using WebApiVeiculos.DTOs.EmpresaAssistenciaDTO;
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

        public async Task<IEnumerable<EmpresaAssistenciaDTO>> BuscarTodosAsync()
        {
            var empresas = await _context.EmpresaAssistencias.ToListAsync();
            return empresas.Select(e => new EmpresaAssistenciaDTO
            {
                Id = e.Id,
                Nome = e.Nome,
                Endereco = e.Endereco
            });
        }

        public async Task<EmpresaAssistenciaDTO?> BuscarPorIdAsync(int id)
        {
            var empresa = await _context.EmpresaAssistencias.FirstOrDefaultAsync(e => e.Id == id);
            if (empresa == null) return null;

            return new EmpresaAssistenciaDTO
            {
                Id = empresa.Id,
                Nome = empresa.Nome,
                Endereco = empresa.Endereco
            };
        }

        public async Task<EmpresaAssistenciaDTO> CriarAsync(EmpresaAssistenciaDTO empresaDto)
        {
            var empresa = new EmpresaAssistenciaModel
            {
                Nome = empresaDto.Nome,
                Endereco = empresaDto.Endereco
            };

            _context.EmpresaAssistencias.Add(empresa);
            await _context.SaveChangesAsync();

            return new EmpresaAssistenciaDTO
            {
                Id = empresa.Id,
                Nome = empresa.Nome,
                Endereco = empresa.Endereco
            };
        }

        public async Task<EmpresaAssistenciaDTO?> AtualizarAsync(int id, EmpresaAssistenciaDTO empresaDto)
        {
            var existente = await _context.EmpresaAssistencias.FindAsync(id);
            if (existente == null)
                return null;

            existente.Nome = empresaDto.Nome;
            existente.Endereco = empresaDto.Endereco;

            _context.EmpresaAssistencias.Update(existente);
            await _context.SaveChangesAsync();

            return new EmpresaAssistenciaDTO
            {
                Id = existente.Id,
                Nome = existente.Nome,
                Endereco = existente.Endereco
            };
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
