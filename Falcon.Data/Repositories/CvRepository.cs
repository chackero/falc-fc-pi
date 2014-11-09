using Falcon.Data.Infrastructure;
using Falcon.Domain.Models;

namespace Falcon.Data.Repositories
{
    public class CvRepository : RepositoryBase<CV>, ICvRepository
    {
        public CvRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {
        }
    }

    public interface ICvRepository : IRepository<CV>
    {

    }
}
