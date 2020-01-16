using System;

namespace IncidentReport.Application.User
{
    public interface IApplicantContext
    {
        public Guid UserId { get; }
    }
}
