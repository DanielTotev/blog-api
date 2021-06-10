using BlogApi.Db;
using BlogApi.Db.Models;
using BlogApi.Service.DTOs;
using BlogApi.Utils;
using System;
using System.Linq;

namespace BlogApi.Service.Implementations
{
    public class CommentService
    {
        private BlogDbContext blogDbContext = new BlogDbContext();
        private CommentMapper commentMapper = new CommentMapper();

        public void CreateComment(CommentCreateDTO commentDto, int authorId)
        {
            var author = blogDbContext.Users.Where(u => u.Id == authorId).FirstOrDefault();
            var post = blogDbContext.Posts.Where(p => p.Id == commentDto.PostId).FirstOrDefault();
            if(post == null)
            {
                throw new EntityNotFoundException();
            }
            var comment = new Comment()
            {
                Content = commentDto.Content,
                Author = author,
                Post = post,
                CreatedOn = DateTime.Now
            };
            blogDbContext.Comments.Add(comment);
            blogDbContext.SaveChanges();
        }

        public void DeleteCommentById(int id, int currentUserId)
        {
            var comment = blogDbContext.Comments.Include("Author").Where(c => c.Id == id).FirstOrDefault();
            CheckIfCommentIsValidForUpdateDelete(comment, currentUserId);
            blogDbContext.Comments.Remove(comment);
            blogDbContext.SaveChanges();
        }

        public void UpdateComment(CommentEditDTO commentDto, int commentId, int currentUserId)
        {
            var comment = blogDbContext.Comments.Include("Author").Where(c => c.Id == commentId).FirstOrDefault();
            if(commentDto.Content != comment.Content)
            {
                CheckIfCommentIsValidForUpdateDelete(comment, currentUserId);
            }
            comment.Content = commentDto.Content;
            comment.Likes = commentDto.Likes;
            comment.Dislikes = commentDto.Dislikes;
            comment.UpdatedOn = DateTime.Now;
            blogDbContext.SaveChanges();
        }

        private void CheckIfCommentIsValidForUpdateDelete(Comment comment, int currentUserId)
        {
            if (comment == null)
            {
                throw new EntityNotFoundException();
            }
            if (comment.Author.Id != currentUserId)
            {
                throw new IlegalAccessException();
            }
        }

        public CommentDTO GetCommentDetailsById(int id)
        {
            var comment = blogDbContext.Comments.Include("Author").Where(u => u.Id == id).FirstOrDefault();
            if(comment == null)
            {
                throw new EntityNotFoundException();
            }
            return commentMapper.MapToDto(comment);
        }
    }
}