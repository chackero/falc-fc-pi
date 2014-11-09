using Falcon.Data.Infrastructure;
using Falcon.Domain.Models;

namespace Falcon.Data.Repositories
{
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {
        }
    }

    public interface IPostRepository : IRepository<Post>
    {

    }
}
