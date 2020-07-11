namespace RhSystem.Controllers
{
    using System;
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

        [HttpPost]
        [Route("CreateUserRules")]
        [Authorize]
        public ActionResult<dynamic> CreateUserRules(UserRules userRules)
        {
            try
            {
                _userRulesService.CreateRule(userRules);

                return new OkObjectResult(new
                {
                    Message = "Regra criada com sucesso!",
                    UserRule = userRules
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
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

        [HttpPut]
        [Route("UpdateUserRules")]
        [Authorize]
        public ActionResult<dynamic> UpdateUserRules(UserRules userRules)
        {
            try
            {
                userRules = _userRulesService.UpdateUserRules(userRules);

                return new OkObjectResult(new
                {
                    Message = "Regra foi atualizada!",
                    UserRules = userRules
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetUserRules")]
        [Authorize]
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

        [HttpDelete("{id}")]
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

        [HttpDelete("{id}")]
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