using Inventura.Infrastructure.Data;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddPresentationServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    await app.InitializeDatabaseAsync();
    app.MapOpenApi("/api/v1/docs/{documentName}.json");
    app.MapScalarApiReference("api/v1/docs");
}
else
{
    app.UseHsts();
}

app.UseHealthChecks("/health");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseExceptionHandler(options => { });
app.Map("/", () => Results.Redirect("/api"));
app.MapEndpoints();

app.Run();
