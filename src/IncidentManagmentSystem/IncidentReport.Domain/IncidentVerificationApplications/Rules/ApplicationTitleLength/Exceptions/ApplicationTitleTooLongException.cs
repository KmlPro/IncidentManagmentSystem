using BuildingBlocks.Domain.Abstract;
using BuildingBlocks.Domain.Interfaces;

namespace IncidentReport.Domain.IncidentVerificationApplications.Rules.ApplicationTitleLength.Exceptions
{
    internal class ApplicationTitleTooLongException : BusinessRuleValidationException
    {
        private const string _errorMessage = "The Title should contain a minimum of {0} characters";
        public ApplicationTitleTooLongException(IBusinessRule brokenRule, int maxLength) : base(brokenRule, string.Format(_errorMessage, maxLength))
        {
        }
    }
}
