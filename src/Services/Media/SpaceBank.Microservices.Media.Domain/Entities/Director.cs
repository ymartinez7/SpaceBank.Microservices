namespace SpaceBank.Microservices.Media.Domain.Entities
{
    public class Director : BaseEntity
    {
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public int VideoId { get; set; }
        public virtual Video? Video { get; set; }
    }
}
