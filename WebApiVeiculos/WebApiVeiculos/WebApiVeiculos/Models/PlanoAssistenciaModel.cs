using System.ComponentModel.DataAnnotations; //anotações para validação de dados (Ex.: Key, Required...)
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiVeiculos.Models
{
    public class PlanoAssistenciaModel
    {

        [Key]
        public int id { get; set; }

        [Required]
        public int empresaId { get; set; }

        [ForeignKey("empresaId")]
        public required EmpresaAssistenciaModel EmpresaAssistencia { get; set; }

        [Required(ErrorMessage = "Preencha o campo de descrição")]
        public required string descricao { get; set; }

        public required string cobertura { get; set; }

        public required ICollection<VeiculoAssistenciaModel> VeiculoAssistencia { get; set; }
    }
}
