using BuildingBlocks.Domain.Abstract;
using BuildingBlocks.Domain.Interfaces;

namespace IncidentReport.Domain.IncidentVerificationApplications.Rules.ApplicationDescriptionLength.Exceptions
{
    internal class ApplicationDescriptionTooLongException : BusinessRuleValidationException
    {
        private const string _errorMessage = "The Description should contain a minimum of {0} characters";
        public ApplicationDescriptionTooLongException(IBusinessRule brokenRule, int maxLength) : base(brokenRule, string.Format(_errorMessage, maxLength))
        {
        }

    }
}
