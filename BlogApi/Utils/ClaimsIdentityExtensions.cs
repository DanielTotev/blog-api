using System.Linq;
using System.Security.Claims;

namespace BlogApi.Utils
{
    public static class ClaimsIdentityExtensions
    {
        public static int GetUserId(this ClaimsIdentity identity)
        {
            var id = identity.Claims.Where(p => p.Type == "userid").FirstOrDefault()?.Value;
            return int.Parse(id);
        }
    }
}