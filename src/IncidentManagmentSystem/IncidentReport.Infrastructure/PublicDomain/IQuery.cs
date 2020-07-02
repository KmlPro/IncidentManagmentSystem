using System.Linq;

namespace IncidentReport.Infrastructure.PublicDomain
{
    public interface IQuery<TDto> where TDto : IDto
    {
        IQueryable<TDto> Get();
    }
}
