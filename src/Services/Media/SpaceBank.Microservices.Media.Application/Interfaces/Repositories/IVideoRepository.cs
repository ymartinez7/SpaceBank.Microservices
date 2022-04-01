using SpaceBank.Microservices.Media.Domain.Entities;

namespace SpaceBank.Microservices.Media.Application.Interfaces.Repositories
{
    public interface IVideoRepository : IBaseRepository<Video>
    {
        Task<Video> GetVideoByName(string name);
        Task<IEnumerable<Video>> GetVideoByUsername(string username);
    }
}
