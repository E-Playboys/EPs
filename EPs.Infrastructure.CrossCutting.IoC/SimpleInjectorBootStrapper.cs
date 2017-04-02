using AutoMapper;
using EPs.Application.Interfaces;
using EPs.Application.Services;
using EPs.Domain.Commands;
using EPs.Domain.Core.Events;
using EPs.Domain.Core.Interfaces;
using EPs.Domain.Core.Notification;
using EPs.Domain.Events;
using EPs.Domain.Repositories;
using EPs.Infrastructure.CrossCutting.Identity.Authorization;
using EPs.Infrastructure.CrossCutting.Identity.Services;
using EPs.Infrastructure.Data.Contexts;
using EPs.Infrastructure.Data.Repositories;
using EPs.Infrastructure.Data.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace EPs.Infrastructure.CrossCutting.IoC
{
    public class SimpleInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // ASP.NET Authorization Polices
            services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>(); ;

            // Application
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));
            services.AddScoped<IProductService, ProductService>();

            // Domain - Events
            services.AddScoped<IDomainNotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<IHandler<ProductCreatedEvent>, ProductEventHandler>();
            services.AddScoped<IHandler<ProductUpdatedEvent>, ProductEventHandler>();
            services.AddScoped<IHandler<ProductDeletedEvent>, ProductEventHandler>();

            // Domain - Commands
            services.AddScoped<IHandler<CreateProductCommand>, ProductCommandHandler>();
            services.AddScoped<IHandler<UpdateProductCommand>, ProductCommandHandler>();
            services.AddScoped<IHandler<DeleteProductCommand>, ProductCommandHandler>();

            // Infra - Data
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<EPsContext>();
        }
    }
}
