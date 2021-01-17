using System;
using System.Collections.Generic;
using IncidentReport.Domain.Employees.ValueObjects;
using IncidentReport.Domain.IncidentVerificationApplications.DraftApplications;
using IncidentReport.Domain.IncidentVerificationApplications.ValueObjects;

namespace IncidentReport.Domain.UnitTests.IncidentVerificationApplications.Builders
{
    public class DraftApplicationBuilder
    {
        private EmployeeId _applicantId;
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

        public DraftApplication Build()
        {
            this._contentOfApplication = this.TryBuildContentOfApplication();
            this._suspiciousEmployees = this.TryBuildSuspiciousEmployees();
            return DraftApplication.Create(this._contentOfApplication, this._incidentType, this._applicantId,
                this._suspiciousEmployees);
        }

        private List<EmployeeId> TryBuildSuspiciousEmployees()
        {
            return this._suspiciousEmployeesDelegate != null
                ? this._suspiciousEmployeesDelegate(new SuspiciousEmployeesBuilder()).Build()
                : new List<EmployeeId>();
        }

        private ContentOfApplication TryBuildContentOfApplication()
        {
            return this._contentOfApplicationDelegate?.Invoke(new ContentOfApplicationBuilder()).Build();
        }
    }
}
