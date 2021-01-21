

using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace Clubs.Application.Behaviours
{
    public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILoggerFactory  _logger;

        public LoggingBehaviour(ILoggerFactory logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var log = _logger.CreateLogger<TRequest>();
            log.LogInformation($"Handling {typeof(TRequest).Name}");
            var response = await next();
            //Probably not required!
            //log.LogInformation($"Handled {typeof(TResponse).Name}");
        return response;
        }
    }
}