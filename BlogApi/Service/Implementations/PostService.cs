using BlogApi.Db;
using BlogApi.Db.Models;
using BlogApi.Service.DTOs;
using BlogApi.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlogApi.Service.Implementations
{
    public class PostService
    {
        private BlogDbContext dbContext;
        private CommentMapper commentMapper;

        public PostService()
        {
            dbContext = new BlogDbContext();
            commentMapper = new CommentMapper();
        }

        public void CreatePost(PostCreateDTO post, int authorId)
        {
            var author = dbContext.Users.Where(u => u.Id == authorId).FirstOrDefault();
            var postToSave = new Post()
            {
                Title = post.Title,
                Descriptipon = post.Description,
                ImageUrl = post.ImageUrl,
                Author = author,
                CreatedOn = DateTime.Now
            };
            dbContext.Posts.Add(postToSave);
            dbContext.SaveChanges();
        }

        public List<AllPostsDTO> GetAllPosts()
        {
            return dbContext.Posts.Select(post => new AllPostsDTO()
            {
                Title = post.Title,
                Summary = post.Descriptipon.Substring(0, 25) + "...",
                Id = post.Id
            }).ToList();
        }

        public void DeletePost(int postId, int currentUserId)
        {
            var post = dbContext.Posts.Include("Author").Include("Comments").Where(p => p.Id == postId).FirstOrDefault();
            ValidatePostForUpdateOrDelete(post, currentUserId);
            var comments = post.Comments;
            dbContext.Comments.RemoveRange(comments);
            dbContext.Posts.Remove(post);
            dbContext.SaveChanges();
        }

        public void UpdatePost(PostUpdateDTO postDto, int postId, int currentUserId)
        {
            var post = dbContext.Posts.Include("Author").Where(p => p.Id == postId).FirstOrDefault();
            if(UpdateRequiresAuthorization(postDto, post))
            {
                ValidatePostForUpdateOrDelete(post, currentUserId);
            }
            post.Title = postDto.Title;
            post.Descriptipon = postDto.Description;
            post.ImageUrl = postDto.ImageUrl;
            post.Likes = postDto.Likes;
            post.Dislikes = postDto.Dislikes;
            post.UpdatedOn = DateTime.Now;
            dbContext.SaveChanges();
        }

        private bool UpdateRequiresAuthorization(PostUpdateDTO postDto, Post post)
        {
            return post.Title != postDto.Title || post.Descriptipon != postDto.Description || post.ImageUrl != post.ImageUrl;
        }

        public PostDetailsDTO GetPostDetails(int id)
        {
            var post = dbContext
            .Posts
            .Include("Author")
            .Include("Comments")
            .Include("Comments.Author")
            .Where(p => p.Id == id)
            .FirstOrDefault();
            if(post == null)
            {
                throw new EntityNotFoundException();
            }
            var comments = post.Comments != null ? post.Comments.Select(comment => commentMapper.MapToDto(comment)).ToList() : null;
            return new PostDetailsDTO() 
            {
                Id = post.Id,
                CreatedOn = post.CreatedOn,
                UpdatedOn = post.UpdatedOn,
                Title = post.Title,
                Descriptipon = post.Descriptipon,
                Likes = post.Likes,
                Dislikes = post.Dislikes,
                ImageUrl = post.ImageUrl,
                PostedBy = post.Author.Username,
                Comments = comments
            };
        }

        private void ValidatePostForUpdateOrDelete(Post post, int currentUserId)
        {
            if (post == null)
            {
                throw new EntityNotFoundException();
            }
            if (post.Author.Id != currentUserId)
            {
                throw new IlegalAccessException();
            }
        }
    }
}