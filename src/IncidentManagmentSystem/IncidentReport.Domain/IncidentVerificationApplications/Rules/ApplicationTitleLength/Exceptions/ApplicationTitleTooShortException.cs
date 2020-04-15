using BuildingBlocks.Domain.Abstract;
using BuildingBlocks.Domain.Interfaces;

namespace IncidentReport.Domain.IncidentVerificationApplications.Rules.ApplicationTitleLength.Exceptions
{
    internal class ApplicationTitleTooShortException : BusinessRuleValidationException
    {
        private readonly static string _errorMessage = Resources.ApplicationTitleTooShortException;

        public ApplicationTitleTooShortException(IBusinessRule brokenRule, int minLength) : base(brokenRule, string.Format(_errorMessage, minLength))
        {
        }
    }
}
