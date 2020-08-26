using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Clubs.Application.Behaviours
{
    public class DBUpdateExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<TRequest> _logger;

        public DBUpdateExceptionBehaviour(ILogger<TRequest> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                return await next();
            }
            catch (DbUpdateException ex)
            {
                var requestName = typeof(TRequest).Name;
                _logger.LogError(ex, "Clubs API: DbUpdate Exception for Request {Name} {@Request}", requestName, request);
                throw;
            }
        }
    }
}