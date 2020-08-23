namespace RhSystem.DTO
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class UserRulesDTO
    {
        /// <summary>
        /// ID 
        /// </summary>
        /// <example>1</example>
        public int Id { get; set; }

        /// <summary>
        /// Name 
        /// </summary>
        /// <example>Administrador</example>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// IsAdmin 
        /// </summary>
        /// <example>true</example>
        [DefaultValue(false)]
        public bool IsAdmin { get; set; }

        /// <summary>
        /// PhysicalExclusion 
        /// </summary>
        /// <example>true</example>
        [DefaultValue(false)]
        public bool PhysicalExclusion { get; set; }
    }
}