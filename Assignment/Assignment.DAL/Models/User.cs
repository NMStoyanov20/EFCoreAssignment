using System.ComponentModel.DataAnnotations;

namespace DomainModel.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

    }
}
