using TrustMoi.Data.Base;
using TrustMoi.Data.Interfaces;

namespace TrustMoi.Data.Repositories
{
    public class UserRepository : Repository<AspNetUser>, IUserRepository
    {
        public UserRepository(IDbContext context) : base(context)
        {
        }
    }
}