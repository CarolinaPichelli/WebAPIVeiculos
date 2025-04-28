using Microsoft.EntityFrameworkCore;
using WebApiVeiculos.Models;

namespace WebApiVeiculos.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        //mapeia as entidades para as tabelas (cada um representa uma tabela no banco)
        public DbSet<VeiculoModel> Veiculos { get; set; }
        public DbSet<VeiculoAssistenciaModel> VeiculoAssistencia { get; set; } //tabela intermediária
        public DbSet<PlanoAssistenciaModel> PlanoAssistencias { get; set; }
        public DbSet<GrupoVeiculoModel> GrupoVeiculo { get; set; }
        public DbSet<EmpresaAssistenciaModel> EmpresaAssistencias { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //relacionamento 1:N entre Veiculo e GrupoVeiculo
            modelBuilder.Entity<VeiculoModel>().HasOne(v => v.GrupoVeiculo).WithMany(g => g.Veiculos)
                .HasForeignKey(v => v.grupoId);
            //relacionamento 1:N entre PlanoAssistencias e EmpresaAssistencias
            modelBuilder.Entity<PlanoAssistenciaModel>().HasOne(p => p.EmpresaAssistencia).WithMany(e => e.Planos)
                .HasForeignKey(p => p.empresaId);
            //tabela intermediária explícita: VeiculoAssistencia
            modelBuilder.Entity<VeiculoAssistenciaModel>().HasKey(va => va.veiculoId);
            //relacionamento N:1 entre VeiculosAssistencias e Veiculo
            modelBuilder.Entity<VeiculoAssistenciaModel>().HasOne(va => va.Veiculo).WithMany(v => v.VeiculoAssistencia)
                .HasForeignKey(va => va.veiculoId);
            //relacionamento N:1 entre VeiculoAssistencias e PlanoAssistencias
            modelBuilder.Entity<VeiculoAssistenciaModel>().HasOne(va => va.PlanoAssistencia).WithMany(p => p.VeiculoAssistencia)
                .HasForeignKey(va => va.planoId);

        }

    }
}
