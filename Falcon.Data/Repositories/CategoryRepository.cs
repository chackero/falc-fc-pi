using Falcon.Data.Infrastructure;
using Falcon.Domain.Models;

namespace Falcon.Data.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {
        }
    }

    public interface ICategoryRepository : IRepository<Category>
    {

    }
}
