namespace RhSystem.Repositories.IServices
{
    using RhSystem.Models;

    public interface IUserService
    {
        User GetUserForAuthenticate(string username, string password);
        User GetUser(string username, string password);
        User GetUserForId(int id);        
        User CreateUser(User user);
        User DeleteUser(int user);
        User UpdateUser(User user);
        void PhysicalDelete(User user);
    }
}