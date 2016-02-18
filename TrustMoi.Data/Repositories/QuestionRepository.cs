using TrustMoi.Data.Base;
using TrustMoi.Data.Interfaces;

namespace TrustMoi.Data.Repositories
{
    public class QuestionRepository : Repository<Question>, IQuestionRepository
    {
        public QuestionRepository(IDbContext context) : base(context)
        {
        }
    }
}