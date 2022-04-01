using Microsoft.EntityFrameworkCore;
using SpaceBank.Microservices.Media.Domain.Entities;

namespace SpaceBank.Microservices.Media.Infrastructure.Data.Context
{
    public class MediaDbContext : DbContext
    {
        public DbSet<Actor>? Actors{ get; set; }
        public DbSet<Director>? Directors { get; set; }
        public DbSet<Streamer>? Streamers { get; set; }
        public DbSet<Video>? Videos { get; set; }
        public DbSet<VideoActor>? VideoActors { get; set; }

        public MediaDbContext(DbContextOptions<MediaDbContext> options) : base(options)
        {

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Detached:
                        break;
                    case EntityState.Unchanged:
                        break;
                    case EntityState.Deleted:
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = "system";
                        break;
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = "system";
                        break;
                    default:
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);    
        }
    }
}
