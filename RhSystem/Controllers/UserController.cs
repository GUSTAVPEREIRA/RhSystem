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

                return new OkObjectResult(new
                {
                    User = user
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("DeleteUser/{id}")]
        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult<dynamic> DeleteUser(int id)
        {
            try
            {                                
                User user = _userService.DeleteUser(id);

                return new OkObjectResult(new
                {
                    Message = $"Usuário {user.Username} foi deletado!"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("UpdateUser")]
        [HttpPut]
        [Authorize]
        public ActionResult<dynamic> UpdateUser(User user)
        {
            try
            {
                user = _userService.UpdateUser(user);
                User updatedUser = _userService.GetUserForId(user.Id);

                return new OkObjectResult(new
                {
                    Message = "Usuário foi atualizado",
                    User = updatedUser
                });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [Route("GetUser/{id}")]
        [HttpGet]
        [Authorize]
        public ActionResult<dynamic> GetUser(int id)
        {
            try
            {
                User user = _userService.GetUserForId(id);
                
                return new OkObjectResult(new
                {
                    User = user
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}