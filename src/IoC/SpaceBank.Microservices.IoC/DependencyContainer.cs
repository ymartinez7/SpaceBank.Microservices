using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SpaceBank.Microservices.Infra.Bus;
using SpaceBank.Microservices.Rabbit.Domain.Core.Bus;
using System.Reflection;

namespace SpaceBank.Microservices.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection RegisterServices (this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();

            //MediatR Mediator
            services.AddMediatR(Assembly.GetExecutingAssembly());

            //Domain Bus
            services.AddSingleton<IEventBus, RabbitMQBus>(sp => {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                var optionsFactory = sp.GetService<IOptions<RabbitMQSetting>>();
                return new RabbitMQBus(sp.GetService<IMediator>(), scopeFactory, optionsFactory);
            });

            /* Banking */
            // Applicaction
            //services.AddTransient<IAccountService, AccountService>();
            // Infra
            //services.AddTransient<BankingDbContext>();
            //services.AddTransient<IAccountRepository, AccountRepository>();


            /* Transfer */
            // Applicaction
            //services.AddTransient<ITransferService, TransferService>();
            // Infra
            //services.AddTransient<TransferDbContext>();
            //services.AddTransient<ITransferRepository, TransferRepository>();

            return services;
        }
    }
}
