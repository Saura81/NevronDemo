using MediatR;
using Microsoft.EntityFrameworkCore;
using NevronDemo.Application.Common.Exceptions;
using NevronDemo.Application.Common.Interfaces;
using NevronDemo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NevronDemo.Application.Numbers.Commands.DeleteNumber
{
    public class DeleteNumberCommand : IRequest
    {
        public int Id { get; set; }

        public class DeleteNumberCommandHandler : IRequestHandler<DeleteNumberCommand>
        {
            private readonly INumbersDemoDbContext db;
            public DeleteNumberCommandHandler(INumbersDemoDbContext db)
            {
                this.db = db;
            }

            public async Task<Unit> Handle(DeleteNumberCommand request, CancellationToken cancellationToken)
            {
                var entities = await db.Numbers.ToListAsync();

                if (entities == null)
                    throw new NotElementsOnDatabaseException(nameof(Number));

                db.Numbers.RemoveRange(entities);
                await db.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
