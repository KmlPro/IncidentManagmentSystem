using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Serilog;

namespace IncidentReport.Infrastructure.Processing.Behaviors
{
    public class PerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private const int MAX_ELAPSED_MILISECONDS = 1000;

        private readonly Stopwatch _timer;
        private readonly ILogger _logger;

        public PerformanceBehaviour(
            ILogger logger)
        {
            this._timer = new Stopwatch();

            this._logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            this._timer.Start();

            var response = await next();

            this._timer.Stop();

            var elapsedMilliseconds = this._timer.ElapsedMilliseconds;

            if (elapsedMilliseconds <= MAX_ELAPSED_MILISECONDS)
            {
                return response;
            }

            var requestName = typeof(TRequest).Name;
            this._logger.Warning(
                $"Long Running UseCase: {requestName} ({elapsedMilliseconds} milliseconds) {request}");

            return response;
        }
    }
}
