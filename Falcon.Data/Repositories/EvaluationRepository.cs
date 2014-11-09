using Falcon.Data.Infrastructure;
using Falcon.Domain.Models;

namespace Falcon.Data.Repositories
{
    public class EvaluationRepository : RepositoryBase<Evaluation>, IEvaluationRepository
    {
        public EvaluationRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {
        }
    }

    public interface IEvaluationRepository : IRepository<Evaluation>
    {

    }
}
