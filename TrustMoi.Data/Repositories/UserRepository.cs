using TrustMoi.Data.Base;
using TrustMoi.Data.Interfaces;

namespace TrustMoi.Data.Repositories
{
    public class UserRepository : Repository<AspNetUser>, IUserRepository
    {
        private readonly IRepository<Person> _personRepository;
         
        public UserRepository(IDbContext context, IRepository<Person> personRepository) : base(context)
        {
            _personRepository = personRepository;
        }

        public Person NewPersonObject()
        {
            return _personRepository.NewObject();
        }
    }
}