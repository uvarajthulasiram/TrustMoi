using Microsoft.AspNet.Identity.EntityFramework;
using TrustMoi.Models;

namespace TrustMoi
{
    public class ApplicationUserStore : UserStore<ApplicationUser>
    {
        public ApplicationUserStore(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}