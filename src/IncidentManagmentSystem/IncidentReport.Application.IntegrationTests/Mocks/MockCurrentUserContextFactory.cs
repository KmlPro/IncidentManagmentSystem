using System;
using BuildingBlocks.Application;
using Moq;

namespace IncidentReport.Application.IntegrationTests.Mocks
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
