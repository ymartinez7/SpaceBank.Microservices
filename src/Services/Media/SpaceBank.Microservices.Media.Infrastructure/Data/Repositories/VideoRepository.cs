using Microsoft.EntityFrameworkCore;
using SpaceBank.Microservices.Media.Application.Interfaces.Repositories;
using SpaceBank.Microservices.Media.Domain.Entities;
using SpaceBank.Microservices.Media.Infrastructure.Data.Context;

namespace SpaceBank.Microservices.Media.Infrastructure.Data.Repositories
{
    public class VideoRepository : BaseRepository<Video>, IVideoRepository
    {
        public VideoRepository(MediaDbContext dbContext) : base(dbContext) { }

        public async Task<Video> GetVideoByName(string name)
        {
            return await _dbContext.Videos!.Where(p => p.Nombre == name).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Video>> GetVideoByUsername(string username)
        {
            return await _dbContext.Videos!.Where(p => p.CreatedBy == username).ToListAsync();
        }
    }
}
