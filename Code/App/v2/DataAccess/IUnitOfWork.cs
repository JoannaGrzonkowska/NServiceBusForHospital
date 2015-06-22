using System;

namespace DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
    }
}
