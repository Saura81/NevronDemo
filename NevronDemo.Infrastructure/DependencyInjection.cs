using Microsoft.Extensions.DependencyInjection;
using NevronDemo.Common;
using System;

namespace NevronDemo.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IDateTime, MachineDateTime>();

            return services;
        }
    }
}
