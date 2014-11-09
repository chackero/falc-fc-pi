using Falcon.Data.Infrastructure;
using Falcon.Domain.Models;

namespace Falcon.Data.Repositories
{
    public class MemberRepository : RepositoryBase<Member>, IMemberRepository
    {
        public MemberRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {
        }
    }

    public interface IMemberRepository : IRepository<Member>
    {

    }
}
