
namespace Falcon.Data.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {

        private FalconDbContext dataContext;

        public FalconDbContext DataContext
        {
            get
            {
                return dataContext; 
            }
        }

        public DatabaseFactory()
        {
            dataContext = new FalconDbContext();
        }

        protected override void DisposeCore()
        {
            if (DataContext != null)
                DataContext.Dispose();
        }
    }
}
