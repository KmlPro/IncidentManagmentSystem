using System.Threading.Tasks;
using BuildingBlocks.Application.UseCases;
using IncidentReport.Infrastructure.PublicDomain;

namespace IncidentReport.Infrastructure.Contract
{
    public interface IIncidentReportModule
    {
        Task<TIUseCaseOutput> ExecuteUseCase<TIUseCaseOutput>(IUseCaseInput<TIUseCaseOutput> useCases)
            where TIUseCaseOutput : IUseCaseOutput;

        IReadIncidentReportDbContext ReadContext { get; }
    }
}
