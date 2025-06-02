namespace StormSafe.API.Infrastructure.Persistence
{
    public class RotaEvacuacao
    {
        public int Id { get; set; }
        public string Origem { get; set; } = string.Empty;
        public string Destino { get; set; } = string.Empty;
        public string RegiaoCritica { get; set; } = string.Empty;
    }
}
