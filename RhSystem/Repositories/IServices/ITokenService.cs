namespace RhSystem.Repositories.IServices
{
    using RhSystem.Models;

    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}