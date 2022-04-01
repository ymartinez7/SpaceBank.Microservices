namespace SpaceBank.Microservices.Media.Domain.Entities
{
    public class Video : BaseEntity
    {
        public string? Nombre { get; set; }
        public int StreamerId { get; set; }
        public virtual Streamer? Streamer { get; set; }
        public virtual ICollection<Actor> Actores { get; set; }
        public virtual Director Director { get; set; }

        public Video()
        {
            Actores = new HashSet<Actor>();
        }
    }
}
