using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuildingBlocks.Domain.UnitTests;
using IncidentReport.Application.Boundaries.UpdateDraftApplications;
using IncidentReport.Application.Common;
using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications;
using IncidentReport.Domain.IncidentVerificationApplications.Enums;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Application.UnitTests.UseCases.UpdateDraftApplication
{
    public class TestFixture
    {
        private IIncidentReportDbContext IncidentReportDbContext { get; }

        public TestFixture(IIncidentReportDbContext incidentReportDbContext)
        {
            this.IncidentReportDbContext = incidentReportDbContext;
        }

        public async Task<UpdateDraftApplicationInput> PrepareUseCaseWithTestData(List<Guid> suspiciousEmployees, List<Guid> initialSuspiciousEmployees)
        {
            var newDraftApplication = this.CreateNewDraft(initialSuspiciousEmployees, IncidentType.AdverseEffectForTheCompany);
            await this.IncidentReportDbContext.DraftApplication.AddAsync(newDraftApplication);

            var useCase = this.CreateUseCaseWithRequiredFields(newDraftApplication.Id.Value, suspiciousEmployees, IncidentType.FinancialViolations);
            return useCase;
        }

        private DraftApplication CreateNewDraft(List<Guid> suspiciousEmployees, IncidentType incidentType)
        {
            var title = FakeData.AlphaNumeric(10);
            var description = FakeData.AlphaNumeric(99);
            var contentOfApplication = new ContentOfApplication(title, description);
            var applicantId = new EmployeeId(Guid.NewGuid());
            var suspiciousEmployeesIds = suspiciousEmployees.Select(x => new EmployeeId(x)).ToList();

            var draftApplication = new DraftApplication(contentOfApplication, incidentType, applicantId, suspiciousEmployeesIds);

            return draftApplication;
        }

        private UpdateDraftApplicationInput CreateUseCaseWithRequiredFields(Guid draftApplicationId, List<Guid> suspiciousEmployees, IncidentType incidentType)
        {
            var title = FakeData.AlphaNumeric(10);
            var description = FakeData.AlphaNumeric(99);

            return new UpdateDraftApplicationInput(
                draftApplicationId,
                title,
                description,
                incidentType,
                suspiciousEmployees,
                null,
                null);
        }
    }
}
