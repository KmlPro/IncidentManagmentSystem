using System;
using System.Collections.Generic;
using System.Linq;
using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications;
using IncidentReport.Domain.IncidentVerificationApplications.Enums;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Domain.UnitTests.IncidentVerificationApplications.Builders
{
    public class DraftApplicationBuilder
    {
        private ContentOfApplication _contentOfApplication;
        private IncidentType? _incidentType;
        private EmployeeId _applicantId;
        private SuspiciousEmployees _suspiciousEmployees;
        private IEnumerable<Attachment> _attachments;

        private Func<ContentOfApplicationBuilder, ContentOfApplicationBuilder> _contentOfApplicationDelegate;
        private Func<SuspiciousEmployeesBuilder, SuspiciousEmployeesBuilder> _suspiciousEmployeesDelegate;
        private Func<AttachmentBuilder, AttachmentBuilder>[] _attachmentsDelegate;

        public DraftApplicationBuilder SetIncidentType(IncidentType incidentType)
        {
            this._incidentType = incidentType;
            return this;
        }

        public DraftApplicationBuilder SetApplicantId(EmployeeId employeeId)
        {
            this._applicantId = employeeId;
            return this;
        }

        public DraftApplicationBuilder SetContentOfApplication(Func<ContentOfApplicationBuilder, ContentOfApplicationBuilder> contentOfApplicationDelegate)
        {
            this._contentOfApplicationDelegate = contentOfApplicationDelegate;
            return this;
        }

        public DraftApplicationBuilder SetSuspiciousEmployees(Func<SuspiciousEmployeesBuilder, SuspiciousEmployeesBuilder> suspiciousEmployeesDelegate)
        {
            this._suspiciousEmployeesDelegate = suspiciousEmployeesDelegate;
            return this;
        }

        public DraftApplicationBuilder SetAttachments(Func<AttachmentBuilder, AttachmentBuilder>[] attachmentsDelegate)
        {
            this._attachmentsDelegate = attachmentsDelegate;
            return this;
        }

        public DraftApplication Build()
        {
            this._contentOfApplication = this.TryBuildContentOfApplication();
            this._suspiciousEmployees = this.TryBuildSuspiciousEmployees();
            this._attachments = this.TryBuildAttachments();
            return new DraftApplication(this._contentOfApplication, this._incidentType, this._applicantId, this._suspiciousEmployees);
        }

        private IEnumerable<Attachment> TryBuildAttachments()
        {
            return this._attachments != null ? this._attachmentsDelegate.Select(x => x(new AttachmentBuilder()).Build()).ToList() : null;
        }

        private SuspiciousEmployees TryBuildSuspiciousEmployees()
        {
            return this._suspiciousEmployeesDelegate != null ? this._suspiciousEmployeesDelegate(new SuspiciousEmployeesBuilder()).Build() : null;
        }

        private ContentOfApplication TryBuildContentOfApplication()
        {
            return this._contentOfApplicationDelegate != null ? this._contentOfApplicationDelegate(new ContentOfApplicationBuilder()).Build() : null;
        }
    }
}
