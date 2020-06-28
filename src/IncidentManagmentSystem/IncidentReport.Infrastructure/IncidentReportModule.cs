using System.Threading.Tasks;
using BuildingBlocks.Application.UseCases;
using IncidentReport.Infrastructure.Configuration.Processing.UseCases;
using IncidentReport.Infrastructure.Contract;
using IncidentReport.Infrastructure.PublicDomain;

namespace IncidentReport.Infrastructure
{
    internal class IncidentReportModule : IIncidentReportModule
    {
        public IReadIncidentReportDbContext ReadContext => ReadContextInstanceFactory.Get();

        public async Task<TUseCaseOutput> ExecuteUseCase<TUseCaseOutput>(IUseCaseInput<TUseCaseOutput> useCase)
            where TUseCaseOutput : IUseCaseOutput
        {
            return await UseCaseExecutor.Execute(useCase);
        }
    }
}
