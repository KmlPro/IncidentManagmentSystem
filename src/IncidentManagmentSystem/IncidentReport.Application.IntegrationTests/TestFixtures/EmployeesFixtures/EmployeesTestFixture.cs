using IncidentReport.Domain.Employees.ValueObjects;
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

        public static EmployeeId CreateRandomEmployeeInDb()
        {
            var randomEmployee = RandomEmployeeFactory.Create();
            TestDatabaseInitializer.SeedDataForTest(dbContext =>
            {
                dbContext.Employee.Add(randomEmployee);
            });

            return randomEmployee.Id;
        }
    }
}
