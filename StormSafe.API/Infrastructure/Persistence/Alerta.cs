namespace StormSafe.API.Infrastructure.Persistence
{
    public class Alerta
    {
        public int Id { get; set; }
        public string Mensagem { get; set; } = string.Empty;
        public string NivelRisco { get; set; } = string.Empty; // Baixo, Médio, Alto
        public DateTime CriadoEm { get; set; } = DateTime.Now;
    }
}
