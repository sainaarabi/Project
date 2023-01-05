using System;
using System.Threading.Tasks;

namespace SSO.Core.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        Task CommitAsync();
    }
}
