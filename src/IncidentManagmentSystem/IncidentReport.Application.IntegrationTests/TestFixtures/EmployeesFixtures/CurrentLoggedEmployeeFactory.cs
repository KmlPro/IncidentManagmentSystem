using BuildingBlocks.Domain.UnitTests;
using IncidentReport.Application.IntegrationTests.Mocks;
using IncidentReport.Domain.Entities.Employees;

namespace IncidentReport.Application.IntegrationTests.TestFixtures.EmployeesFixtures
{
    public static class CurrentLoggedEmployeeFactory
    {
        public static Employee Create()
        {
            var userId = new TestCurrentUserContext().UserId;
            return new Employee(userId, FakeData.Alpha(10), FakeData.Alpha(10));
        }
    }
}
