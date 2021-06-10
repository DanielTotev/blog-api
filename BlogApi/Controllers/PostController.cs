using System.Web.Http;
using BlogApi.Service.DTOs;
using BlogApi.Utils;
using BlogApi.Service.Implementations;

namespace BlogApi.Controllers
{
    [RoutePrefix("api/posts")]
    public class PostController : BaseController
    {
        private PostService postService = new PostService();

        [Authorize]
        [HttpPost]
        [Route("")]
        public IHttpActionResult Create([FromBody] PostCreateDTO post)
        {
            if(!post.IsValid())
            {
                return Json(Messages.ResponseMessage.BadRequest());
            }
            var authorId = GetCurrentUserId();
            postService.CreatePost(post, authorId);
            return Json(Messages.ResponseMessage.Created(null));
        }

        [Authorize]
        [HttpGet]
        [Route("")]

        public IHttpActionResult GetAll()
        {
            return Json(Messages.ResponseMessage.Ok(postService.GetAllPosts()));
        }

        [Authorize]
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult DeleteById(int id)
        {
            var currentUserId = GetCurrentUserId();
            try
            {
                postService.DeletePost(id, currentUserId);
            } catch (IlegalAccessException)
            {
                return Json(Messages.ResponseMessage.Unauthorized());
            } catch(EntityNotFoundException)
            {
                return Json(Messages.ResponseMessage.NotFound());
            }
            return Json(Messages.ResponseMessage.NoContent());
        }

        [Authorize]
        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult UpdateById(int id, PostUpdateDTO postDto)
        {
            if (!postDto.IsValid())
            {
                return Json(Messages.ResponseMessage.BadRequest());
            }
            var currentUserId = GetCurrentUserId();
            try
            {
                postService.UpdatePost(postDto, id, currentUserId);
            }
            catch (IlegalAccessException)
            {
                return Json(Messages.ResponseMessage.Unauthorized());
            }
            catch(EntityNotFoundException)
            {
                return Json(Messages.ResponseMessage.NotFound());
            }
            return Json(Messages.ResponseMessage.NoContent());
        }

        [Authorize]
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetPostDetailsById(int id)
        {
            try
            {
                return Json(Messages.ResponseMessage.Ok(postService.GetPostDetails(id)));
            }catch(EntityNotFoundException)
            {
                return Json(Messages.ResponseMessage.NotFound());
            }
        }
    }
}
