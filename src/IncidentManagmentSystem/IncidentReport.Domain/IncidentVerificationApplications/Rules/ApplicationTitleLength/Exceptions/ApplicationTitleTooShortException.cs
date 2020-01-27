using BuildingBlocks.Domain.Abstract;
using BuildingBlocks.Domain.Interfaces;

namespace IncidentReport.Domain.IncidentVerificationApplications.Rules.ApplicationTitleLength.Exceptions
{
    internal class ApplicationTitleTooShortException : BusinessRuleValidationException
    {
        private const string _errorMessage = "The Title should contain a minimum of {0} characters";
        public ApplicationTitleTooShortException(IBusinessRule brokenRule, int minLength) : base(brokenRule, string.Format(_errorMessage, minLength))
        {
        }
    }
}
