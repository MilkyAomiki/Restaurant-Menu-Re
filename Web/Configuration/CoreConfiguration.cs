using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Configuration
{
    public static class CoreConfiguration
    {

        public static IServiceCollection ConfigureCoreInterfaces(this IServiceCollection services)
        {
            services.AddDbContext<MenuContext>();
            services.AddScoped<IRepository<MenuItem>, MenuRepository>();
            services.AddScoped<IMenuService<MenuItem>, MenuService>();
            return services;
        }
    }
}
