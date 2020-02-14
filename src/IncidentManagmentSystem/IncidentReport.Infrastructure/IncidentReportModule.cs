using BuildingBlocks.Application.Commands;
using IncidentReport.Infrastructure.Configuration.Processing.Commands;
using IncidentReport.Infrastructure.Contract;
using System.Threading.Tasks;

namespace IncidentReport.Infrastructure
{
    internal class IncidentReportModule : IIncidentReportModule
    {
        public async Task ExecuteCommandAsync(ICommand command)
        {
            await CommandsExecutor.Execute(command);
        }
    }
}
