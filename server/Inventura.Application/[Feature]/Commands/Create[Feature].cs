using Inventura.Application.Common.Interfaces;

namespace Inventura.Application.Feature.Commands;

public record CreateFeatureCommand : IRequest<int> { }

public class CreateFeatureCommandHandler : IRequestHandler<CreateFeatureCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateFeatureCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateFeatureCommand request, CancellationToken cancellationToken)
    {
        // Add handle logic here
        await _context.SaveChangesAsync(cancellationToken);
        return 0;
    }
}
