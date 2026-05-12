using System.Diagnostics;
using Meetline.Modules.Users.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Meetline.Modules.Users.MigrationService;

public class Worker(IServiceProvider services, IHostApplicationLifetime lifetime) : BackgroundService
{
    public const string ActivitySourceName = "Migrations";
    private static readonly ActivitySource ActivitySource = new(ActivitySourceName);

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var activity = ActivitySource.StartActivity(nameof(ExecuteAsync), ActivityKind.Client);

        try
        {
            using var scope = services.CreateScope();

            var usersContext = scope.ServiceProvider.GetRequiredService<UsersDbContext>();

            await RunMigrationAsync(usersContext, stoppingToken);
        }
        catch (Exception ex)
        {
            activity?.AddException(ex);
            throw;
        }

        lifetime.StopApplication();
    }

    private static async Task RunMigrationAsync(
        DbContext dbContext, CancellationToken cancellationToken)
    {
        var strategy = dbContext.Database.CreateExecutionStrategy();

        await strategy.ExecuteAsync(
            (dbContext, cancellationToken),
            static async (state, ct) => { await state.dbContext.Database.MigrateAsync(ct); },
            cancellationToken);
    }
}