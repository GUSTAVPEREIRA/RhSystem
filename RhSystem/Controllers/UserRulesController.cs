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
    public class UserRulesController : ControllerBase
    {
        private readonly IUserRulesService _userRulesService;

        public UserRulesController(IUserRulesService userRulesService)
        {
            _userRulesService = userRulesService;
        }

        /// <summary>
        /// Cria uma regra para o usuário
        /// </summary>        
        /// <remarks>
        /// Sample request:
        ///
        ///     POST
        ///     {
        ///        "Name": ADMIN,
        ///        "IsAdmin": true,
        ///        "PhysicalExclusion": true
        ///     }
        ///
        /// </remarks>  
        /// <response code="200">Retorna a regra de usuário recém criada!</response>
        /// <response code="400">Retorna nulo e a mensagem do erro</response>            
        /// <returns></returns>
        [HttpPost]
        [Route("CreateUserRules")]
        [Authorize]
        public ActionResult<dynamic> CreateUserRules(UserRulesDTO userRules)
        {
            try
            {

                UserRules newUserRules = new UserRules(userRules.Name, userRules.IsAdmin, userRules.PhysicalExclusion);

                _userRulesService.CreateRule(newUserRules);

                return new OkObjectResult(new
                {
                    Message = "Regra criada com sucesso!",
                    UserRule = newUserRules
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Cria uma regra para o usuário
        /// </summary>                
        /// <param name="id">Código da regra de usuário!</param>
        /// <response code="200">Retorna a regra de usuário</response>
        /// <response code="400">Retorna nulo e a mensagem do erro</response>            
        /// <returns></returns>
        [HttpGet]
        [Route("GetUserRulesById/{id}")]
        [Authorize]
        public ActionResult<dynamic> GetUserRulesById(int id)
        {
            try
            {
                UserRules userRules = _userRulesService.GetUserRulesById(id);

                return new OkObjectResult(new
                {
                    UserRule = userRules
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Atualiza uma regra de usuário existente
        /// </summary>           
        /// <remarks>
        /// Sample request:
        ///
        ///     POST
        ///     {
        ///        "Name": ADMIN,
        ///        "IsAdmin": true,
        ///        "PhysicalExclusion": true
        ///     }
        ///
        /// </remarks> 
        /// <response code="200">Retorna a regra de usuário atualizada</response>
        /// <response code="400">Retorna uma mensagem do erro</response>            
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateUserRules")]
        [Authorize]
        public ActionResult<dynamic> UpdateUserRules(UserRulesDTO userRules)
        {
            try
            {

                UserRules updateUserRules = _userRulesService.GetUserRulesById(userRules.Id);

                if (updateUserRules == null)
                {
                    throw new Exception("Regra de usuário não foi encontrada");
                }

                updateUserRules.IsAdmin = userRules.IsAdmin;
                updateUserRules.PhysicalExclusion = userRules.PhysicalExclusion;
                updateUserRules.Name = userRules.Name;
                updateUserRules = _userRulesService.UpdateUserRules(updateUserRules);

                return new OkObjectResult(new
                {
                    Message = "Regra foi atualizada!",
                    UserRules = updateUserRules
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Retorna uma lista de regras de usuário
        /// </summary>           
        /// <response code="200">Retorna uma lista de regra de usuário</response>
        /// <response code="400">Retorna uma mensagem do erro</response>            
        /// <returns></returns>
        [HttpGet]
        [Route("GetUserRules")]
        public ActionResult<dynamic> GetUserRules()
        {
            try
            {
                var lista = _userRulesService.GetUserRules();

                return new OkObjectResult(new
                {
                    UserRules = lista
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Deleta físicamente uma regra de usuário
        /// </summary>           
        /// <param name="id">Código da regra de usuário</param>
        /// <response code="200">Retorna a regra de usuário e uma mensagem informando que ela foi deletada</response>
        /// <response code="400">Retorna uma mensagem do erro</response>            
        /// <returns></returns>
        [HttpDelete]
        [Route("PhysicalDelete/{id}")]
        [Authorize]
        public ActionResult<dynamic> DeleteUserRulesPhysical(int id)
        {
            try
            {
                var userRules = _userRulesService.GetUserRulesById(id);

                if (userRules == null)
                {
                    throw new ArgumentNullException("Regra de usuário não encontrada!");
                }

                _userRulesService.PhysicalDeletedUserRules(userRules);

                return new OkObjectResult(new
                {
                    Message = "Regra foi deletada!",
                    Regra = userRules.Name
                });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Deleta lógicamente uma regra de usuário
        /// </summary>           
        /// <param name="id">Código da regra de usuário</param>
        /// <response code="200">Retorna a regra de usuário e uma mensagem informando que ela foi deletada</response>
        /// <response code="400">Retorna uma mensagem do erro</response>            
        /// <returns></returns>
        [HttpDelete]
        [Route("Delete/{id}")]
        [Authorize]
        public ActionResult<dynamic> DeleteUserRules(int id)
        {
            try
            {
                var userRules = _userRulesService.DeletedUserRules(id);

                return new OkObjectResult(new
                {
                    Message = $"Regra {userRules.Name} foi deletado!"
                });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}