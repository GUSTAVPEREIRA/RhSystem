namespace RhSystem.Repositories.IServices
{
    using RhSystem.Models;

    public interface IUserService
    {
        User GetUserForAuthenticate(string username, string password);
    }
}