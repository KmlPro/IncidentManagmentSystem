using BuildingBlocks.Application.OutputPort;
using BuildingBlocks.Application.UseCases;

namespace IncidentReport.Application.Boundaries.UpdateDraftApplications
{
    public interface IOutputPort
        : IOutputPortStandard<UpdateDraftApplicationOutput>, IOutputPortBusinessError, IUseCaseOutput, IOutputPortResourceNotFound
    {
    }
}
