using System;
using BuildingBlocks.Domain.UnitTests;
using IncidentReport.Domain.Entities.Employees;

namespace IncidentManagementSystem.ApiBehavioursTests.IncidentReport.TestFixtures.EmployeesFixtures
{
    public static class RandomEmployeeFactory
    {
        public static Employee Create()
        {
            return new Employee(Guid.NewGuid(), FakeData.Alpha(10), FakeData.Alpha(10));
        }
    }
}
