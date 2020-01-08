using BuildingBlocks.Domain.Abstract;
using BuildingBlocks.Domain.Interfaces;

namespace IncidentReport.Domain.IncidentVerificationApplications.Rules.ContentLength.Exceptions
{
    internal class ApplicationContentTooLongException : BusinessRuleValidationException
    {
        public ApplicationContentTooLongException(IBusinessRule brokenRule, string message) : base(brokenRule, message)
        {
        }
    }
}
