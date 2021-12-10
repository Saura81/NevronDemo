
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using NevronDemo.Application.Common.Behaviours;
using MediatR;
using AutoMapper;

namespace NevronDemo.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
