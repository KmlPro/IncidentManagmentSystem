using BuildingBlocks.Application.Boundaries;

namespace IncidentReport.Application.Boundaries.CreateDraftApplications
{
    public interface IOutputPort
        : IOutputPortStandard<CreateDraftApplicationOutput>, IOutputPortBusinessError
    {
    }
}
