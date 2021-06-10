using System.ComponentModel.DataAnnotations;

namespace BlogApi.Db.Models
{
    public class User: BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        [MaxLength(150)]
        public string Email { get; set; }

        [Required]
        [MaxLength(400)]
        public string Password { get; set; }

    }
}