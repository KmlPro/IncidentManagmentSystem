using System.Linq;

namespace IncidentReport.Infrastructure.PublicDomain
{
    public interface IQuery {

    }
    public interface IQuery<TDto>: IQuery where TDto : IDto
    {
        IQueryable<TDto> Get();
    }
}
