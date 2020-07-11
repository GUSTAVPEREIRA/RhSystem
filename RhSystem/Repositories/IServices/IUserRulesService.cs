namespace RhSystem.Repositories.IServices
{
    using RhSystem.Models;
    using System.Collections.Generic;

    public interface IUserRulesService
    {
        UserRules CreateRule(UserRules userRules);
        UserRules GetUserRulesById(int id);
        UserRules UpdateUserRules(UserRules userRules);
        List<UserRules> GetUserRules();
        UserRules DeletedUserRules(int id);
        void PhysicalDeletedUserRules(UserRules userRules);
    }
}