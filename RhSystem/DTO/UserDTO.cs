namespace RhSystem.DTO
{
    using System.ComponentModel.DataAnnotations;

    public class UserDTO
    {
        /// <summary>
        /// ID 
        /// </summary>
        /// <example>1</example>
        public int ID { get; set; }

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

        /// <summary>
        /// RulesID 
        /// </summary>
        /// <example>1</example>
        [Required]
        public int RulesID { get; set; }
    }
}