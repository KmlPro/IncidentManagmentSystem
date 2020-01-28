using System;

namespace IncidentReport.Application.User
{
    public interface ICurrentUserContext
    {
        public Guid UserId { get; }
    }
}
