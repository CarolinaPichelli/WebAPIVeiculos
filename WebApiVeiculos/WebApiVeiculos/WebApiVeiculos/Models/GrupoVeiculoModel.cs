using System.ComponentModel.DataAnnotations;
using WebApiVeiculos.Models;


namespace WebApiVeiculos.Models { 
public class GrupoVeiculoModel
{
    [Key]
    public int id { get; set; }

    [Required(ErrorMessage = "Preencha com o nome")]
    public string nome { get; set; }

    [Required(ErrorMessage = "Preencha com a descrição")]
    public string descricao { get; set; }

    public ICollection<VeiculoModel> Veiculos { get; set; }

    public GrupoVeiculoModel()
    {
        Veiculos = new List<VeiculoModel>();  // Inicializando a coleção
    }
}
}
