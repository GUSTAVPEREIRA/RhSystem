namespace RhSystem.Repositories
{
    using RhSystem.Seeders;
    using RhSystem.Repositories.Services;
    using RhSystem.Repositories.IServices;
    using Microsoft.Extensions.DependencyInjection;
    using RhSystem.Repositories.IServices.ISeederService;

    public class RegisterService
    {
        public void Register(ref IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IFirstInstallSeederService, FirstInstallSeederService>();
        }
    }
}