using System.Threading.Tasks;
using BuildingBlocks.Application.Commands;
using IncidentReport.Infrastructure.Configuration.Processing.Commands;
using IncidentReport.Infrastructure.Contract;

namespace IncidentReport.Infrastructure
{
    public class IncidentReportModule : IIncidentReportModule
    {
        private readonly CommandsExecutor _commandsExecutor;
        public IncidentReportModule(CommandsExecutor commandsExecutor)
        {
            this._commandsExecutor = commandsExecutor;
        }

        public async Task ExecuteCommandAsync(ICommand command)
        {
            await this._commandsExecutor.Execute(command);
        }
    }
}
