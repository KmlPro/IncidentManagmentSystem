using System;
using IncidentReport.Application.User;
using Moq;
using NUnit.Framework;

namespace IncidentReport.Application.UnitTests
{

    [SetUpFixture]
    public class SetUpTests
    {
        [OneTimeSetUp]
        public void GlobalSetup()
        {
            var currentUserServiceMock = new Mock<ICurrentUserContext>();
            currentUserServiceMock.Setup(m => m.UserId)
                .Returns(Guid.NewGuid());
        }

        [OneTimeTearDown]
        public void GlobalTeardown()
        {
            // Do logout here
        }
    }
}
