using BuildingBlocks.Domain.Abstract;
using BuildingBlocks.Domain.Interfaces;

namespace IncidentReport.Domain.IncidentVerificationApplications.Rules.ApplicantCannotBeSuspect.Exceptions
{
    internal class ApplicantCannotBeSuspectRuleException : BusinessRuleValidationException
    {
        private readonly static string _errorMessage = Resources.ApplicantCannotBeSuspectRuleException;

        public ApplicantCannotBeSuspectRuleException(IBusinessRule brokenRule) : base(brokenRule, _errorMessage)
        {
        }
    }
}
