namespace RhSystem.Models
{
    using System;
    using System.Text;
    using Newtonsoft.Json;
    using RhSystem.Helpers;
    using System.Security.Cryptography;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; private set; }
        public UserRules Rules { get; set; }

        [NotMapped]
        [SwaggerIgnore]
        public Employees Employees { get; set; }

        [Required]
        public int RulesId { get; set; }

        public User(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException("Os campos username e password não podem ser vazios!");
            }

            this.Username = username;
            this.SetPassword(password);
            this.CreatedAt = DateTime.UtcNow;
            this.UpdatedAt = DateTime.UtcNow;
        }

        public void SetPassword(string password)
        {
            if (!string.IsNullOrEmpty(password))
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
            else
            {
                this.Password = "";
            }
        }

        public void SetDeletedAt()
        {
            DeletedAt = DateTime.UtcNow;
        }

        public void RemoveDeletedAt()
        {
            DeletedAt = new Nullable<DateTime>();
        }
    }
}