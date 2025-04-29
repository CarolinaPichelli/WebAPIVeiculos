using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiVeiculos.Models
{
    public class VeiculoModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Preencha o modelo do veículo")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "Preencha a placa do veículo")]
        [StringLength(10, ErrorMessage = "A placa do veículo deve conter até 10 caracteres")]
        public string Placa { get; set; }

        [Required]
        public int GrupoId { get; set; }

        [ForeignKey("GrupoId")]
        public GrupoVeiculoModel GrupoVeiculo { get; set; }

        public ICollection<VeiculoAssistenciaModel> VeiculoAssistencias { get; set; } = new List<VeiculoAssistenciaModel>();
    }
}
