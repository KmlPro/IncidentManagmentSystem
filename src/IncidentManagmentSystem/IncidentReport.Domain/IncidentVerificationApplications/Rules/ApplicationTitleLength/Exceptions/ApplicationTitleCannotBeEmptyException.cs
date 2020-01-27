using BuildingBlocks.Domain.Abstract;
using BuildingBlocks.Domain.Interfaces;

namespace IncidentReport.Domain.IncidentVerificationApplications.Rules.ApplicationTitleLength.Exceptions
{
    internal class ApplicationTitleCannotBeEmptyException : BusinessRuleValidationException
    {
        public ApplicationTitleCannotBeEmptyException(IBusinessRule brokenRule, string message) : base(brokenRule, message)
        {
        }
    }
}
