using System.Collections.Generic;
using System.Linq;
using IncidentReport.Domain.Entities.Employees;
using IncidentReport.Domain.Entities.Employees.ValueObjects;
using IncidentReport.Infrastructure.ForTests;

namespace IncidentReport.Application.IntegrationTests.TestFixtures.EmployeesFixtures
{
    public static class EmployeesTestFixture
    {
        public static (EmployeeId, EmployeeId) PrepareApplicantAndRandomEmployeeInDb()
        {
            var suspiciousEmployee = RandomEmployeeFactory.Create();
            var applicant = CurrentLoggedEmployeeFactory.Create();

            TestDatabaseInitializer.SeedDataForTest(dbContext =>
            {
                dbContext.Employee.Add(applicant);
                dbContext.Employee.Add(suspiciousEmployee);
            });

            return (applicant.Id, suspiciousEmployee.Id);
        }

        public static List<EmployeeId> CreateRandomEmployeeInDb(int count)
        {
            var employees = new List<Employee>();
            for (var i = 0; i < count; i++)
            {
                employees.Add(RandomEmployeeFactory.Create());
            }

            TestDatabaseInitializer.SeedDataForTest(dbContext =>
            {
                dbContext.Employee.AddRange(employees);
            });

            return employees.Select(x => x.Id).ToList();
        }
    }
}
