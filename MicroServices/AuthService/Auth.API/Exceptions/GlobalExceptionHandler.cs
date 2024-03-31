using Auth.Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using System.Diagnostics;

namespace Auth.API.Exceptions;

public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> _logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var traceId = Activity.Current?.Id ?? httpContext.TraceIdentifier;

        _logger.LogError(
            exception,
            "Could not process a request TraceId: {TraceId}",
            traceId
        );

        var (statusCode, title) = MapException(exception);

        await Results.Problem(
            title: title,
            statusCode: statusCode,
            extensions: new Dictionary<string, object?>
            {
                { "traceId", traceId }
            }
        ).ExecuteAsync(httpContext);

        return true;
    }

    private static (int StatusCode, string Title) MapException(Exception exception)
    {
        return exception switch
        {
            ItemNotFoundException => (StatusCodes.Status404NotFound,  exception.Message), 
            GlobalException => (StatusCodes.Status400BadRequest,  exception.Message),
            _ => (StatusCodes.Status500InternalServerError, "Something went wrong, please retry!")
        };
    }
}
