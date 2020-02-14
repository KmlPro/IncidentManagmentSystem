using System;
using BuildingBlocks.Application;
using Moq;

namespace IncidentReport.Application.UnitTests.Mocks
{
    internal class MockCurrentUserContextFactory
    {
        public ICurrentUserContext CreateUserContext()
        {
            var currentUserServiceMock = new Mock<ICurrentUserContext>();
            currentUserServiceMock.Setup(m => m.UserId)
                .Returns(Guid.NewGuid());

            return currentUserServiceMock.Object;
        }
    }
}
