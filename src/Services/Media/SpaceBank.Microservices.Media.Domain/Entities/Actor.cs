namespace SpaceBank.Microservices.Media.Domain.Entities
{
    public class Actor : BaseEntity
    {
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public ICollection<Video> Videos { get; set; }

        public Actor()
        {
            Videos = new HashSet<Video>();
        }
    }
}
