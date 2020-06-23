namespace RhSystem.Repositories
{
    using RhSystem.Repositories.Services;
    using RhSystem.Repositories.IServices;
    using Microsoft.Extensions.DependencyInjection;

    public class RegisterService
    {
        public void Register(ref IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}