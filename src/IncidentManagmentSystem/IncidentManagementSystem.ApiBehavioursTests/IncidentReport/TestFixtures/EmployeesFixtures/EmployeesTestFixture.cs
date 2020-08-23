using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Infrastructure.ForTests;

namespace IncidentManagementSystem.ApiBehavioursTests.IncidentReport.TestFixtures.EmployeesFixtures
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
    }
}
