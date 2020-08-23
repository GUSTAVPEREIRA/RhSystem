namespace RhSystem.Controllers
{
    using System;
    using RhSystem.DTO;
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
        /// <remarks>
        /// Sample request:
        ///
        ///     POST
        ///     {
        ///        "Username": ADMIN,
        ///        "Password": "ADMIN",
        ///        "RulesID": 2
        ///     }
        ///
        /// </remarks>  
        /// <response code="200">Retorna o usuário recém criado!</response>
        /// <response code="400">Retorna nulo e a mensagem do erro</response>            
        /// <returns></returns>
        [Route("CreateUser")]
        [HttpPost]
        [Authorize]
        public ActionResult<dynamic> CreateUser([FromBody] UserDTO user)
        {
            try
            {
                if (user.RulesID == 0)
                {
                    return BadRequest("Não foi informada a regra do usuário");
                }

                User newUser = new User(user.Username, user.Password);

                newUser.Rules = _userRulesService.GetUserRulesById(user.RulesID);
                newUser = _userService.CreateUser(newUser);

                return new OkObjectResult(new
                {
                    User = newUser
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Deleta lógicamente um usuário
        /// </summary>        
        /// <param name="id">Código do usuário</param>
        /// <response code="200">Retorna uma mensagem, informando o usuário que foi deletado lógicamente!</response>
        /// <response code="400">Retorna nulo e a mensagem do erro</response>            
        /// <returns></returns>
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

        /// <summary>
        /// Atualiza os dados do usuário
        /// </summary>                
        /// <response code="200">Retorno o usuário</response>
        /// <response code="400">Retorna nulo e a mensagem do erro</response> 
        [Route("UpdateUser")]
        [HttpPut]
        [Authorize]
        public ActionResult<dynamic> UpdateUser([FromBody] UserDTO user)
        {
            try
            {
                User updatedUser = _userService.GetUserForId(user.ID);

                if (updatedUser != null)
                {
                    updatedUser.SetPassword(user.Password);                    
                    updatedUser.Rules = _userRulesService.GetUserRulesById(user.RulesID);
                }

                _userService.UpdateUser(updatedUser);
                updatedUser = _userService.GetUserForId(updatedUser.Id);

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

        /// <summary>
        /// Procura um usuário pelo código
        /// </summary>        
        /// <param name="id">Código do usuário</param>
        /// <response code="200">Retorno o usuário</response>
        /// <response code="400">Retorna nulo e a mensagem do erro</response>  
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

        /// <summary>
        /// Deleta físicamente um usuário
        /// </summary>        
        /// <param name="id">Código do usuário</param>
        /// <response code="200">Retorna uma mensagem, informando o usuário que foi deletado físicamente!</response>
        /// <response code="400">Retorna nulo e a mensagem do erro</response>   
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

        /// <summary>
        /// Verifica se um usuário já existe
        /// </summary>        
        /// <param name="username">Código do usuário</param>
        /// <response code="200">Retorna true caso o usuário exista, caso não false!</response>
        /// <response code="400">Retorna nulo e a mensagem do erro</response>   
        [HttpGet]
        [Route("UsernameExists/{username}")]
        [Authorize]
        public ActionResult<dynamic> CheckUsernameExist(string username)
        {
            try
            {
                var user = _userService.SearchUser(username, null);
                bool UsernameExist = user != null;

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