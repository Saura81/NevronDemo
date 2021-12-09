using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NevronDemo.Application.Common.Interfaces;



namespace NevronDemo.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddDbContext<NumbersDemoDbContext>(options =>
                options.UseInMemoryDatabase(databaseName: "NumbersDemo"));

            services.AddScoped(provider => provider.GetService<NumbersDemoDbContext>());

            return services;
        }
    }
}
