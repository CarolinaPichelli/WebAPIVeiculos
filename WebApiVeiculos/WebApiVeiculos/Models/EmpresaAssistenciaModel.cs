using System.ComponentModel.DataAnnotations;

namespace WebApiVeiculos.Models
{
    public class EmpresaAssistenciaModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Preencha com o nome")]
        public string Nome { get; set; }

        [Required]
        public string Endereco { get; set; }

        public ICollection<PlanoAssistenciaModel> Planos { get; set; } = new List<PlanoAssistenciaModel>();
    }
}
