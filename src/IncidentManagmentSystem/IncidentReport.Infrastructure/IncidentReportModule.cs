using System.Threading.Tasks;
using BuildingBlocks.Application.Boundaries;
using BuildingBlocks.Application.Commands;
using IncidentReport.Infrastructure.Configuration.Processing.Commands;
using IncidentReport.Infrastructure.Configuration.Processing.UseCases;
using IncidentReport.Infrastructure.Contract;

namespace IncidentReport.Infrastructure
{
    internal class IncidentReportModule : IIncidentReportModule
    {
        public async Task ExecuteCommandAsync(ICommand command)
        {
            await CommandsExecutor.Execute(command);
        }

        public async Task<TCommandResult> ExecuteCommandWithResultAsync<TCommandResult>(ICommand<TCommandResult> command) where TCommandResult : ICommandResult
        {
            return await CommandsExecutor.ExecuteWithResult(command);
        }

        public async Task ExecuteUseCase(IUseCaseInput useCase)
        {
            await UseCaseExecutor.Execute(useCase);
        }
    }
}
