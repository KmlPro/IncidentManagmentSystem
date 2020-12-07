using System;
using BuildingBlocks.Application;

namespace IncidentReport.Application.IntegrationTests.Mocks
{
    public class TestCurrentUserContext : ICurrentUserContext
    {
        public Guid UserId => new Guid("bf52748c-0199-4f82-b170-c6d7910ecef6");
    }
}
