using System.ComponentModel.DataAnnotations;

namespace WebApiVeiculos.Models
{
    public class GrupoVeiculoModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Preencha com o nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha com a descrição")]
        public string Descricao { get; set; }

        public ICollection<VeiculoModel> Veiculos { get; set; } = new List<VeiculoModel>();
    }
}
