using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SpaceBank.Microservices.Media.Application.Interfaces.Repositories;
using SpaceBank.Microservices.Media.Application.Interfaces.Services;
using SpaceBank.Microservices.Media.Application.Models;
using SpaceBank.Microservices.Media.Infrastructure.Data.Context;
using SpaceBank.Microservices.Media.Infrastructure.Data.Repositories;
using SpaceBank.Microservices.Media.Infrastructure.Services;

namespace SpaceBank.Microservices.Media.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MediaDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("MediaDbConnection"));
            });

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IVideoRepository, VideoRepository>();
            services.AddScoped<IStreamerRepository, StreamerRepository>();

            services.Configure<EmailSetting>(c => configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailService, EmailService>();

            return services;
        }
    }
}
