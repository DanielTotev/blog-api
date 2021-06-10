namespace BlogApi.Service.DTOs
{
    public class PostUpdateDTO: PostCreateDTO
    {
        public int Likes { get; set; }

        public int Dislikes { get; set; }
    }
}