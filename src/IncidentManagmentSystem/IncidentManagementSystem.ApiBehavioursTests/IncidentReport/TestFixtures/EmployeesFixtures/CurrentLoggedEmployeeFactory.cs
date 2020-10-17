using BuildingBlocks.Domain.UnitTests;
using IncidentManagementSystem.ApiBehavioursTests.WebAppTestConfiguration;
using IncidentReport.Domain.Employees;

namespace IncidentManagementSystem.ApiBehavioursTests.IncidentReport.TestFixtures.EmployeesFixtures
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
