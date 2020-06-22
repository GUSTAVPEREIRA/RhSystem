namespace RhSystem.Models
{
    using System;
    using System.Text;
    using System.Security.Cryptography;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo \"Username\" não pode ser vazio!")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "O username deve conter entre 3 a 15 caracteres!")]
        public string Username { get; set; }
        
        [Required(ErrorMessage = "O campo \"Senha\" não pode ser vazio!")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "A senha deve conter entre 3 a 15 caracteres!")]
        public string Password { get; private set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }        


        public void SetPassword(string password)
        {
            this.Password = password;
            StringBuilder keyPassword = new StringBuilder();
            MD5 md5 = MD5.Create();
            byte[] input = Encoding.ASCII.GetBytes("//" + this.Password);
            byte[] hash = md5.ComputeHash(input);

            for (int i = 0; i < hash.Length; i++)
            {
                keyPassword.Append(hash[i].ToString("X2"));
            }

            this.Password = keyPassword.ToString();
        }
    }
}