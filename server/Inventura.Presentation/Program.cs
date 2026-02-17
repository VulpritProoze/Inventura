using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddPresentationServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi("/api/v1/docs/{documentName}.json");
    app.MapScalarApiReference("api/v1/docs");
}

app.MapControllers();

app.Run();
