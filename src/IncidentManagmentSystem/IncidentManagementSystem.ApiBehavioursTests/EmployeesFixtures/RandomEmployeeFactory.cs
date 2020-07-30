using System;
using BuildingBlocks.Domain.UnitTests;
using IncidentReport.Domain.Employees;

namespace IncidentManagementSystem.ApiBehavioursTests.EmployeesFixtures
{
    public static class RandomEmployeeFactory
    {
        public static Employee Create()
        {
            return new Employee(Guid.Empty, FakeData.Alpha(10), FakeData.Alpha(10));
        }
    }
}
