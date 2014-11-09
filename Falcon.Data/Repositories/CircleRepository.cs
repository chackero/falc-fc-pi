using Falcon.Data.Infrastructure;
using Falcon.Domain.Models;

namespace Falcon.Data.Repositories
{
    public class CircleRepository : RepositoryBase<Circle>, ICircleRepository
    {
        public CircleRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {
        }
    }

    public interface ICircleRepository : IRepository<Circle>
    {

    }
}
