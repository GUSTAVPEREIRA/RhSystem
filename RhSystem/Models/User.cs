namespace RhSystem.Models
{
    using System;
    using System.Text;
    using System.Security.Cryptography;

    public class User
    {
        public int Id { get; set; }                
        public string Username { get; set; }                
        public string Password { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; private set; }        
        public UserRules Rules { get; set; }        

        public User(string username, string password)
        {
            this.Username = username;
            this.SetPassword(password);
            this.CreatedAt = DateTime.UtcNow.Date;
            this.UpdatedAt = DateTime.UtcNow.Date;            
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
                this.Password = password;
            }            
        }

        public void SetDeletedAt()
        {
            DeletedAt = DateTime.UtcNow.Date;
        }

        public void RemoveDeletedAt()
        {
            DeletedAt = new Nullable<DateTime>();
        }
    }
}