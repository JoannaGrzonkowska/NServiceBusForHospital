using System;

namespace RepositoryClasses
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
    }
}
