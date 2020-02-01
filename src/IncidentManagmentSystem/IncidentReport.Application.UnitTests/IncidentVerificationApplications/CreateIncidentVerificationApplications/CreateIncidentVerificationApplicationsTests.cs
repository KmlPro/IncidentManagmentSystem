using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IncidentReport.Application.Common.File;
using IncidentReport.Application.IncidentVerificationApplications.CreateIncidentVerificationApplications;
using IncidentReport.Domain.IncidentVerificationApplications;
using IncidentReport.Domain.IncidentVerificationApplications.Enums;
using NUnit.Framework;

namespace IncidentReport.Application.UnitTests.IncidentVerificationApplications.CreateIncidentVerificationApplications
{
    public class CreateIncidentVerificationApplicationsTests : BaseTest
    {
        [Test]
        public async Task CreateIncidentVerificationApplicationCommand_OnlyWithoutAttachments_DraftCreatedSuccessfullyAsync()
        {
            //Arrange
            var command = this.CreateCommandWithRequiredFields(false);
            var handler = new CreateIncidentVerificationApplicationCommandHandler(this.IncidentReportDbContext, this.CurrentUserContext, this.IFileStorageService);

            //Act
            await handler.Handle(command, new CancellationToken());

            //Assert
            var draftFromContext = this.IncidentReportDbContext.DraftIncidentVerificationApplication.First();
            this.CompareDraftFromContextWithCommandData(command, draftFromContext);
        }

        [Test]
        public async Task CreateIncidentVerificationApplicationCommand_WithAttachments_DraftCreatedSuccessfullyAsync()
        {
            //Arrange
            var command = this.CreateCommandWithRequiredFields(true);
            var handler = new CreateIncidentVerificationApplicationCommandHandler(this.IncidentReportDbContext, this.CurrentUserContext, this.IFileStorageService);

            //Act
            await handler.Handle(command, new CancellationToken());

            //Assert
            var draftFromContext = this.IncidentReportDbContext.DraftIncidentVerificationApplication.First();
            this.CompareDraftFromContextWithCommandData(command, draftFromContext);
        }

        private void CompareDraftFromContextWithCommandData(CreateIncidentVerificationApplicationCommand command, DraftIncidentVerificationApplication draftFromContext)
        {
            Assert.AreEqual(command.Title, draftFromContext.ContentOfApplication.Title);
            Assert.AreEqual(command.Description, draftFromContext.ContentOfApplication.Description);
            Assert.AreEqual(command.IncidentType, draftFromContext.IncidentType);
            Assert.AreEqual(this.CurrentUserContext.UserId, draftFromContext.ApplicantId.Value);

            if (command.Attachments == null)
            {
                Assert.AreEqual(0, draftFromContext.IncidentVerificationApplicationAttachments.Attachments.Count());
            }
            else
            {
                Assert.AreEqual(command.Attachments.Count(), draftFromContext.IncidentVerificationApplicationAttachments.Attachments.Count());
                Assert.IsTrue(draftFromContext.IncidentVerificationApplicationAttachments.Attachments.Any(x => command.Attachments.Any(z => z.FileName == x.FileInfo.FileName)));
            }

            Assert.AreEqual(command.SuspiciousEmployees.Count(), draftFromContext.SuspiciousEmployees.Employees.Count());
            Assert.IsTrue(draftFromContext.SuspiciousEmployees.Employees.Any(x => command.SuspiciousEmployees.Any(z => x.Value == z)));
        }

        private CreateIncidentVerificationApplicationCommand CreateCommandWithRequiredFields(bool withAttachments)
        {
            var title = Faker.StringFaker.AlphaNumeric(10);
            var description = Faker.StringFaker.AlphaNumeric(99);
            var incidentType = IncidentType.AdverseEffectForTheCompany;
            var suspiciousEmployees = new List<Guid> { Guid.NewGuid() };
            var attachments = withAttachments ? new List<FileData> { new FileData("dupa.pdf", new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 }) } : null;

            return new CreateIncidentVerificationApplicationCommand(
                  title,
                  description,
                  incidentType,
                  suspiciousEmployees,
                  attachments);
        }
    }
}
