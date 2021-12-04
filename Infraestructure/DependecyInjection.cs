using CoreDDD.Event;
using Domain.Persistence;
using Domain.Persistence.Repository;
using Infraestructure.Persistence;
using Infraestructure.Persistence.Repository;
using Infraestructure.RabbitMq;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Infraestructure
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfraestructure(
            this IServiceCollection services, IConfiguration configuration)
        {

            string connectionString = configuration.GetConnectionString("DbConnectionString");

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    connectionString, 
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
            );

            services.AddTransient<IOrdenEntregaRepository, OrdenEntregaRepository>();
            services.AddTransient<IItemRepository, ItemRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();


            services.AddSingleton<IEventBus, RabbitEventBus>(sp =>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitEventBus(sp.GetService<IMediator>(), configuration, scopeFactory);
            });

            return services;
        }


    }
}
