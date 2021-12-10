using Microsoft.EntityFrameworkCore;
using NevronDemo.Domain.Entities;
using NevronDemo.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace NevronDemo.Application.UnitTest.Common
{
    public static class NumbersDemoDbContextFactory
    {
        public static NumbersDemoDbContext Create()
        {
            var options = new DbContextOptionsBuilder<NumbersDemoDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new NumbersDemoDbContext(
                new MachineDateTime(),
                new AnonymousUserService(),
                options
                );

            context.Database.EnsureCreated();

            FillTestData(context);

            return context;
        }

        public static void Destroy(NumbersDemoDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }

        private static void FillTestData(NumbersDemoDbContext context)
        {

            context.Numbers.Add(new Number() { Value = 111111111 });
            context.Numbers.Add(new Number() { Value = 222222222 });

            context.SaveChanges();
        }
    }
}
