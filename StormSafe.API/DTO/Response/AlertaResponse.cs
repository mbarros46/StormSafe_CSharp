namespace StormSafe.API.DTO.Response
{
    public class AlertaResponse
    {
        public int Id { get; set; }
        public string Mensagem { get; set; } = string.Empty;
        public string NivelRisco { get; set; } = string.Empty;
        public DateTime CriadoEm { get; set; }
    }
}
