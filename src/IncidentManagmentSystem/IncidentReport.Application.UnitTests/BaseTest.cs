using System;
using IncidentReport.Application.Common;
using IncidentReport.Application.User;
using IncidentReport.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;

namespace IncidentReport.Application.UnitTests
{
    public class BaseTest
    {
        protected IIncidentReportDbContext IncidentReportDbContext { get; set; }
        protected ICurrentUserContext CurrentUserContext { get; set; }

        [SetUp]
        public void UnitTestBaseSetUp()
        {
            this.IncidentReportDbContext = this.CreateDbContext();
            this.CurrentUserContext = this.CreateUserContext();
        }

        private IIncidentReportDbContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<IncidentReportDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new IncidentReportDbContext(options);

            context.Database.EnsureCreated();
            return context;
        }

        private ICurrentUserContext CreateUserContext()
        {
            var currentUserServiceMock = new Mock<ICurrentUserContext>();
            currentUserServiceMock.Setup(m => m.UserId)
                .Returns(Guid.NewGuid());

            return currentUserServiceMock.Object;
        }
    }
}
