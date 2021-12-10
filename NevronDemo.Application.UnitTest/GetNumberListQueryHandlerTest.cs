using NevronDemo.Application.UnitTest.Common;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;
using static NevronDemo.Application.Numbers.Queries.GetNumbersList.GetNumberListQuery;
using NevronDemo.Application.Numbers.Queries.GetNumbersList;

namespace NevronDemo.Application.UnitTest
{
    [TestFixture]
    public class GetNumberListQueryHandlerTest : QueryTestBase
    {
        GetNumberListQueryHandler handler;

        [SetUp]
        public void Init()
        {
            handler = new GetNumberListQueryHandler(Context, Mapper);
        }

        [Test]
        public async Task GetNumbersShouldBe2()
        {
            var result = await handler.Handle(new GetNumberListQuery(), CancellationToken.None);

            Assert.AreEqual(result.Numbers.Count, 2);
        }

    }
}