using MediatR;
using Microsoft.EntityFrameworkCore;
using NevronDemo.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NevronDemo.Application.Numbers.Queries.GetNumbersSum
{
    public  class GetNumbersSumQuery : IRequest<NumbersSumVM>
    {
        public class GetNumbersSumQueryHandler : IRequestHandler<GetNumbersSumQuery, NumbersSumVM>
        {
            private readonly INumbersDemoDbContext db;

            public GetNumbersSumQueryHandler(INumbersDemoDbContext db)
            {
                this.db = db;
            }

            public async Task<NumbersSumVM> Handle(GetNumbersSumQuery request, CancellationToken cancellationToken)
            {
                var numbers = await db.Numbers
                    .AsNoTracking()
                    .ToListAsync();

                if (numbers != null)
                {
                    return new NumbersSumVM()
                    {
                        HasNoResult = false,
                        Sum = numbers.Sum(number => number.Value) 
                    };
                }

                return new NumbersSumVM() { HasNoResult = true, Sum = null };
            }
        }
    }
}
