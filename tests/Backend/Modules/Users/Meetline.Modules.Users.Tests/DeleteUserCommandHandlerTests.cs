using Meetline.Modules.Users.Application.Data;
using Meetline.Modules.Users.Application.Users.Commands.DeleteUser;
using Meetline.Modules.Users.Domain.Entities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Meetline.Modules.Users.Tests;

public sealed class DeleteUserCommandHandlerTests : IAsyncDisposable
{
    private readonly SqliteConnection _connection;
    private readonly TestUsersDbContext _context;

    public DeleteUserCommandHandlerTests()
    {
        _connection = new SqliteConnection("DataSource=:memory:");
        _connection.Open();

        var options = new DbContextOptionsBuilder<TestUsersDbContext>()
            .UseSqlite(_connection)
            .Options;

        _context = new TestUsersDbContext(options);
        _context.Database.EnsureCreated();
    }

    public async ValueTask DisposeAsync()
    {
        await _context.DisposeAsync();
        await _connection.DisposeAsync();
    }

    [Fact(DisplayName = "Handle should delete user when matching external ID exists")]
    public async Task Handle_ShouldDeleteUser_WhenMatchingExternalIdExists()
    {
        const string externalId = "user_123456";
        var user = new User
        {
            Id = Guid.NewGuid(),
            ExternalId = externalId,
            Username = "testuser",
            Email = "test@example.com"
        };
        _context.Users.Add(user);
        await _context.SaveChangesAsync(TestContext.Current.CancellationToken);

        var command = new DeleteUserCommand(externalId);

        await DeleteUserCommandHandler.Handle(command, _context, CancellationToken.None);

        var exists = await _context.Users.AnyAsync(u => u.ExternalId == externalId,
            TestContext.Current.CancellationToken);
        Assert.False(exists);
    }

    [Fact(DisplayName = "Handle should not delete other users when external ID does not match")]
    public async Task Handle_ShouldNotDeleteOtherUsers_WhenExternalIdDoesNotMatch()
    {
        const string targetExternalId = "user_target";
        const string otherExternalId = "user_other";

        var targetUser = new User
        {
            Id = Guid.NewGuid(),
            ExternalId = targetExternalId,
            Username = "target",
            Email = "target@example.com"
        };
        var otherUser = new User
        {
            Id = Guid.NewGuid(),
            ExternalId = otherExternalId,
            Username = "other",
            Email = "other@example.com"
        };

        _context.Users.AddRange(targetUser, otherUser);
        await _context.SaveChangesAsync(TestContext.Current.CancellationToken);

        var command = new DeleteUserCommand(targetExternalId);

        await DeleteUserCommandHandler.Handle(command, _context, CancellationToken.None);

        var targetExists = await _context.Users.AnyAsync(u => u.ExternalId == targetExternalId,
            TestContext.Current.CancellationToken);
        var otherExists = await _context.Users.AnyAsync(u => u.ExternalId == otherExternalId,
            TestContext.Current.CancellationToken);

        Assert.False(targetExists);
        Assert.True(otherExists);
    }

    private class TestUsersDbContext(DbContextOptions<TestUsersDbContext> options) : DbContext(options), IUsersDbContext
    {
        public DbSet<User> Users => Set<User>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(builder =>
            {
                builder.HasKey(u => u.Id);
                builder.HasIndex(u => u.ExternalId).IsUnique();
                builder.HasIndex(u => u.Username).IsUnique();
                builder.HasIndex(u => u.Email).IsUnique();
            });
        }
    }
}