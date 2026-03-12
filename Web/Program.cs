using Scalar.AspNetCore;
using Web.Configs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi(OpenApiConfiguration.Configure);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.Run();