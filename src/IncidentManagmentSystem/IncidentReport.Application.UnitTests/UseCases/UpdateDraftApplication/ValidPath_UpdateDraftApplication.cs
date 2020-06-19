using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.Application.UnitTests;
using IncidentReport.Application.UseCases;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace IncidentReport.Application.UnitTests.UseCases.UpdateDraftApplication
{
    [Category(CategoryTitle.Title + " UpdateDraftApplicationUseCase")]
    public class ValidPath_UpdateDraftApplication : BaseTest
    {
        private readonly TestFixture _testFixture;
        public ValidPath_UpdateDraftApplication()
        {
            this._testFixture = new TestFixture(this.IncidentReportDbContext);
        }

        [Test]
        public async Task SuspiciousEmployeeNotChanged_DraftUpdatedSuccessfully()
        {
            //Arrange
            var initialSuspiciousEmployees = new List<Guid> { Guid.NewGuid() };
            var suspiciousEmployees = initialSuspiciousEmployees;

            var useCase = await this._testFixture.PrepareUseCaseWithTestData(suspiciousEmployees, initialSuspiciousEmployees);
            var handler = new UpdateDraftApplicationUseCase(this.IncidentReportDbContext,
                this.IFileStorageService, new UpdateDraftApplicationUseCaseOutputPort());

            //Act
            var useCaseOutput =
                (UpdateDraftApplicationUseCaseOutputPort)await handler.Handle(useCase, new CancellationToken());

            //Assert
            var draftApplicationFromContext = await this._testFixture.GetDraftFromContext(useCaseOutput.Id);
            
            Assert.AreEqual(OutputPortInvokedMethod.Standard, useCaseOutput.InvokedOutputMethod);
            Assert.AreEqual(1, draftApplicationFromContext.SuspiciousEmployees.Count);
        }

        [Test]
        public async Task TwoNewSuspiciousEmployeeAdded_OneRemoved_DraftUpdatedSuccessfully()
        {
            //Arrange
            var initialSuspiciousEmployees = new List<Guid> { Guid.NewGuid() };
            var newSuspiciousEmployees = new List<Guid> { Guid.NewGuid(), Guid.NewGuid() };

            var useCase =
               await this._testFixture.PrepareUseCaseWithTestData(newSuspiciousEmployees, initialSuspiciousEmployees);
            var handler = new UpdateDraftApplicationUseCase(this.IncidentReportDbContext,
                this.IFileStorageService, new UpdateDraftApplicationUseCaseOutputPort());

            //Act
            var useCaseOutput =
                (UpdateDraftApplicationUseCaseOutputPort)await handler.Handle(useCase, new CancellationToken());

            //Assert
            var draftApplicationFromContext = await this._testFixture.GetDraftFromContext(useCaseOutput.Id);

            Assert.AreEqual(OutputPortInvokedMethod.Standard, useCaseOutput.InvokedOutputMethod);
            Assert.AreEqual(2, draftApplicationFromContext.SuspiciousEmployees.Count);
        }
    }
}
