//kbytner 17.03.2020 -- TO DO repair tests

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading;
//using System.Threading.Tasks;
//using BuildingBlocks.Domain.UnitTests;
//using IncidentReport.Application.Files;
//using IncidentReport.Application.Files.Exceptions;
//using IncidentReport.Domain.IncidentVerificationApplications;
//using IncidentReport.Domain.IncidentVerificationApplications.Enums;
//using NUnit.Framework;

//namespace IncidentReport.Application.UnitTests.UseCases
//{
//    public class CreateDraftApplicationTests : BaseTest
//    {
//        [Test]
//        public async Task CreateIncidentVerificationApplicationCommand_OnlyWithoutAttachments_DraftCreatedSuccessfully()
//        {
//            //Arrange
//            var command = this.CreateCommandWithRequiredFields();
//            var handler = new CreateDraftApplicationCommandHandler(this.IncidentReportDbContext, this.CurrentUserContext, this.IFileStorageService);

//            //Act
//            await handler.Handle(command, new CancellationToken());

//            //Assert
//            var draftFromContext = this.IncidentReportDbContext.DraftIncidentVerificationApplication.First();
//            this.CompareDraftFromContextWithCommandData(command, draftFromContext);
//        }

//        [Test]
//        public async Task CreateIncidentVerificationApplicationCommand_WithAttachments_DraftCreatedSuccessfully()
//        {
//            //Arrange
//            var command = this.CreateCommandWithRequiredFields(new List<string>() { "testFile.pdf" });
//            var handler = new CreateDraftApplicationCommandHandler(this.IncidentReportDbContext, this.CurrentUserContext, this.IFileStorageService);

//            //Act
//            await handler.Handle(command, new CancellationToken());

//            //Assert
//            var draftFromContext = this.IncidentReportDbContext.DraftIncidentVerificationApplication.First();
//            this.CompareDraftFromContextWithCommandData(command, draftFromContext);
//        }

//        [Test]
//        public void CreateIncidentVerificationApplicationCommand_AttachmentsWithUnallowedExtension_DraftNotCreated()
//        {
//            AssertApplicationLayerException<UnallowedFileExtensionException>(() => this.CreateCommandWithRequiredFields(new List<string>() { "testFile.exe" }));
//        }

//        [Test]
//        public void CreateIncidentVerificationApplicationCommand_AttachmentsWithoutExtension_DraftNotCreated()
//        {
//            AssertApplicationLayerException<FileExtensionNotRecognizedException>(() => this.CreateCommandWithRequiredFields(new List<string>() { "testFile" }));
//        }

//        private void CompareDraftFromContextWithCommandData(CreateDraftApplicationCommand command, DraftApplication draftFromContext)
//        {
//            Assert.AreEqual(command.Title, draftFromContext.ContentOfApplication.Title);
//            Assert.AreEqual(command.Description, draftFromContext.ContentOfApplication.Description);
//            Assert.AreEqual(command.IncidentType, draftFromContext.IncidentType);
//            Assert.AreEqual(this.CurrentUserContext.UserId, draftFromContext.ApplicantId.Value);

//            if (command.Attachments == null)
//            {
//                Assert.AreEqual(0, draftFromContext.IncidentVerificationApplicationAttachments.Attachments.Count());
//            }
//            else
//            {
//                Assert.AreEqual(command.Attachments.Count(), draftFromContext.IncidentVerificationApplicationAttachments.Attachments.Count());
//                Assert.IsTrue(draftFromContext.IncidentVerificationApplicationAttachments.Attachments.Any(x => command.Attachments.Any(z => z.FileName == x.FileInfo.FileName)));
//            }

//            Assert.AreEqual(command.SuspiciousEmployees.Count(), draftFromContext.SuspiciousEmployees.Employees.Count());
//            Assert.IsTrue(draftFromContext.SuspiciousEmployees.Employees.Any(x => command.SuspiciousEmployees.Any(z => x.Value == z)));
//        }

//        private CreateDraftApplicationCommand CreateCommandWithRequiredFields(List<string> fileNames = null)
//        {
//            var title = FakeData.AlphaNumeric(10);
//            var description = FakeData.AlphaNumeric(99);
//            var incidentType = IncidentType.AdverseEffectForTheCompany;
//            var suspiciousEmployees = new List<Guid> { Guid.NewGuid() };
//            var attachments = fileNames?.Select(x => new FileData(x, new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 })).ToList();

//            return new CreateDraftApplicationCommand(
//                  title,
//                  description,
//                  incidentType,
//                  suspiciousEmployees,
//                  attachments);
//        }
//    }
//}