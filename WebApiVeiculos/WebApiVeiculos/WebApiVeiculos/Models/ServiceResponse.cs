namespace WebApiVeiculos.Models
{
    public class ServiceResponse <T>
    {
        public T? dados { get; set; }

        public bool sucesso { get; set; } = true;

        public string mensagem {  get; set; } = string.Empty; 

    }
}
