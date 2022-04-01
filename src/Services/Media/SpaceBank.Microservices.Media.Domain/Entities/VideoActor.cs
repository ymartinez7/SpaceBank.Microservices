namespace SpaceBank.Microservices.Media.Domain.Entities
{
    public class VideoActor :BaseEntity
    {
        public int VideoId { get; set; }
        public int ActorId { get; set; }
    }
}
