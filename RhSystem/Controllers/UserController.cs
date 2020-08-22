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


        /// <summary>
        /// Cria um usuário
        /// </summary>               
        /// <response code="200">Retorna o usuário recém criado!</response>
        /// <response code="400">Retorna nulo e a mensagem do erro</response>            
        /// <returns></returns>
        [Route("CreateUser")]
        [HttpPost]
        [Authorize]
        public ActionResult<dynamic> CreateUser([FromBody] User user)
        {
            try
            {
                if (user.RulesId == 0)
                {
                    return BadRequest("Não foi informada a regra do usuário");
                }

                user.Rules = _userRulesService.GetUserRulesById(user.RulesId);
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
        [HttpDelete]
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
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("PhysicalDelete/{id}")]
        [Authorize]
        public ActionResult<dynamic> DeleteUserPhysical(int id)
        {
            try
            {
                User user = _userService.GetUserForId(id);

                if (user == null)
                {
                    throw new ArgumentNullException("Usuário não encontrado!");
                }

                _userService.PhysicalDelete(user);

                return new OkObjectResult(new
                {
                    Message = "Usuário foi deletado!",
                    Usuario = user.Username
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("UsernameExists/{username}")]
        [Authorize]
        public ActionResult<dynamic> CheckUsernameExist(string username)
        {
            try
            {
                var user = _userService.SearchUser(username, null);

                bool UsernameExist = user != null ? true : false;

                return new OkObjectResult(new
                {
                    Message = UsernameExist

                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}