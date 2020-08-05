using System;
using System.Collections.Generic;
using System.Linq;
using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications;
using IncidentReport.Domain.IncidentVerificationApplications.Applications;
using IncidentReport.Domain.IncidentVerificationApplications.Applications.States;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Domain.UnitTests.IncidentVerificationApplications.Builders
{
    public class PostedApplicationBuilder
    {
        private EmployeeId _applicantId;
        private List<Attachment> _attachments;
        private Func<AttachmentBuilder, AttachmentBuilder>[] _attachmentsDelegate = new Func<AttachmentBuilder, AttachmentBuilder>[0];
        private ContentOfApplication _contentOfApplication;

        private Func<ContentOfApplicationBuilder, ContentOfApplicationBuilder> _contentOfApplicationDelegate;
        private IncidentType _incidentType;
        private List<EmployeeId> _suspiciousEmployees;
        private Func<SuspiciousEmployeesBuilder, SuspiciousEmployeesBuilder> _suspiciousEmployeesDelegate;

        public PostedApplicationBuilder SetIncidentType(IncidentType incidentType)
        {
            this._incidentType = incidentType;
            return this;
        }

        public PostedApplicationBuilder SetApplicantId(EmployeeId employeeId)
        {
            this._applicantId = employeeId;
            return this;
        }

        public PostedApplicationBuilder SetContentOfApplication(
            Func<ContentOfApplicationBuilder, ContentOfApplicationBuilder> contentOfApplicationDelegate)
        {
            this._contentOfApplicationDelegate = contentOfApplicationDelegate;
            return this;
        }

        public PostedApplicationBuilder SetSuspiciousEmployees(
            Func<SuspiciousEmployeesBuilder, SuspiciousEmployeesBuilder> suspiciousEmployeesDelegate)
        {
            this._suspiciousEmployeesDelegate = suspiciousEmployeesDelegate;
            return this;
        }

        public PostedApplicationBuilder SetAttachments(
            Func<AttachmentBuilder, AttachmentBuilder>[] attachmentsDelegate)
        {
            this._attachmentsDelegate = attachmentsDelegate;
            return this;
        }

        public PostedApplication Build()
        {
            this._contentOfApplication = this.TryBuildContentOfApplication();
            this._suspiciousEmployees = this.TryBuildSuspiciousEmployees();
            this._attachments = this.TryBuildAttachments();
            var application = Application.Create(this._contentOfApplication, this._incidentType, this._applicantId,
                this._suspiciousEmployees, this._attachments);
            return application.Post();
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

        private ContentOfApplication TryBuildContentOfApplication()
        {
            return this._contentOfApplicationDelegate?.Invoke(new ContentOfApplicationBuilder()).Build();
        }
    }
}
