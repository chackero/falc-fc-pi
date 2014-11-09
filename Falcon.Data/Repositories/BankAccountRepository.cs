using Falcon.Data.Infrastructure;
using Falcon.Domain.Models;

namespace Falcon.Data.Repositories
{
    public class BankAccountRepository : RepositoryBase<BankAccount>, IBankAccountRepository
    {
        public BankAccountRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {
        }
    }

    public interface IBankAccountRepository : IRepository<BankAccount>
    {

    }
}
