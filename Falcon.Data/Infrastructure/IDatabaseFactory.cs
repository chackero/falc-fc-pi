using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Falcon.Domain.Models;

namespace Falcon.Data.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        FalconDbContext DataContext { get; }
    }
}
