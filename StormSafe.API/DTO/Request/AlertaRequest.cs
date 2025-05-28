namespace StormSafe.API.DTO.Request
{
    public class AlertaRequest
    {
        public string Mensagem { get; set; } = string.Empty;
        public string NivelRisco { get; set; } = string.Empty;
    }
}
