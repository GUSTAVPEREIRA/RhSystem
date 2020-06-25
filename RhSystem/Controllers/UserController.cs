namespace RhSystem.Controllers
{
    using System;
    using RhSystem.Models;
    using Microsoft.AspNetCore.Mvc;
    using RhSystem.Repositories.IServices;
    using Microsoft.AspNetCore.Authorization;

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;
        private readonly IUserRulesService _userRulesService;        

        public UserController(IUserService userService, IUserRulesService userRulesService)
        {
            _userService = userService;
            _userRulesService = userRulesService;            
        }

        [Route("CreateUser")]
        [HttpPost]
        [Authorize]
        public ActionResult<dynamic> CreateUser(User user)
        {
            try
            {
                if (user.Rules == null && user.Rules.Id == 0)
                {
                    return BadRequest("Não foi informada a regra do usuário");
                }

                user.Rules = _userRulesService.GetUserRulesById(user.Rules.Id);
                user = _userService.CreateUser(user);

                user.SetPassword("");                

                return new OkObjectResult(new
                {
                    user
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}