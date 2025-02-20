using DeveloperEvaluation.Application.Event;
using DeveloperEvaluation.Domain.Repositories;
using DeveloperEvaluation.Domain.Services;
using DeveloperEvaluation.ORM;
using DeveloperEvaluation.ORM.Repositories;
using DeveloperEvaluation.RabbitMQ;
using DeveloperEvaluation.Redis;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DeveloperEvaluation.IoC.ModuleInitializers;

public class InfrastructureModuleInitializer : IModuleInitializer
{
    public void Initialize(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<DbContext>(provider => provider.GetRequiredService<DefaultContext>());
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IAdressRepository, AdressRepository>();
        builder.Services.AddScoped<IGeolocationRepository, GeolocationRepository>();
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddScoped<IEventPublisher, RabbitMqEventPublisher>();
        builder.Services.AddScoped<IProductRepository, ProductRepository>();
        builder.Services.AddScoped<IRatingRepository, RatingRepository>();
        builder.Services.AddScoped<IRedisService, RedisService>();
        builder.Services.AddScoped<ISaleRepository, SaleRepository>();
        builder.Services.AddScoped<ISaleProductRepository, SaleProductRepository>();
        builder.Services.AddScoped<EventService>();
    }
}