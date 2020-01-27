using BuildingBlocks.Domain.Abstract;
using BuildingBlocks.Domain.Interfaces;

namespace IncidentReport.Domain.IncidentVerificationApplications.Rules.ApplicationTitleLength.Exceptions
{
    internal class ApplicationTitleTooLongException : BusinessRuleValidationException
    {
        public ApplicationTitleTooLongException(IBusinessRule brokenRule, string message) : base(brokenRule, message)
        {
        }
    }
}
