namespace RhSystem.Repositories.IServices
{
    using RhSystem.Models;

    public interface IUserRulesService
    {
        UserRules CreateRule(UserRules userRules);
        UserRules GetUserRulesById(int id);
    }
}