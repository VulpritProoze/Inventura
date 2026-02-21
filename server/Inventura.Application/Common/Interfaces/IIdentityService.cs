using Inventura.Application.Common.Models;

namespace Inventura.Application.Common.Interfaces;

public interface IIdentityService
{
    Task<string?> GetUsernameAsync(string userId);
    Task<bool> IsInRoleAsync(string userId, string role);
    Task<bool> AuthorizeAsync(string userId, string policyName);
    Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);
    Task<Result> DeleteUserAsync(string userId);
}
