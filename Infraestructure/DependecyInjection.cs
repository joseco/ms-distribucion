using Domain.Persistence;
using Domain.Persistence.Repository;
using Infraestructure.Persistence;
using Infraestructure.Persistence.Repository;
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

            services.AddScoped<IOrdenEntregaRepository, OrdenEntregaRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }


    }
}
