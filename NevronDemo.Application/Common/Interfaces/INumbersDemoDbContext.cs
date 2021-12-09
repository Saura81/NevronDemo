using Microsoft.EntityFrameworkCore;
using NevronDemo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NevronDemo.Application.Common.Interfaces
{
    public interface INumbersDemoDbContext
    {
        DbSet<Number> Numbers { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
