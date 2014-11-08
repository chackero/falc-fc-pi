using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Falcon.Domain.Models;

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
