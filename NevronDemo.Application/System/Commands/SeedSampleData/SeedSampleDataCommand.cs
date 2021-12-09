using MediatR;
using NevronDemo.Application.Common.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NevronDemo.Domain.Entities;
using System;

namespace NevronDemo.Application.System.Commands.SeedSampleData
{
    public class SeedSampleDataCommand : IRequest
    {
        public class SeedSampleDataCommandHandler : IRequestHandler<SeedSampleDataCommand>
        {
            private readonly INumbersDemoDbContext  db;

            public SeedSampleDataCommandHandler(INumbersDemoDbContext db)
            {
                this.db = db;
            }

            public async Task<Unit> Handle(SeedSampleDataCommand request, CancellationToken cancellationToken)
            {
                if (!db.Numbers.Any())
                {
                    Random rd = new Random();

                    await db.Numbers.AddAsync(new Number { Value = rd.Next() }, cancellationToken);
                    await db.Numbers.AddAsync(new Number { Value = rd.Next() }, cancellationToken);
                    await db.Numbers.AddAsync(new Number { Value = rd.Next() }, cancellationToken);
                    await db.Numbers.AddAsync(new Number { Value = rd.Next() }, cancellationToken);
                    await db.Numbers.AddAsync(new Number { Value = rd.Next() }, cancellationToken);

                    await db.SaveChangesAsync(cancellationToken);
                }

                return Unit.Value;
            }


        }
    }
}
