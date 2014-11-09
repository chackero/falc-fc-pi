using System;

namespace Falcon.Data.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        FalconDbContext DataContext { get; }
    }
}
