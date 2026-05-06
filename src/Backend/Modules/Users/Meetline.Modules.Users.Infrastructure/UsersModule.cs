using Microsoft.Extensions.DependencyInjection;

namespace Meetline.Modules.Users.Infrastructure;

public static class UsersModule
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddUsersModule()
        {
            return services;
        }
    }
}