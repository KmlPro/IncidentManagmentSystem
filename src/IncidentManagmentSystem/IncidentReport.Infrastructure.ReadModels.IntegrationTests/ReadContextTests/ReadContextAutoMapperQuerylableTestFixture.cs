using System;
using System.Collections.Generic;
using Autofac;
using BuildingBlocks.Domain.UnitTests;
using IncidentReport.ReadModels;
using IncidentReport.ReadModels.DbEntities;

namespace IncidentReport.Infrastructure.ReadModels.IntegrationTests.ReadContextTests
{
    public class ReadContextAutoMapperQuerylableTestFixture
    {
        public void AddDraftApplicationWithEmployeesInDatabase(ILifetimeScope scope)
        {
            var readContext = scope.Resolve<IncidentReportReadDbContext>();
            readContext.Database.EnsureCreated();

            readContext.DraftApplication.Add(new DraftApplication
            {
                Id = Guid.NewGuid(),
                IncidentTypeValue = "FinancialViolations",
                Title = FakeData.Alpha(10),
                Description = FakeData.Alpha(15),
                Applicant = this.CreateEmployee(),
                Attachment = new List<Attachment>()
                {
                    CreateAttachment()
                },
                DraftApplicationSuspiciousEmployee = new List<DraftApplicationSuspiciousEmployee>()
                {
                    new DraftApplicationSuspiciousEmployee()
                    {
                        Id = Guid.NewGuid(), Employee = this.CreateEmployee()
                    },
                    new DraftApplicationSuspiciousEmployee
                    {
                        Id = Guid.NewGuid(), Employee = this.CreateEmployee()
                    }
                }
            });

            readContext.SaveChanges();
        }

        private static Attachment CreateAttachment()
        {
            return new Attachment()
            {
                Id = Guid.NewGuid(),
                FileName = "test.txt",
                StorageId = Guid.NewGuid()
            };
        }

        private Employee CreateEmployee()
        {
            return new Employee() {Id = Guid.NewGuid(), Name = "Name", Surname = "Surname"};
        }
    }
}
