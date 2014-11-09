using Falcon.Data.Infrastructure;
using Falcon.Domain.Models;

namespace Falcon.Data.Repositories
{
    public class FreelancerRepository : RepositoryBase<Freelancer>, IFreelancerRepository
    {
        public FreelancerRepository(IDatabaseFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface IFreelancerRepository : IRepository<Freelancer>
    {
        
    }
}
