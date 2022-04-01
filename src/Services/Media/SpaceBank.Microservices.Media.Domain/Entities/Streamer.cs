namespace SpaceBank.Microservices.Media.Domain.Entities
{
    public class Streamer : BaseEntity
    {
        public string? Nombre { get; set; }
        public string? Url { get; set; }
        public ICollection<Video>? Videos { get; set; }
    }
}
