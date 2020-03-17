using BuildingBlocks.Application.OutputPort;

namespace IncidentReport.Application.Boundaries.UpdateDraftApplications
{
    public interface IOutputPort
        : IOutputPortStandard<UpdateDraftApplicationOutput>, IOutputPortBusinessError
    {
    }
}
