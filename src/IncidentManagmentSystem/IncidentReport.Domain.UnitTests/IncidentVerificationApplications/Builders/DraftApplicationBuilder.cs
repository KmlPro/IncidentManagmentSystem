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
        private Content _content;
        private Title _title;

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

        public DraftApplicationBuilder SetContent(string content)
        {
            this._content = new Content(content);
            return this;
        }

        public DraftApplicationBuilder SetTitle(string title)
        {
            this._title = new Title(title);
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
            this._suspiciousEmployees = this.TryBuildSuspiciousEmployees();
            return DraftApplication.Create(this._title, this._content, this._incidentType, this._applicantId,
                this._suspiciousEmployees);
        }

        private List<EmployeeId> TryBuildSuspiciousEmployees()
        {
            return this._suspiciousEmployeesDelegate != null
                ? this._suspiciousEmployeesDelegate(new SuspiciousEmployeesBuilder()).Build()
                : new List<EmployeeId>();
        }
    }
}
