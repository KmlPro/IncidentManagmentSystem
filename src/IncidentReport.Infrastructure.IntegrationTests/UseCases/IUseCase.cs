using BuildingBlocks.Application.UseCases;

namespace IncidentReport.Infrastructure.IntegrationTests.UseCases
{
    internal interface IUseCase : IUseCase<TestUseCaseInput, TestUseCaseOutput>
    {
    }
}
