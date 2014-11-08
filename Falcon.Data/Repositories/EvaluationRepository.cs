using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
