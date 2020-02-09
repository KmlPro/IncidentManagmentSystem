using System.Threading.Tasks;
using BuildingBlocks.Application.Commands;

namespace IncidentReport.Infrastructure.Contract
{
    public interface IIncidentReportModule
    {
        Task ExecuteCommandAsync(ICommand command);
    }
}
