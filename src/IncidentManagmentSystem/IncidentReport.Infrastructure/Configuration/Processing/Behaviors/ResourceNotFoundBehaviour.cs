using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.Application.Exceptions;
using EntityFramework.Exceptions.Common;
using MediatR;
using Serilog;

namespace IncidentReport.Infrastructure.Configuration.Processing.Behaviors
{
    public class ResourceNotFoundBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger _logger;

        public ResourceNotFoundBehaviour(ILogger logger)
        {
            this._logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                return await next();
            }
            catch (ReferenceConstraintException ex)
            {
                var requestName = typeof(TRequest).Name;
                this._logger.Error(ex, $"Resource not found Exception for UseCase {requestName}");

                throw new ResourceNotFoundException(ex);
            }
        }
    }
}
