using System.ComponentModel.DataAnnotations; //anotações para validação de dados (Ex.: Key, Required...)

namespace WebApiVeiculos.Models
{
    public class EmpresaAssistenciaModel
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Preencha com o nome")]
        public required string nome { get; set; }
        
        public required string endereco { get; set; }

        public required ICollection<PlanoAssistenciaModel> Planos { get; set; } //maiusculo ou minusculo? pq as variaveis tao minusculas

    }
}
