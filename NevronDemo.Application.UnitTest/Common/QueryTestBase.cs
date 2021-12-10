using AutoMapper;
using NevronDemo.Application.Common.Mappings;
using NevronDemo.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace NevronDemo.Application.UnitTest.Common
{
    public class QueryTestBase : IDisposable
    {
        public NumbersDemoDbContext Context { get; private set; }
        public IMapper Mapper { get; private set; }

        public QueryTestBase()
        {
            Context = NumbersDemoDbContextFactory.Create();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            NumbersDemoDbContextFactory.Destroy(Context);
        }
    }
}
