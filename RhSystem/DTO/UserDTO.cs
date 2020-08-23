namespace RhSystem.DTO
{
    using System.ComponentModel.DataAnnotations;

    public class UserDTO
    {
        public int ID { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public int RulesID { get; set; }
    }
}