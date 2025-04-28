using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApiVeiculos.Models;

namespace WebApiVeiculos.Models
{
    public class VeiculoAssistenciaModel
    {
        [Key]
        public required int id { get; set; }

        [Required]
        public required int veiculoId { get; set; }

        [ForeignKey("veiculoId")]
        public VeiculoModel Veiculo { get; set; }  // Pode ser opcional se você não precisar do objeto completo aqui.

        [Required]
        public int planoId { get; set; }

        [ForeignKey("planoId")]
        public PlanoAssistenciaModel PlanoAssistencia { get; set; }  // Pode ser opcional se você não precisar do objeto completo aqui.
    }
}
