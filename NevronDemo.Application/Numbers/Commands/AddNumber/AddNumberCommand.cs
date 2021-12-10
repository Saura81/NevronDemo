using MediatR;
using NevronDemo.Application.Common.Interfaces;
using NevronDemo.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NevronDemo.Application.Numbers.Commands.AddNumber
{
    public class AddNumberCommand: IRequest
    {
        public class AddNumberCommandHandler : IRequestHandler<AddNumberCommand>
        {
            private readonly INumbersDemoDbContext db;
            private Random random = new Random(DateTime.Now.Millisecond);
            public AddNumberCommandHandler(INumbersDemoDbContext db)
            {
                this.db = db;
            }


            public async Task<Unit> Handle(AddNumberCommand request, CancellationToken cancellationToken)
            {

                await db.Numbers.AddAsync(new Number() { Value = random.Next() });
                await db.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
