using BuildingBlocks.Domain.Abstract;
using BuildingBlocks.Domain.Interfaces;

namespace IncidentReport.Domain.IncidentVerificationApplications.Rules.ApplicationTitleLength.Exceptions
{
    internal class ApplicationTitleTooLongException : BusinessRuleValidationException
    {
        private readonly static string _errorMessage = Resources.ApplicationTitleTooLongException;

        public ApplicationTitleTooLongException(IBusinessRule brokenRule, int maxLength) : base(brokenRule, string.Format(_errorMessage, maxLength))
        {
        }
    }
}
