using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Serilog;

namespace IncidentReport.Infrastructure.Processing.Behaviors
{
    public class UnhandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger _logger;

        public UnhandledExceptionBehaviour(ILogger logger)
        {
            this._logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                return await next();
            }
            catch (Exception ex)
            {
                var requestName = typeof(TRequest).Name;
                this._logger.Error(ex, $"Unhandled Exception for UseCase {requestName}");

                throw;
            }
        }
    }
}
