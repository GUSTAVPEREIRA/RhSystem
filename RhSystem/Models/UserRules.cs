namespace RhSystem.Models
{
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Text.Json.Serialization;

    public class UserRules
    {
       
        public int Id { get; set; }        
        public string Name { get; set; }

        [DefaultValue(false)]
        public bool IsAdmin { get; set; }

        [DefaultValue(false)]
        public bool PhysicalExclusion { get; set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; private set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public List<User> Users { get; set; }
        public UserRules(string name, bool isAdmin = false, bool physicalExclusion = false)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("O nome da regra não pode ser vazio!");
            }

            this.Name = name;
            this.IsAdmin = isAdmin;
            this.PhysicalExclusion = physicalExclusion;
            CreatedAt = DateTime.UtcNow.Date;
            UpdatedAt = DateTime.UtcNow.Date;
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