using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiVeiculos.Models
{
    public class VeiculoAssistenciaModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int VeiculoId { get; set; }

        [ForeignKey("VeiculoId")]
        public VeiculoModel? Veiculo { get; set; }

        [Required]
        public int PlanoId { get; set; }

        [ForeignKey("PlanoId")]
        public PlanoAssistenciaModel? Plano { get; set; }
    }
}
