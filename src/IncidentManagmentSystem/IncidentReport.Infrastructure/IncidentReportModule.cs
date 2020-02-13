using System.Threading.Tasks;
using Autofac;
using BuildingBlocks.Application.Commands;
using IncidentReport.Infrastructure.Configuration.DIContainer;
using IncidentReport.Infrastructure.Configuration.Processing.Commands;
using IncidentReport.Infrastructure.Contract;

namespace IncidentReport.Infrastructure
{
    internal class IncidentReportModule : IIncidentReportModule
    {
        public async Task ExecuteCommandAsync(ICommand command)
        {
            using (var scope = CompositionRoot.BeginLifetimeScope())
            {
                var commandsExecutor = scope.Resolve<CommandsExecutor>();

                await commandsExecutor.Execute(command);
            }
        }
    }
}
