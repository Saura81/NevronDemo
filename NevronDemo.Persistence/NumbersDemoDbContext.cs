using Microsoft.EntityFrameworkCore;
using NevronDemo.Application.Common.Interfaces;
using NevronDemo.Common;
using NevronDemo.Domain.Common;
using NevronDemo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NevronDemo.Persistence
{
    public class NumbersDemoDbContext : DbContext, INumbersDemoDbContext
    {
        private readonly IDateTime dateTime;
        private readonly ICurrentUserService currentUserService;
        public DbSet<Number> Numbers { get; set; }

        public NumbersDemoDbContext(IDateTime dateTime,
           ICurrentUserService currentUserService,
           DbContextOptions<NumbersDemoDbContext> options) : base(options)
        {
            this.dateTime = dateTime;
            this.currentUserService = currentUserService;
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.Entity.LastUpdatedBy = currentUserService.UserId;
                        entry.Entity.LastUpdated = dateTime.Now;
                        break;
                    case EntityState.Added:
                        entry.Entity.CreatedBy = currentUserService.UserId;
                        entry.Entity.Created = dateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(NumbersDemoDbContext).Assembly);
        }
    }
}
