namespace BlogApi.Service.DTOs
{
    public class CommentEditDTO: BaseCommentDTO
    {
        public int Likes { get; set; }

        public int Dislikes { get; set; }
    }
}