using Newtonsoft.Json;

namespace BlogApi.Service.DTOs
{
    public class CommentCreateDTO: BaseCommentDTO
    {
        [JsonProperty(PropertyName = "postId")]
        public int PostId { get; set; }
    }
}