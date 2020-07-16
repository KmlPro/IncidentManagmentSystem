using System.Threading.Tasks;
using BuildingBlocks.Application.UseCases;

namespace IncidentReport.Infrastructure.Contract
{
    public interface IIncidentReportModule
    {
        Task<TIUseCaseOutput> ExecuteUseCase<TIUseCaseOutput>(IUseCaseInput<TIUseCaseOutput> useCases)
            where TIUseCaseOutput : IUseCaseOutput;
    }
}
