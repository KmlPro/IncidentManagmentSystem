using System;
using System.Collections.Generic;
using System.Linq;
using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications;
using IncidentReport.Domain.IncidentVerificationApplications.IncidentApplications;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Domain.UnitTests.IncidentVerificationApplications.Builders
{
    public class IncidentApplicationBuilder
    {
        private EmployeeId _applicantId;
        private List<Attachment> _attachments;

        private Func<AttachmentBuilder, AttachmentBuilder>[] _attachmentsDelegate =
            new Func<AttachmentBuilder, AttachmentBuilder>[0];

        private Content _content;
        private Title _title;

        private IncidentType _incidentType;
        private List<EmployeeId> _suspiciousEmployees;
        private Func<SuspiciousEmployeesBuilder, SuspiciousEmployeesBuilder> _suspiciousEmployeesDelegate;

        public IncidentApplicationBuilder SetIncidentType(IncidentType incidentType)
        {
            this._incidentType = incidentType;
            return this;
        }

        public IncidentApplicationBuilder SetApplicantId(EmployeeId employeeId)
        {
            this._applicantId = employeeId;
            return this;
        }

        public IncidentApplicationBuilder SetContent(string content)
        {
            this._content = new Content(content);
            return this;
        }

        public IncidentApplicationBuilder SetTitle(string title)
        {
            this._title = new Title(title);
            return this;
        }

        public IncidentApplicationBuilder SetSuspiciousEmployees(
            Func<SuspiciousEmployeesBuilder, SuspiciousEmployeesBuilder> suspiciousEmployeesDelegate)
        {
            this._suspiciousEmployeesDelegate = suspiciousEmployeesDelegate;
            return this;
        }

        public IncidentApplicationBuilder SetAttachments(
            Func<AttachmentBuilder, AttachmentBuilder>[] attachmentsDelegate)
        {
            this._attachmentsDelegate = attachmentsDelegate;
            return this;
        }

        public IncidentApplication Build()
        {
            this._suspiciousEmployees = this.TryBuildSuspiciousEmployees();
            this._attachments = this.TryBuildAttachments();
            return IncidentApplication.Create(this._title,this._content, this._incidentType, this._applicantId,
                this._suspiciousEmployees, this._attachments);
        }

        private List<EmployeeId> TryBuildSuspiciousEmployees()
        {
            return this._suspiciousEmployeesDelegate != null
                ? this._suspiciousEmployeesDelegate(new SuspiciousEmployeesBuilder()).Build()
                : new List<EmployeeId>();
        }

        private List<Attachment> TryBuildAttachments()
        {
            return this._attachmentsDelegate.Select(a => a(new AttachmentBuilder()).Build()).ToList();
        }
    }
}
