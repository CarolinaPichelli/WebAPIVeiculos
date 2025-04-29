using Microsoft.EntityFrameworkCore;
using WebApiVeiculos.Models;

namespace WebApiVeiculos.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<VeiculoModel> Veiculos { get; set; }
        public DbSet<VeiculoAssistenciaModel> VeiculoAssistencias { get; set; }
        public DbSet<PlanoAssistenciaModel> PlanoAssistencias { get; set; }
        public DbSet<GrupoVeiculoModel> GrupoVeiculos { get; set; }
        public DbSet<EmpresaAssistenciaModel> EmpresaAssistencias { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 1:N - Veículo → Grupo
            modelBuilder.Entity<VeiculoModel>()
                .HasOne(v => v.GrupoVeiculo)
                .WithMany(g => g.Veiculos)
                .HasForeignKey(v => v.GrupoId);

            // 1:N - Plano → Empresa
            modelBuilder.Entity<PlanoAssistenciaModel>()
                .HasOne(p => p.EmpresaAssistencia)
                .WithMany(e => e.Planos)
                .HasForeignKey(p => p.EmpresaId);

            // Chave composta (evita duplicidade de relacionamento Veículo-Plano)
            modelBuilder.Entity<VeiculoAssistenciaModel>()
                .HasIndex(va => new { va.VeiculoId, va.PlanoId }).IsUnique();

            // N:1 - VeiculoAssistencia → Veiculo
            modelBuilder.Entity<VeiculoAssistenciaModel>()
                .HasOne(va => va.Veiculo)
                .WithMany(v => v.VeiculoAssistencias)
                .HasForeignKey(va => va.VeiculoId);

            // N:1 - VeiculoAssistencia → Plano
            modelBuilder.Entity<VeiculoAssistenciaModel>()
                .HasOne(va => va.PlanoAssistencia)
                .WithMany(p => p.VeiculoAssistencias)
                .HasForeignKey(va => va.PlanoId);
        }
    }
}
