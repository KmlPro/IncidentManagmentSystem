using System;
using BuildingBlocks.Domain.UnitTests;
using IncidentReport.Domain.Employees;

namespace IncidentReport.Application.IntegrationTests.EmployeesFixtures
{
    public static class RandomEmployeeFactory
    {
        public static Employee Create()
        {
            return new Employee(Guid.NewGuid(), FakeData.Alpha(10), FakeData.Alpha(10));
        }
    }
}
