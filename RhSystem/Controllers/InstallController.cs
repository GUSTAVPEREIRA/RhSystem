namespace RhSystem.Controllers
{
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

        [Route("FirstInstall")]
        [HttpPost]
        public ActionResult<dynamic> FirstInstall()
        {
            _firstInstallSeeder.Seeder();

            return Ok("Configurações iniciais foram parâmetrizadas!");
        }
    }
}