using BuildingBlocks.Domain.Abstract;
using BuildingBlocks.Domain.Interfaces;

namespace IncidentReport.Domain.IncidentVerificationApplications.Rules.ApplicationDescriptionLength.Exceptions
{
    internal class ApplicationDescriptionTooShortException : BusinessRuleValidationException
    {
        private const string _errorMessage = "The Description should contain a minimum of {0} characters";
        public ApplicationDescriptionTooShortException(IBusinessRule brokenRule, int minLength) : base(brokenRule, string.Format(_errorMessage, minLength))
        {
        }
    }
}
