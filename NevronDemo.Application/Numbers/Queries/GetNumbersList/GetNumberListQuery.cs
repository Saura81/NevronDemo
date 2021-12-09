using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NevronDemo.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace NevronDemo.Application.Numbers.Queries.GetNumbersList
{
    public class GetNumberListQuery : IRequest<NumbersListVM>
    {
        public class GetNumberListQueryHandler : IRequestHandler<GetNumberListQuery, NumbersListVM>
        {
            private readonly INumbersDemoDbContext db;
            private IMapper mapper;

            public GetNumberListQueryHandler(INumbersDemoDbContext db,
             IMapper mapper)
            {
                this.db = db;
                this.mapper = mapper;
            }

            public async Task<NumbersListVM> Handle(GetNumberListQuery request, CancellationToken cancellationToken)
            {
                var numbers = await db.Numbers
                    .AsNoTracking()
                    .ProjectTo<NumberDTO>(mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                return new NumbersListVM() { Numbers = numbers };
            }
        }
    }
}
