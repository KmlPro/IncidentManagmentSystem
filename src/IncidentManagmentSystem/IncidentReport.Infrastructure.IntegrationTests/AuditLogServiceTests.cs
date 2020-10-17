using System;
using System.Collections.Generic;
using Autofac;
using BuildingBlocks.Domain.UnitTests;
using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications.DraftApplications;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;
using IncidentReport.Infrastructure.AuditLogs;
using IncidentReport.Infrastructure.Configuration.DIContainer;
using IncidentReport.Infrastructure.Persistence.NotDomainEntities;
using NUnit.Framework;

namespace IncidentReport.Infrastructure.IntegrationTests
{
    [Category(CategoryTitle.Title + " AuditLogService")]
    public class AuditLogServiceTests
    {
        public AuditLogServiceTests()
        {
            TestContainerBuilder.Build();
        }

        [Test]
        public void OneDomainEvent_OneAuditLogCreated()
        {
            var draftApplication = this.Create();
            using (var container = CompositionRoot.BeginLifetimeScope())
            {
                var auditLogService = container.Resolve<AuditLogService>();
                var auditLogs = auditLogService.CreateFromDomainEvents<DraftApplicationAuditLog>(draftApplication);
                Assert.AreEqual(1, auditLogs.Count);
            }
        }

        private DraftApplication Create()
        {
            var draftApplication = new DraftApplication(
                new ContentOfApplication(FakeData.Alpha(12), FakeData.Alpha(100)),
                IncidentType.AdverseEffectForTheCompany, new EmployeeId(Guid.NewGuid()),
                new List<EmployeeId>() { new EmployeeId(Guid.NewGuid()) });
            return draftApplication;
        }
    }
}
