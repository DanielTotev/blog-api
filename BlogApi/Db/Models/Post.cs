using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlogApi.Db.Models
{
    public class Post: BaseEntity
    {
        [Required]
        [MaxLength(150)]
        public string Title { get; set; }

        [MaxLength(3000)]
        public string Descriptipon { get; set; }

        public long Likes { get; set; }

        public long Dislikes { get; set; }

        [MaxLength(3000)]
        public string ImageUrl { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        [Required]
        public User Author { get; set; }
    }
}