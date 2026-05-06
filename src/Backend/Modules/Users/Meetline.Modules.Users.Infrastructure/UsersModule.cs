using Meetline.Modules.Users.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Meetline.Modules.Users.Infrastructure;

public static class UsersModule
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddUsersModule(Action<UsersModuleOptions> configure)
        {
            var options = new UsersModuleOptions();

            configure(options);

            services.AddDbContext<UsersDbContext>(db => { db.UseNpgsql(options.ConnectionString); });

            return services;
        }
    }
}