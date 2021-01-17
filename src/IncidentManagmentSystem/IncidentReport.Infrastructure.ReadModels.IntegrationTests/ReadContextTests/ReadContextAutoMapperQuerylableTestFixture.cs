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

            readContext.DraftApplications.Add(new DraftApplication
            {
                Id = Guid.NewGuid(),
                IncidentType = "FinancialViolations",
                Title = FakeData.Alpha(10),
                Content = FakeData.Alpha(15),
                Applicant = this.CreateEmployee(),
                Attachments = new List<Attachment>()
                {
                    CreateAttachment()
                },
                DraftApplicationSuspiciousEmployees = new List<DraftApplicationSuspiciousEmployee>()
                {
                    new DraftApplicationSuspiciousEmployee()
                    {
                       Employee = this.CreateEmployee()
                    },
                    new DraftApplicationSuspiciousEmployee
                    {
                        Employee = this.CreateEmployee()
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
