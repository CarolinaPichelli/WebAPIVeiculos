using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiVeiculos.Models
{
    public class VeiculoModel
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Preencha o modelo do veículo")]
        public string modelo { get; set; }

        [Required(ErrorMessage = "Preencha a placa do veículo")]
        [StringLength(10, ErrorMessage = "A placa do veículo deve conter até 10 caracteres")]
        public string placa { get; set; }

        [Required]
        public int grupoId { get; set; }

        [ForeignKey("grupoId")]
        public GrupoVeiculoModel GrupoVeiculo { get; set; } // A propriedade não deve ser "required" aqui

        public ICollection<VeiculoAssistenciaModel> VeiculoAssistencia { get; set; } // Essa coleção deve ser inicializada, caso contrário, pode causar erros

        public VeiculoModel()
        {
            VeiculoAssistencia = new List<VeiculoAssistenciaModel>(); // Inicializando a coleção para evitar problemas
        }
    }
}
