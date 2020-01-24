using BuildingBlocks.Domain.Abstract;
using BuildingBlocks.Domain.Interfaces;

namespace IncidentReport.Domain.IncidentVerificationApplications.Rules.ContentLength.Exceptions
{
    internal class ApplicationContentTooShortException : BusinessRuleValidationException
    {
        private const string _errorMessage = "The Content should contain a minimum of {0} characters";
        public ApplicationContentTooShortException(IBusinessRule brokenRule, int minLength) : base(brokenRule, string.Format(_errorMessage, minLength))
        {
        }
    }
}
