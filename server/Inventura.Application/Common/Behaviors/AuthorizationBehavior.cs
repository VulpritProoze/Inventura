using System.Reflection;
using Inventura.Application.Common.Exceptions;
using Inventura.Application.Common.Interfaces;
using Inventura.Application.Common.Security;

namespace Inventura.Application.Common.Behaviors;

/// <summary>
/// Defines the various authorization behaviors such as checking authenticated user's roles or policies
/// </summary>
/// <typeparam name="TRequest"></typeparam>
/// <typeparam name="TResponse"></typeparam>
public class AuthorizationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly IUser _user;
    private readonly IIdentityService _identityService;

    public AuthorizationBehavior(IUser user, IIdentityService identityService)
    {
        _user = user;
        _identityService = identityService;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken
    )
    {
        var authorizeAttributes = request.GetType().GetCustomAttributes<AuthorizeAttribute>();

        if (authorizeAttributes.Any())
        {
            if (_user.Id == null)
            {
                throw new UnauthorizedAccessException();
            }

            var authorizedAttributesWithRoles = authorizeAttributes.Where(a =>
                !string.IsNullOrWhiteSpace(a.Roles)
            );

            if (authorizedAttributesWithRoles.Any())
            {
                var authorized = false;

                foreach (var roles in authorizedAttributesWithRoles.Select(a => a.Roles.Split(',')))
                {
                    foreach (var role in roles)
                    {
                        var isInRole = _user.Roles?.Any(x => role == x) ?? false;
                        if (isInRole)
                        {
                            authorized = true;
                            break;
                        }
                    }
                }

                if (!authorized)
                {
                    throw new ForbiddenAccessException();
                }
            }

            var authorizedAttributesWithPolicies = authorizeAttributes.Where(a =>
                !string.IsNullOrWhiteSpace(a.Policy)
            );

            if (authorizedAttributesWithPolicies.Any())
            {
                foreach (var policy in authorizedAttributesWithPolicies.Select(a => a.Policy))
                {
                    var authorized = await _identityService.AuthorizeAsync(_user.Id, policy);

                    if (!authorized)
                    {
                        throw new ForbiddenAccessException();
                    }
                }
            }
        }

        return await next();
    }
}
