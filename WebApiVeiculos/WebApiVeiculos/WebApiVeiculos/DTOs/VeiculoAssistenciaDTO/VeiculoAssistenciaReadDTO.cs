namespace WebApiVeiculos.DTOs.VeiculoAssistenciaDTO
{
    public class VeiculoAssistenciaReadDTO
    {
        public int Id { get; set; }
        public string VeiculoPlaca { get; set; }
        public string PlanoDescricao { get; set; }
    }

    //acredito que não principalmente pelas tabelas... mas alem disso, o q o dto ta fazendo eh "desmembrando" aquele json

    //em vez de aparecer td como era, é só a entidade que a gnt definiu. acredito que antes mostrava td por causa dos relacionamentos,
    //não pelos models em si.

    //fica mais facil de entender naquele exemplo de usuario. o dto de login usava só email e senha, mas a gnt precisava das
    //outras informações em algumas outras funcionalidades
    //ent é so um ""recorte""
}
