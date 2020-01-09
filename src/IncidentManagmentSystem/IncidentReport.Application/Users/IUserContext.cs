using IncidentReport.Domain.Users;

namespace IncidentReport.Application.Users
{
    public interface IUserContext
    {
        UserId UserId { get; }
    }
}
