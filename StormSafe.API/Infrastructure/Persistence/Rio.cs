namespace StormSafe.API.Infrastructure.Persistence
{
    public class Rio
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public ICollection<Sensor> Sensores { get; set; } = new List<Sensor>();
    }
}
