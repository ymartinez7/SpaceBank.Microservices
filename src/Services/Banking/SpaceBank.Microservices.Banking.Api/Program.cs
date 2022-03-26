using MediatR;
using Microsoft.EntityFrameworkCore;
using SpaceBank.Microservices.Banking.Application.Interfaces;
using SpaceBank.Microservices.Banking.Application.Services;
using SpaceBank.Microservices.Banking.Domain.CommandHandlers;
using SpaceBank.Microservices.Banking.Domain.Commands;
using SpaceBank.Microservices.Banking.Domain.Interfaces;
using SpaceBank.Microservices.Banking.Infra.Context;
using SpaceBank.Microservices.Banking.Infra.Repository;
using SpaceBank.Microservices.Infra.Bus;
using SpaceBank.Microservices.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// EF
builder.Services.AddDbContext<BankingDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("BankingDbConnection"));
});

// Event Bus
builder.Services.Configure<RabbitMQSetting>(builder.Configuration.GetSection("RabbitMQSetting"));

// IoC
builder.Services.RegisterServices(builder.Configuration);
builder.Services.AddTransient<BankingDbContext>();
builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddTransient<IAccountRepository, AccountRepository>();
builder.Services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();
//DependencyContainer.RegisterServices(builder.Services, builder.Configuration);


// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
