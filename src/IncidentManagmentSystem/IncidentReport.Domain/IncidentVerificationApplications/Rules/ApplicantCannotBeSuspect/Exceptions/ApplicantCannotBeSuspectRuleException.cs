using BuildingBlocks.Domain.Abstract;
using BuildingBlocks.Domain.Interfaces;

namespace IncidentReport.Domain.IncidentVerificationApplications.Rules.ApplicantCannotBeSuspect.Exceptions
{
    internal class ApplicantCannotBeSuspectRuleException : BusinessRuleValidationException
    {
        private static readonly string _errorMessage = Resources.ApplicantCannotBeSuspectRuleException;

        public ApplicantCannotBeSuspectRuleException(IBusinessRule brokenRule) : base(brokenRule, _errorMessage)
        {
        }
    }
}
