using System.ComponentModel.DataAnnotations;

namespace BlogApi.Db.Models
{
    public class Comment: BaseEntity
    {
        [Required]
        [MaxLength(3000)]
        public string Content { get; set; }

        public long Likes { get; set; }

        public long Dislikes { get; set; }

        public Post Post { get; set; }

        [Required]
        public User Author { get; set; }
    }
}