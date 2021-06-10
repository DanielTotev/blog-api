using BlogApi.Service.DTOs;
using BlogApi.Service.Implementations;
using BlogApi.Utils;
using System.Web.Http;

namespace BlogApi.Controllers
{
    [RoutePrefix("api/comments")]
    public class CommentController : BaseController
    {
        private CommentService commentService = new CommentService();

        [Authorize]
        [HttpPost]
        [Route("")]
        public IHttpActionResult CreateComment([FromBody] CommentCreateDTO commentDto)
        {
            if (!commentDto.IsValid())
            {
                return Json(Messages.ResponseMessage.BadRequest());
            }
            try
            {
                commentService.CreateComment(commentDto, GetCurrentUserId());
                return Json(Messages.ResponseMessage.Created(null));
            } catch(EntityNotFoundException)
            {
                return Json(Messages.ResponseMessage.NotFound("No such post exists"));
            }
        }


        [Authorize]
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult DeleteComment(int id)
        {
            try
            {
                commentService.DeleteCommentById(id, GetCurrentUserId());
                return Json(Messages.ResponseMessage.NoContent());
            } catch(EntityNotFoundException)
            {
                return Json(Messages.ResponseMessage.NotFound());
            }
        }

        [Authorize]
        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult UpdateComment([FromBody] CommentEditDTO commentEditDTO, int id)
        {
            if (!commentEditDTO.IsValid())
            {
                return Json(Messages.ResponseMessage.BadRequest());
            }
            var currentUserId = GetCurrentUserId();
            try
            {
                commentService.UpdateComment(commentEditDTO, id, currentUserId);
            }
            catch (IlegalAccessException)
            {
                return Json(Messages.ResponseMessage.Unauthorized());
            }
            catch (EntityNotFoundException)
            {
                return Json(Messages.ResponseMessage.NotFound());
            }
            return Json(Messages.ResponseMessage.NoContent());
        }

        [Authorize]
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetCommentDetailsById(int id)
        {
            try
            {
                return Json(Messages.ResponseMessage.Ok(commentService.GetCommentDetailsById(id)));
            } catch(EntityNotFoundException)
            {
                return Json(Messages.ResponseMessage.NotFound());
            }
        }
    }
}
