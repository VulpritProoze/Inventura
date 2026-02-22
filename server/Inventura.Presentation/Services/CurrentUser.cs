using System.Security.Claims;
using Inventura.Application.Common.Interfaces;

namespace Inventura.Presentation.Services;

/// <summary>
/// Represents the currently authenticated user
/// </summary>
public class CurrentUser : IUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUser(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string? Id =>
        _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
    public List<string>? Roles =>
        _httpContextAccessor
            .HttpContext?.User?.FindAll(ClaimTypes.Role)
            .Select(x => x.Value)
            .ToList();
}
