namespace RhSystem.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        [HttpPost]
        [Route("CreateEmployees")]
        public ActionResult<dynamic> CreateEmployees()
        {
            try
            {
                return new OkObjectResult(new
                {
                    Message = "Funcionário criado com sucesso!"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}