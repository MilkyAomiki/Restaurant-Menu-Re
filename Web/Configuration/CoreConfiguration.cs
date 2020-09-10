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

            return services;
        }
    }
}
