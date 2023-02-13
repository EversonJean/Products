using Application.Application;
using Application.Application.Interfaces;
using Application.AutoMapper;
using AutoMapper;
using CrossCutting.Options;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Services;
using Infrastructure.Database;
using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Application.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMongoDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoDbOptions>(configuration.GetSection("MongoDB"));
            services.AddSingleton(options => options.GetRequiredService<IOptions<MongoDbOptions>>().Value);

            services.AddSingleton(options =>
            {
                var settings = configuration.GetSection("MongoDb").Get<MongoDbOptions>();
                var client = new MongoClient(settings?.ConnectionString);
                return client.GetDatabase(settings?.DatabaseName);
            });

            MongoDbConfig.UseMongoConventions();

            return services;
        }

        public static IServiceCollection AddApplications(this IServiceCollection services)
        {
            services.AddScoped<IProductApplication, ProductApplication>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
