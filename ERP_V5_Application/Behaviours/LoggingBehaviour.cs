using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ERP_V5_Application.Behaviours
{
    public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<LoggingBehaviour<TRequest, TResponse>> _logger;

        public LoggingBehaviour(ILogger<LoggingBehaviour<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;
            var requesData = SafeSerialize(request);
            _logger.LogInformation("Handing {RequestName} - Request: {RequestData}", requestName, requesData);
            var stopWatch = Stopwatch.StartNew();
            var response = await next();
            stopWatch.Stop();
            var responseData = SafeSerialize(response);
            _logger.LogInformation("Handled {RequestName}", requestName, stopWatch.ElapsedMilliseconds, responseData);
            return response;
        }

        private string SafeSerialize(object request)
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = false, IgnoreNullValues = true };
                return JsonSerializer.Serialize(request, options);
            }
            catch
            {
                return "<unable To serialize>";
            }
        }
    }
}
