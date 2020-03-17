using BuildingBlocks.Application.OutputPort;

namespace IncidentReport.Application.Boundaries.CreateDraftApplications
{
    public interface IOutputPort
        : IOutputPortStandard<CreateDraftApplicationOutput>, IOutputPortBusinessError
    {
    }
}
