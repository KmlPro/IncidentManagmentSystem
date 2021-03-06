using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.Infrastructure;
using MediatR;

namespace IncidentReport.Infrastructure.Processing.Behaviors
{
    public class UnitOfWorkPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UnitOfWorkPipelineBehavior(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            using (var scope = this._unitOfWork.BeginTransaction())
            {
                var response = await next();
                await this._unitOfWork.CommitAsync(cancellationToken);
                scope.Complete();
                return response;
            }
        }
    }
}
