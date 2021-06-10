using BlogApi.Service.DTOs;
using BlogApi.Service.Implementations;
using BlogApi.Utils;
using System.Web.Http;

namespace BlogApi.Controllers
{
    [RoutePrefix("api/auth")]
    public class AuthController : ApiController
    {
        private UserService userService = new UserService();

        [Route("register")]
        [HttpPost]
        public IHttpActionResult Register([FromBody] UserDTO user)
        {
            if(!user.IsValid())
            {
                return Json(Messages.ResponseMessage.BadRequest());
            }
            var isRegistrationSuccessful = userService.RegisterUser(user);
            if(!isRegistrationSuccessful)
            {
                return Json(Messages.ResponseMessage.InternalServerError());
            }
            return Json(Messages.ResponseMessage.Created(null));
        }

        [Route("login")]
        [HttpPost]
        public IHttpActionResult Login([FromBody] LoginDTO user)
        {
            if(!user.IsValid())
            {
                return Json(Messages.ResponseMessage.BadRequest());
            }
            try
            {
                var token = userService.Login(user);
                return Json(Messages.ResponseMessage.Ok(token));
            } catch(AuthenticationException e) {
                return Json(Messages.ResponseMessage.BadRequest(e.Message));
            }
        }

    }
}
