namespace RhSystem.Repositories
{
    using RhSystem.Repositories.IServices;
    using Microsoft.Extensions.DependencyInjection;
    using RhSystem.Repositories.Services;

    public class RegisterService
    {
        public void Register(ref IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }
    }
}