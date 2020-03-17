using System.Threading.Tasks;
using BuildingBlocks.Application.Boundaries;
using BuildingBlocks.Application.Commands;

namespace IncidentReport.Infrastructure.Contract
{
    public interface IIncidentReportModule
    {
        Task ExecuteCommandAsync(ICommand command);

        Task<TResponse> ExecuteCommandWithResultAsync<TResponse>(ICommand<TResponse> command) where TResponse : ICommandResult;

        Task ExecuteUseCase(IUseCaseInput useCases);
    }
}
