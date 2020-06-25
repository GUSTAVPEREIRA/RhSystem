namespace RhSystem.Repositories.Services
{
    using System;
    using System.Text;
    using RhSystem.Models;
    using System.Security.Claims;
    using Microsoft.IdentityModel.Tokens;
    using System.IdentityModel.Tokens.Jwt;
    using RhSystem.Repositories.IServices;

    public class TokenService : ITokenService
    {
        public string GenerateToken(User user)
        {
            var tokenhandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);

            var tokenDescription = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username)
                    //new Caim(ClaimTypes.Role, user.)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials
                (
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature
                )
            };

            var token = tokenhandler.CreateToken(tokenDescription);
            return tokenhandler.WriteToken(token);
        }
    }
}