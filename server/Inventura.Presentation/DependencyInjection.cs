using Microsoft.OpenApi;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentationServices(this IServiceCollection services)
    {
        services.AddControllers();

        services.AddOpenApi(options =>
        {
            options.AddDocumentTransformer(
                (document, context, cancellationToken) =>
                {
                    document.Info.Title = "Inventura API for testing";
                    document.Info.Version = "v1";
                    document.Info.Description = "This API is for testing only.";

                    return Task.CompletedTask;
                }
            );
        });

        return services;
    }
}
