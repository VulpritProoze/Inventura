using Microsoft.Extensions.Logging;

namespace Inventura.Application.Common.Behaviors;

/// <summary>
/// Middleware for customizing behaviors when catching unhandled exceptions.
/// </summary>
/// <typeparam name="TRequest"></typeparam>
/// <typeparam name="TResponse"></typeparam>
public class UnhandledExceptionBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly ILogger _logger;

    public UnhandledExceptionBehavior(ILogger logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken
    )
    {
        try
        {
            return await next();
        }
        catch (Exception ex)
        {
            var requestName = typeof(TRequest).Name;
            _logger.LogError(
                ex,
                "Inventura Request: Unhandled Exception for Request {Name} {@Request}",
                requestName,
                request
            );

            throw;
        }
    }
}
