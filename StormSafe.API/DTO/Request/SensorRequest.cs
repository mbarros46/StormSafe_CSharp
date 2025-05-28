namespace StormSafe.API.DTO.Request
{
    public class SensorRequest
    {
        public string Tipo { get; set; } = string.Empty;
        public float Valor { get; set; }
        public DateTime DataLeitura { get; set; }
        public int RioId { get; set; }
    }
}
