using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuildingBlocks.Domain.UnitTests;
using IncidentReport.Application.Boundaries.UpdateDraftApplications;
using IncidentReport.Application.Common;
using IncidentReport.Application.Files;
using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications;
using IncidentReport.Domain.IncidentVerificationApplications.Enums;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;
using Microsoft.EntityFrameworkCore;

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
            var newDraftApplication = this.CreateNewDraft(initialSuspiciousEmployees);
            await this.IncidentReportDbContext.DraftApplication.AddAsync(newDraftApplication);

            var useCase = this.CreateUseCaseWithRequiredFields(newDraftApplication.Id.Value, suspiciousEmployees, IncidentType.FinancialViolations, null,null);
            return useCase;
        }

        public async Task<UpdateDraftApplicationInput> PrepareUseCaseWithTestData(List<FileData> addedAttachments, List<Guid> deleteAttachments, List<Attachment> initialAttachments)
        {
            var suspiciousEmployees = new List<Guid>() { Guid.NewGuid() };
            var newDraftApplication = this.CreateNewDraft(null);
            newDraftApplication.AddAttachments(initialAttachments);
            await this.IncidentReportDbContext.DraftApplication.AddAsync(newDraftApplication);

            var useCase = this.CreateUseCaseWithRequiredFields(newDraftApplication.Id.Value, suspiciousEmployees, IncidentType.FinancialViolations, addedAttachments, deleteAttachments);
            return useCase;
        }

        public async Task<DraftApplication> GetDraftFromContext(Guid id)
        {
            return await this.IncidentReportDbContext.DraftApplication.FirstAsync(x => x.Id.Value == id);
        }

        private DraftApplication CreateNewDraft(List<Guid> suspiciousEmployees)
        {
            var title = FakeData.AlphaNumeric(10);
            var incidentType = IncidentType.AdverseEffectForTheCompany;
            var description = FakeData.AlphaNumeric(99);
            var contentOfApplication = new ContentOfApplication(title, description);
            var applicantId = new EmployeeId(Guid.NewGuid());
            var suspiciousEmployeesIds = suspiciousEmployees.Select(x => new EmployeeId(x)).ToList();

            var draftApplication = new DraftApplication(contentOfApplication, incidentType, applicantId, suspiciousEmployeesIds);

            return draftApplication;
        }

        private UpdateDraftApplicationInput CreateUseCaseWithRequiredFields(Guid draftApplicationId, List<Guid> suspiciousEmployees, IncidentType incidentType, List<FileData> addedAttachments, List<Guid> deleteAttachments)
        {
            var title = FakeData.AlphaNumeric(10);
            var description = FakeData.AlphaNumeric(99);

            return new UpdateDraftApplicationInput(
                draftApplicationId,
                title,
                description,
                incidentType,
                suspiciousEmployees,
                addedAttachments,
                deleteAttachments);
        }
    }
}
