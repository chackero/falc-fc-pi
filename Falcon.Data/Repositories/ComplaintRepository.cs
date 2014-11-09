using Falcon.Data.Infrastructure;
using Falcon.Domain.Models;

namespace Falcon.Data.Repositories
{
    public class ComplaintRepository : RepositoryBase<Complaint>, IComplaintRepository
    {
        public ComplaintRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {
        }
    }

    public interface IComplaintRepository : IRepository<Complaint>
    {

    }
}
