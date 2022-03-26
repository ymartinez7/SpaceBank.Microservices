using Microsoft.EntityFrameworkCore;
using SpaceBank.Microservices.Infra.Bus;
using SpaceBank.Microservices.IoC;
using SpaceBank.Microservices.Rabbit.Domain.Core.Bus;
using SpaceBank.Microservices.Transfer.Application.Interfaces;
using SpaceBank.Microservices.Transfer.Application.Services;
using SpaceBank.Microservices.Transfer.Domain.EventHandlers;
using SpaceBank.Microservices.Transfer.Domain.Events;
using SpaceBank.Microservices.Transfer.Domain.Interfaces;
using SpaceBank.Microservices.Transfer.Infra.Context;
using SpaceBank.Microservices.Transfer.Infra.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// EF
builder.Services.AddDbContext<TransferDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("TransferDbConnection"));
});

// Event Bus
builder.Services.Configure<RabbitMQSetting>(builder.Configuration.GetSection("RabbitMQSetting"));


// IoC
builder.Services.RegisterServices(builder.Configuration);

builder.Services.AddTransient<ITransferService, TransferService>();
builder.Services.AddTransient<ITransferRepository, TransferRepository>();
builder.Services.AddTransient<TransferDbContext>();
builder.Services.AddTransient<IEventHandler<TransferCreatedEvent>, TransferEventHandler>();


// Subscriptions for consumer of Event Bus
builder.Services.AddTransient<TransferEventHandler>();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
});



var app = builder.Build();

// Event Bus
var eventBus = app.Services.GetRequiredService<IEventBus>();
eventBus.Subscribe<TransferCreatedEvent, TransferEventHandler>();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
