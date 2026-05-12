using Meetline.Modules.Users.Infrastructure.Data;
using Meetline.Modules.Users.MigrationService;
using Meetline.ServiceDefaults;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

// TODO pass the connection names as parameters ideally gathered from the AppHost db itself
builder.AddNpgsqlDbContext<UsersDbContext>("postgres-users");

builder.AddServiceDefaults();

builder.Services.AddOpenTelemetry()
    .WithTracing(tracing => tracing.AddSource(Worker.ActivitySourceName));

var host = builder.Build();
host.Run();