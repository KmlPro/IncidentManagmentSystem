using BuildingBlocks.Application.OutputPort;
using BuildingBlocks.Application.UseCases;

namespace IncidentReport.Application.Boundaries.CreateDraftApplications
{
    public interface IOutputPort
        : IOutputPortStandard<CreateDraftApplicationOutput>, IOutputPortBusinessError, IUseCaseOutput, IOutputPortInvalidInput
    {
    }
}
