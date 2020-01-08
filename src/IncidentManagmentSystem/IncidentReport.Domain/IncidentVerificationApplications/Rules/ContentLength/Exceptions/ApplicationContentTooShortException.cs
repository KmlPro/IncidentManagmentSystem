using BuildingBlocks.Domain.Abstract;
using BuildingBlocks.Domain.Interfaces;

namespace IncidentReport.Domain.IncidentVerificationApplications.Rules.ContentLength.Exceptions
{
    internal class ApplicationContentTooShortException : BusinessRuleValidationException
    {
        public ApplicationContentTooShortException(IBusinessRule brokenRule, string message) : base(brokenRule, message)
        {
        }
    }
}
