namespace RhSystem.Controllers
{
    using System;
    using RhSystem.Models;
    using Microsoft.AspNetCore.Mvc;
    using RhSystem.Repositories.IServices;

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
    }
}