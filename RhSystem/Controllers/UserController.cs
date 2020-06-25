namespace RhSystem.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using RhSystem.Repositories.IServices;

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }               
    }
}