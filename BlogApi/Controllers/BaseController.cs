using System.Web.Http;
using System.Security.Claims;
using BlogApi.Utils;

namespace BlogApi.Controllers
{
    public abstract class BaseController : ApiController
    {
        protected int GetCurrentUserId()
        {
            var identity = User.Identity as ClaimsIdentity;
            return identity.GetUserId();
        }
    }
}
