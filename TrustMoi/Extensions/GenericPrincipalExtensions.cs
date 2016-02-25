using System.Security.Claims;
using System.Security.Principal;

namespace TrustMoi.Extensions
{
    public static class GenericPrincipalExtensions
    {
        public static string GetUserFullName(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("FullName");

            return (claim != null) ? claim.Value : string.Empty;
        }
    }

}