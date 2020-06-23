using System;
using System.Collections.Generic;
using System.Linq;
using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Domain.UnitTests.IncidentVerificationApplications.Builders
{
    public class DraftApplicationBuilder
    {
        private EmployeeId _applicantId;
        private IEnumerable<Attachment> _attachments;
        private Func<AttachmentBuilder, AttachmentBuilder>[] _attachmentsDelegate;
        private ContentOfApplication _contentOfApplication;

        private Func<ContentOfApplicationBuilder, ContentOfApplicationBuilder> _contentOfApplicationDelegate;
        private IncidentType _incidentType;
        private List<EmployeeId> _suspiciousEmployees;
        private Func<SuspiciousEmployeesBuilder, SuspiciousEmployeesBuilder> _suspiciousEmployeesDelegate;

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

        public DraftApplicationBuilder SetContentOfApplication(
            Func<ContentOfApplicationBuilder, ContentOfApplicationBuilder> contentOfApplicationDelegate)
        {
            this._contentOfApplicationDelegate = contentOfApplicationDelegate;
            return this;
        }

        public DraftApplicationBuilder SetSuspiciousEmployees(
            Func<SuspiciousEmployeesBuilder, SuspiciousEmployeesBuilder> suspiciousEmployeesDelegate)
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
            return new DraftApplication(this._contentOfApplication, this._incidentType, this._applicantId,
                this._suspiciousEmployees);
        }

        private IEnumerable<Attachment> TryBuildAttachments()
        {
            return this._attachments != null
                ? this._attachmentsDelegate.Select(x => x(new AttachmentBuilder()).Build()).ToList()
                : null;
        }

        private List<EmployeeId> TryBuildSuspiciousEmployees()
        {
            return this._suspiciousEmployeesDelegate != null
                ? this._suspiciousEmployeesDelegate(new SuspiciousEmployeesBuilder()).Build()
                : new List<EmployeeId>();
        }

        private ContentOfApplication TryBuildContentOfApplication()
        {
            return this._contentOfApplicationDelegate != null
                ? this._contentOfApplicationDelegate(new ContentOfApplicationBuilder()).Build()
                : null;
        }
    }
}
