using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

namespace TrustMoi.Extensions
{
    public static class GenericPrincipalExtensions
    {
        public static string FullName(this IPrincipal user)
        {
            if (!user.Identity.IsAuthenticated) return string.Empty;

            var claimsIdentity = user.Identity as ClaimsIdentity;

            if (claimsIdentity == null) return string.Empty;

            foreach (var claim in claimsIdentity.Claims.Where(claim => claim.Type == "FullName"))
                return claim.Value;

            return string.Empty;
        }
    }

}