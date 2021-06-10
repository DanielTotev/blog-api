using Newtonsoft.Json;
using System;

namespace BlogApi.Service.DTOs
{
    public class CommentDTO: BaseCommentDTO
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "likes")]
        public long Likes { get; set; }

        [JsonProperty(PropertyName = "dislikes")]
        public long Dislikes { get; set; }

        [JsonProperty(PropertyName = "createdBy")]
        public string CreatedBy { get; set; }

        [JsonProperty(PropertyName = "createdOn")]
        public DateTime CreatedOn { get; set; }

        [JsonProperty(PropertyName = "updatedOn")]
        public DateTime? UpdatedOn { get; set; }
    }
}