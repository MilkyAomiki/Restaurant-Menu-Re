using ApplicationCore.Entities.Data;
using ApplicationCore.Entities.DataRepresentation;
using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using AutoMapper;
using Infrastructure.Data;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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

        public static IServiceCollection ConfigureInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<MenuContext>(options => options.UseSqlServer("Name=HomeServer"));
            return services;
        }

        public static IServiceCollection ConfigureWeb(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MenuMapperDtoProfile));
            return services;
        }
    }
}
