namespace StormSafe.API.DTO.Response
{
    public class RotaEvacuacaoResponse
    {
        public int Id { get; set; }
        public string Origem { get; set; } = string.Empty;
        public string Destino { get; set; } = string.Empty;
        public string RegiaoCritica { get; set; } = string.Empty;
    }
}
