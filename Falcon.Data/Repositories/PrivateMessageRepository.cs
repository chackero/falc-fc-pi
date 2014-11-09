using Falcon.Data.Infrastructure;
using Falcon.Domain.Models;

namespace Falcon.Data.Repositories
{
    public class PrivateMessageRepository : RepositoryBase<PrivateMessage>, IPrivateMessageRepository
    {
        public PrivateMessageRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {
        }
    }

    public interface IPrivateMessageRepository : IRepository<PrivateMessage>
    {

    }
}
