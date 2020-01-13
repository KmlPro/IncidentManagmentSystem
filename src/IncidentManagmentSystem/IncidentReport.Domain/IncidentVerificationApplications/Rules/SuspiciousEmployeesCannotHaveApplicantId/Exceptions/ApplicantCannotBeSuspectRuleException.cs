using BuildingBlocks.Domain.Abstract;
using BuildingBlocks.Domain.Interfaces;

namespace IncidentReport.Domain.IncidentVerificationApplications.Rules.SuspiciousEmployeesCannotHaveApplicantId.Exceptions
{
    internal class ApplicationCannotHaveApplicantAsSuspiciousEmployeeException : BusinessRuleValidationException
    {
        private const string _errorMessage = "The applicant cannot be a suspect";
        public ApplicationCannotHaveApplicantAsSuspiciousEmployeeException(IBusinessRule brokenRule) : base(brokenRule, _errorMessage)
        {
        }
    }
}
