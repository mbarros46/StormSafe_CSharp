namespace StormSafe.API.Infrastructure.Persistence
{
    public class Sensor
    {
        public int Id { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public float Valor { get; set; }
        public DateTime DataLeitura { get; set; }
        public int RioId { get; set; }
        public Rio Rio { get; set; }
    }
}
