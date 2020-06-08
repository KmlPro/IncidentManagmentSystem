using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.Application.UnitTests;
using IncidentReport.Application.UseCases;
using IncidentReport.Domain.IncidentVerificationApplications.Enums;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace IncidentReport.Application.UnitTests.UseCases.UpdateDraftApplication
{
    [Category(CategoryTitle.Title)]
    public class UpdateDraftApplicationUseCaseTests : BaseTest
    {
        private readonly TestFixture _testFixture;
        public UpdateDraftApplicationUseCaseTests()
        {
            this._testFixture = new TestFixture();
        }

        [Test]
        public async Task SuspiciousEmployeeNotChanged_DraftUpdatedSuccessfully()
        {
            //Arrange
            var suspiciousEmployees = new List<Guid> { Guid.NewGuid() };
            var newDraftApplication = this._testFixture.CreateNewDraft(suspiciousEmployees, IncidentType.AdverseEffectForTheCompany);
            await this.IncidentReportDbContext.DraftApplication.AddAsync(newDraftApplication);

            var useCase = this._testFixture.CreateUseCaseWithRequiredFields(newDraftApplication.Id.Value, suspiciousEmployees, IncidentType.FinancialViolations);
            var outputPort = new UpdateDraftApplicationUseCaseOutputPort();
            var handler = new UpdateDraftApplicationUseCase(this.IncidentReportDbContext,
                this.IFileStorageService, outputPort);

            //Act
            var useCaseOutput =
                (UpdateDraftApplicationUseCaseOutputPort)await handler.Handle(useCase, new CancellationToken());

            //Assert
            var draftApplicationFromContext =
               await this.IncidentReportDbContext.DraftApplication.FirstAsync(x => x.Id.Value == useCaseOutput.Id);

            Assert.AreEqual(OutputPortInvokedMethod.Standard, useCaseOutput.InvokedOutputMethod);
            Assert.AreEqual(draftApplicationFromContext.ContentOfApplication.Title, useCase.Title);
            Assert.AreEqual(draftApplicationFromContext.ContentOfApplication.Description, useCase.Description);
            Assert.AreEqual(draftApplicationFromContext.IncidentType, useCase.IncidentType);
            Assert.AreEqual(1, draftApplicationFromContext.SuspiciousEmployees.Count);
        }

        [Test]
        public async Task TwoNewSuspiciousEmployeeAdded_OneRemoved_DraftUpdatedSuccessfully()
        {
            //Arrange
            var initialSuspiciousEmployees = new List<Guid> { Guid.NewGuid() };
            var newDraftApplication = this._testFixture.CreateNewDraft(initialSuspiciousEmployees, IncidentType.AdverseEffectForTheCompany);
            await this.IncidentReportDbContext.DraftApplication.AddAsync(newDraftApplication);

            var newSuspiciousEmployees = new List<Guid> { Guid.NewGuid(), Guid.NewGuid() };

            var useCase = this._testFixture.CreateUseCaseWithRequiredFields(newDraftApplication.Id.Value, newSuspiciousEmployees, IncidentType.FinancialViolations);
            var outputPort = new UpdateDraftApplicationUseCaseOutputPort();
            var handler = new UpdateDraftApplicationUseCase(this.IncidentReportDbContext,
                this.IFileStorageService, outputPort);

            //Act
            var useCaseOutput =
                (UpdateDraftApplicationUseCaseOutputPort)await handler.Handle(useCase, new CancellationToken());

            //Assert
            var draftApplicationFromContext =
               await this.IncidentReportDbContext.DraftApplication.FirstAsync(x => x.Id.Value == useCaseOutput.Id);

            Assert.AreEqual(OutputPortInvokedMethod.Standard, useCaseOutput.InvokedOutputMethod);
            Assert.AreEqual(2, draftApplicationFromContext.SuspiciousEmployees.Count);
        }
    }
}
