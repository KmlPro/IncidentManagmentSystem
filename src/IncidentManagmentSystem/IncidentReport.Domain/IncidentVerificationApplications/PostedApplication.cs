using System;
using System.Collections.Generic;
using System.Linq;
using BuildingBlocks.Domain;
using BuildingBlocks.Domain.Abstract;
using BuildingBlocks.Domain.Interfaces;
using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications.Enums;
using IncidentReport.Domain.IncidentVerificationApplications.Events;
using IncidentReport.Domain.IncidentVerificationApplications.Rules.ApplicantCannotBeSuspect;
using IncidentReport.Domain.IncidentVerificationApplications.Rules.IndicateAtLeastOneSuspect;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;
using JetBrains.Annotations;

namespace IncidentReport.Domain.IncidentVerificationApplications
{
    //this enitity will change, development is not completed here
    public class PostedApplication : Entity, IAggregateRoot
    {
        public PostedApplication(
            ContentOfApplication contentOfApplication,
            IncidentType incidentType,
            EmployeeId applicantId,
            List<EmployeeId> suspiciousEmployees,
            List<Attachment> attachments)
        {
            this.CheckRule(new IndicateAtLeastOneSuspectRule(suspiciousEmployees));
            this.CheckRule(new ApplicantCannotBeSuspectRule(suspiciousEmployees, applicantId));

            this.ApplicantId = applicantId ?? throw new ArgumentNullException(nameof(applicantId));
            this.ContentOfApplication =
                contentOfApplication ?? throw new ArgumentNullException(nameof(contentOfApplication));

            this.Id = new PostedApplicationId(Guid.NewGuid());
            this.IncidentType = incidentType;
            this.SuspiciousEmployees = suspiciousEmployees.Select(x => new SuspiciousEmployee(x)).ToList();
            this.Attachments = attachments;
            this.PostDate = SystemClock.Now;
            this.ApplicationNumber = new ApplicationNumber(this.PostDate, this.IncidentType);

            this.AddDomainEvent(new PostedApplicationDomainEvent(this.Id, this.ApplicationNumber,
                this.ContentOfApplication, this.IncidentType, this.ApplicantId, this.SuspiciousEmployees,
                this.Attachments, this.PostDate));
        }

        public PostedApplicationId Id { get; private set; }
        public ApplicationNumber ApplicationNumber { get; }
        public ContentOfApplication ContentOfApplication { get; }
        public IncidentType IncidentType { get; }
        public DateTime PostDate { get; }
        public EmployeeId ApplicantId { get; }
        public List<SuspiciousEmployee> SuspiciousEmployees { get; private set; }
        public List<Attachment> Attachments { get; private set; }

        private PostedApplication()
        {
        }
    }
}
