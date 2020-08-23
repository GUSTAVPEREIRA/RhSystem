namespace RhSystem.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;
    using RhSystem.Repositories.IServices.ISeederService;

    [Route("api/[controller]")]
    [ApiController]
    public class InstallController : ControllerBase
    {
        private readonly IFirstInstallSeederService _firstInstallSeeder;

        public InstallController(IFirstInstallSeederService firstInstallSeeder)
        {
            _firstInstallSeeder = firstInstallSeeder;
        }

        /// <summary>
        /// Realiza a parâmetrização inicial do sistemas, criando o usuário inicial.
        /// </summary>          
        /// <response code="200">Retorna uma mensagem informado sucesso!</response>
        /// <response code="400">Retorna nulo e a mensagem do erro</response>            
        /// <returns></returns>
        [Route("FirstInstall")]
        [HttpPost]
        public ActionResult<dynamic> FirstInstall()
        {
            try
            {
                _firstInstallSeeder.Seeder();

                return Ok("Configurações iniciais foram parâmetrizadas!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }
    }
}