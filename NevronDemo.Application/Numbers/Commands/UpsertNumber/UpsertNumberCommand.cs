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

namespace NevronDemo.Application.Numbers.Commands.UpsertNumber
{
    public class UpsertNumberCommand: IRequest<int>
    {
        public int? Id { get; set; }
        public long Value { get; set; }

        public class UpsertNumberCommandHandler : IRequestHandler<UpsertNumberCommand, int>
        {
            private readonly INumbersDemoDbContext db;

            public UpsertNumberCommandHandler(INumbersDemoDbContext db)
            {
                this.db = db;
            }

            public async Task<int> Handle(UpsertNumberCommand request, CancellationToken cancellationToken)
            {
                Number entity;

                if (request.Id.HasValue)
                {
                    entity = await db.Numbers.FirstOrDefaultAsync(x => x.Id == request.Id.Value, cancellationToken);
                    if(entity == null)
                        throw new NotFoundException(nameof(Number), request.Id.Value);

                }
                else 
                {
                    entity = new Number();
                }

                entity.Value = request.Value;

                await db.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
        }
    }
}
