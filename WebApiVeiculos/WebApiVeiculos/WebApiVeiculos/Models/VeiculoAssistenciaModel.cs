using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiVeiculos.Models
{
    public class VeiculoAssistenciaModel
    {
        [Key]
        public int Id { get; set; } // Opcional: ou use chave composta abaixo no DbContext

        [Required]
        public int VeiculoId { get; set; }

        [ForeignKey("VeiculoId")]
        public VeiculoModel Veiculo { get; set; }

        [Required]
        public int PlanoId { get; set; }

        [ForeignKey("PlanoId")]
        public PlanoAssistenciaModel PlanoAssistencia { get; set; }
    }
}
