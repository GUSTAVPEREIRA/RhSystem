namespace RhSystem.Repositories.IServices
{
    using RhSystem.Models;

    public interface IUserService
    {
        User GetUserForAuthenticate(string username, string password);
        User GetUser(string username, string password);
        User CreateUserAsync(User user);
        User CreateUser(User user);
    }
}