namespace StormSafe.API.DTO.Request
{
    public class RotaEvacuacaoRequest
    {
        public string Origem { get; set; } = string.Empty;
        public string Destino { get; set; } = string.Empty;
        public string RegiaoCritica { get; set; } = string.Empty;
    }
}
