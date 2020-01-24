using BuildingBlocks.Domain.Abstract;
using BuildingBlocks.Domain.Interfaces;

namespace IncidentReport.Domain.IncidentVerificationApplications.Rules.ContentLength.Exceptions
{
    internal class ApplicationContentTooLongException : BusinessRuleValidationException
    {
        private const string _errorMessage = "The Content should contain a minimum of {0} characters";
        public ApplicationContentTooLongException(IBusinessRule brokenRule, int maxLength) : base(brokenRule, string.Format(_errorMessage, maxLength))
        {
        }

    }
}
