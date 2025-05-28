namespace StormSafe.API.DTO.Response
{
    public class SensorResponse
    {
        public int Id { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public float Valor { get; set; }
        public DateTime DataLeitura { get; set; }
        public int RioId { get; set; }
    }
}
