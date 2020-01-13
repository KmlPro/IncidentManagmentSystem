using System;

namespace IncidentReport.UseCases.User
{
    public interface IApplicantContext
    {
        public Guid UserId { get; }
    }
}
