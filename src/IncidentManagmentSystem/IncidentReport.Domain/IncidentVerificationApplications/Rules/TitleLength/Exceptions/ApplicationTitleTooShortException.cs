using BuildingBlocks.Domain.Abstract;
using BuildingBlocks.Domain.Interfaces;

namespace IncidentReport.Domain.IncidentVerificationApplications.Rules.TitleLength.Exceptions
{
    internal class ApplicationTitleTooShortException : BusinessRuleValidationException
    {
        public ApplicationTitleTooShortException(IBusinessRule brokenRule, string message) : base(brokenRule, message)
        {
        }
    }
}
