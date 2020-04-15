using BuildingBlocks.Domain.Abstract;
using BuildingBlocks.Domain.Interfaces;

namespace IncidentReport.Domain.IncidentVerificationApplications.Rules.ApplicationDescriptionLength.Exceptions
{
    internal class ApplicationDescriptionTooLongException : BusinessRuleValidationException
    {
        private readonly static string _errorMessage = Resources.ApplicationDescriptionTooLongException;

        public ApplicationDescriptionTooLongException(IBusinessRule brokenRule, int maxLength) : base(brokenRule, string.Format(_errorMessage, maxLength))
        {
        }

    }
}
