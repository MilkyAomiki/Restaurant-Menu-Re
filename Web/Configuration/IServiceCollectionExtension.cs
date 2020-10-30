using ApplicationCore.Entities.Data;
using ApplicationCore.Entities.DataRepresentation;
using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using AutoMapper;
using Infrastructure.Data;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Web.Configuration
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection ConfigureCore(this IServiceCollection services)
        {
            services.AddScoped<IRepository<MenuItem>, MenuRepository>();
            services.AddScoped<IMenuService<MenuItem, SearchData>, MenuService>();
            return services;
        }

        public static IServiceCollection ConfigureInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MenuContext>(options => options.UseSqlServer(configuration.GetConnectionString("HomeServer")));
            return services;
        }

        public static IServiceCollection ConfigureWeb(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DTO.MapsConfiguration.MenuDtoProfile));
            return services;
        }
    }
}
