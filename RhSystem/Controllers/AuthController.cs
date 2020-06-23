namespace RhSystem.Controllers
{
    using RhSystem.Models;
    using Microsoft.AspNetCore.Mvc;
    using RhSystem.Repositories.IServices;

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;

        public AuthController(ITokenService tokenService, IUserService userService)
        {
            _tokenService = tokenService;
            _userService = userService;
        }

        [Route("Authenticate")]
        [HttpPost]
        public ActionResult<dynamic> Authenticate(User user)
        {
            User validUser = _userService.GetUserForAuthenticate(user.Username, user.Password);

            if (validUser == null)
            {
                return NotFound(new { Message = "Usuário não encontrado!"});
            }

            var token = _tokenService.GenerateToken(validUser);
            validUser.SetPassword("");

            return new OkObjectResult(new 
            {
                BearerToken = token, 
                User = validUser 
            });
        }
    }
}