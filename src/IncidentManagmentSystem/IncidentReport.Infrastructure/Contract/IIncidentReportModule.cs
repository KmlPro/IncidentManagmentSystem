using System.Threading.Tasks;
using BuildingBlocks.Application.UseCases;

namespace IncidentReport.Infrastructure.Contract
{
    public interface IIncidentReportModule
    {
        Task ExecuteUseCase(IUseCaseInput useCases);
    }
}
