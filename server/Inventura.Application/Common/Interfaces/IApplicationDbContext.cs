namespace Inventura.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    // Add DbContext interfaces here

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
