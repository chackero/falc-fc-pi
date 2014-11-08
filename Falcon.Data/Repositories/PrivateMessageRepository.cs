using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
