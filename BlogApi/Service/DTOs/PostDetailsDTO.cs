using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace BlogApi.Service.DTOs
{
    public class PostDetailsDTO
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "createdOn")]
        public DateTime CreatedOn { get; set; }

        [JsonProperty(PropertyName = "updatedOn")]
        public DateTime? UpdatedOn { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Descriptipon { get; set; }

        [JsonProperty(PropertyName = "likes")]
        public long Likes { get; set; }

        [JsonProperty(PropertyName = "dislikes")]
        public long Dislikes { get; set; }

        [JsonProperty(PropertyName = "imageUrl")]
        public string ImageUrl { get; set; }

        [JsonProperty(PropertyName = "comments")]
        public List<CommentDTO> Comments { get; set; }

        [JsonProperty(PropertyName = "postedBy")]
        public string PostedBy { get; set; }
    }
}