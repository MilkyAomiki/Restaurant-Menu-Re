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
    //TODO Я бы папку, назвал Extension, а не Configuration
    public static class CoreConfiguration
    {

        //TODO Лучше назвать ConfigureContext, ConfigureDatabase или как-то так. 
        //Чтобы не просто все в 1 метод вынести, а метод единую логическую цель выполняли.
        //Конфигурирование работы с базой; конфигурирование каких-то сервисов и тд
        public static IServiceCollection ConfigureCoreInterfaces(this IServiceCollection services)
        {
            services.AddDbContext<MenuContext>();
            services.AddScoped<IRepository<MenuItem>, MenuRepository>();
            services.AddScoped<IMenuService<MenuItem>, MenuService>();
            return services;
        }
    }
}
