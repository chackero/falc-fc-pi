using Falcon.Data.Infrastructure;
using Falcon.Domain.Models;

namespace Falcon.Data.Repositories
{
    public class MissionRepository : RepositoryBase<Mission>, IMissionRepository
    {
        public MissionRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {
        }
    }

    public interface IMissionRepository : IRepository<Mission>
    {

    }
}
