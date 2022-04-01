using SpaceBank.Microservices.Media.Application.Interfaces.Repositories;
using SpaceBank.Microservices.Media.Domain.Entities;
using SpaceBank.Microservices.Media.Infrastructure.Data.Context;

namespace SpaceBank.Microservices.Media.Infrastructure.Data.Repositories
{
    public class StreamerRepository : BaseRepository<Streamer>, IStreamerRepository
    {
        public StreamerRepository(MediaDbContext dbContext) : base(dbContext) { }
    }
}
