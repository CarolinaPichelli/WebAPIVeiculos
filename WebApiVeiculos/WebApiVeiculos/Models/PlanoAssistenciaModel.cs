using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiVeiculos.Models
{
    public class PlanoAssistenciaModel
    {
        [Key]
        public int Id { get; set; }

       public int EmpresaId { get; set; }

        [ForeignKey("EmpresaId")]
        public EmpresaAssistenciaModel EmpresaAssistencia { get; set; }

        [Required(ErrorMessage = "Preencha o campo de descrição")]
        public string Descricao { get; set; }

        [Required]
        public string Cobertura { get; set; }

        public List<VeiculoAssistenciaModel> VeiculoAssistencias { get; set; } = new();

        //public ICollection<VeiculoAssistenciaModel> VeiculoAssistencias { get; set; } = new List<VeiculoAssistenciaModel>();
    }
}
