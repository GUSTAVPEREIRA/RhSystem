namespace RhSystem.DTO
{
    using Newtonsoft.Json;
    using Swashbuckle.AspNetCore.Annotations;
    using System.ComponentModel.DataAnnotations;

    [SwaggerSchema(Required = new[] { "Autenticação de usuário" })]
    public class UserAuthenticateDTO
    {
        /// <summary>
        /// Username 
        /// </summary>
        /// <example>ADMIN</example>
        [Required]
        public string Username { get; set; }

        /// <summary>
        /// Password 
        /// </summary>
        /// <example>ADMIN</example>
        [Required]
        public string Password { get; set; }
    }
}