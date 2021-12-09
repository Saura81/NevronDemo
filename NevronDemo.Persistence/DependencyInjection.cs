using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NevronDemo.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NevronDemo.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<NumbersDemoDbContext>(options =>
                options.UseInMemoryDatabase(databaseName: "NumbersDemo")); ;

            services.AddScoped<INumbersDemoDbContext>(provider => provider.GetService<NumbersDemoDbContext>());

            return services;
        }
    }
}
