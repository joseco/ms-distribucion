using Application.EventHandler;
using Application.Features.Item.AddItem;
using AutoMapper;
using CoreDDD.Event;
using Domain.Events;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddTransient<AddItemHandler>();

            services.AddTransient<IEventHandler<ArticuloCreated>, AddItemHandler>();

            return services;
        }


        public static IApplicationBuilder UseApplication(this IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
            eventBus.Subscribe<ArticuloCreated, AddItemHandler>();

            return app;
        }
    }
}
