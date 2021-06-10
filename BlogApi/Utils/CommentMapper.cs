using BlogApi.Db.Models;
using BlogApi.Service.DTOs;

namespace BlogApi.Utils
{
    public class CommentMapper
    {
        public CommentDTO MapToDto(Comment comment) => new CommentDTO()
        {
            Content = comment.Content,
            Id = comment.Id,
            Likes = comment.Likes,
            Dislikes = comment.Dislikes,
            CreatedOn = comment.CreatedOn,
            UpdatedOn = comment.UpdatedOn,
            CreatedBy = comment.Author.Username
        };
    }
}