using BuildingBlocks.Application.OutputPort;
using BuildingBlocks.Application.UseCases;

namespace IncidentReport.Application.Boundaries.PostApplicationUseCase
{
    public interface IOutputPort
        : IOutputPortStandard<PostApplicationOutput>, IOutputPortBusinessError, IUseCaseOutput, IOutputPortResourceNotFound
    {
    }
}
