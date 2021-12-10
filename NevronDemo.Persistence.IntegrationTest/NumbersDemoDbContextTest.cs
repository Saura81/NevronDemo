using Microsoft.EntityFrameworkCore;
using Moq;
using NevronDemo.Application.Common.Interfaces;
using NevronDemo.Common;
using NUnit.Framework;
using System;
using NevronDemo.Domain.Entities;
using System.Threading.Tasks;

namespace NevronDemo.Persistence.IntegrationTest
{
    [TestFixture]
    public class NumbersDemoDbContextTest : IDisposable
    {
        private readonly string userId;
        private readonly DateTime dateTime;
        private readonly Mock<IDateTime> dateTimeMock;
        private readonly Mock<ICurrentUserService> currentUserServiceMock;
        private readonly NumbersDemoDbContext db;

        public NumbersDemoDbContextTest()
        {
            dateTime = new DateTime(3001, 1, 1);
            dateTimeMock = new Mock<IDateTime>();
            dateTimeMock.Setup(m => m.Now).Returns(dateTime);

            userId = "00000000-0000-0000-0000-000000000000";
            currentUserServiceMock = new Mock<ICurrentUserService>();
            currentUserServiceMock.Setup(m => m.UserId).Returns(userId);

            var options = new DbContextOptionsBuilder<NumbersDemoDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            db = new NumbersDemoDbContext(dateTimeMock.Object, currentUserServiceMock.Object, options);

            db.Numbers.Add(new Number
            {
                Value = 123131
            });

            db.SaveChanges();

        }

        [Test]
        public async Task SaveChangesAsyncGivenNewNumberShouldSetAuditableProperties()
        {
            var number = new Number
            {
                Value = 9789089986542
            };

            db.Numbers.Add(number);

            await db.SaveChangesAsync();

            Assert.AreEqual(dateTime, number.Created);
            Assert.AreEqual(userId, number.CreatedBy);
        }

        [Test]
        public async Task SaveChangesAsyncGivenExistingNumberShouldSetAuditableProperties()
        {
            var number = await db.Numbers.FindAsync(1);

            number.Value = 324342242;

            await db.SaveChangesAsync();

            Assert.IsNotNull(number.LastUpdatedBy);
            Assert.AreEqual(userId, number.LastUpdatedBy);
            Assert.AreEqual(dateTime, number.LastUpdated);
        }

        public void Dispose()
        {
            db?.Dispose();
        }


    }
}