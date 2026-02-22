using Inventura.Application.Common.Interfaces;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace Inventura.Application.Common.Behaviors;

/// <summary>
/// Logging middleware that logs every request. This can be customized later to send logs to an external source
/// or disable logging to some parts of the application.
/// </summary>
/// <typeparam name="TRequest"></typeparam>
public class LoggingBehavior<TRequest> : IRequestPreProcessor<TRequest>
    where TRequest : notnull
{
    private readonly ILogger _logger;
    private readonly IUser _user;
    private readonly IIdentityService _identityService;

    public LoggingBehavior(ILogger logger, IUser user, IIdentityService identityService)
    {
        _logger = logger;
        _user = user;
        _identityService = identityService;
    }

    public async Task Process(TRequest request, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;
        var userId = _user.Id ?? string.Empty;
        string? userName = string.Empty;

        if (!string.IsNullOrEmpty(userId))
        {
            userName = await _identityService.GetUsernameAsync(userId); // Will optimize in the future to stop database hits every request
        }

        _logger.LogInformation(
            "Inventura Request: {Name} {@UserId} {UserName} {@Request}",
            requestName,
            userId,
            userName,
            request
        );
    }
}
