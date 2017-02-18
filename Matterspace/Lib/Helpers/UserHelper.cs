using System.Linq;
using System.Security.Claims;
using System.Web;

namespace Matterspace.Lib.Helpers
{
    public static class UserHelper
    {
        /// <summary>
        /// Search UserId in User Identity Claims.
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public static string GetUserIdFromClaims(HttpContextBase httpContext)
        {
            var userId = ((ClaimsPrincipal)httpContext.User).Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                throw new HttpRequestValidationException("User id not found in Claims.");
            }

            return userId.Value;
        }
    }
}