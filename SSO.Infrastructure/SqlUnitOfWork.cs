using Microsoft.EntityFrameworkCore;
using SSO.Core.Exceptions;
using SSO.Core.Repositories;
using SSO.Infrastructure.DBContext;

namespace SSO.Infrastructure
{
    public class SqlUnitOfWork : IUnitOfWork
    {
        private readonly SSODbContext _ssoDbContext;

        public SqlUnitOfWork(SSODbContext context)
        {
            _ssoDbContext = context;
        }

        public void Dispose()
        {
            _ssoDbContext.Dispose();
        }

        public void Commit()
        {
            try
            {
                _ssoDbContext.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException != null && (ex.InnerException.Message.Contains("DELETE") ||
                    ex.InnerException.Message.Contains("REFERENCE")))
                {
                    throw new ImpossibleDeleteException();
                }
                throw new DbInvalidOperationException();
            }
        }

        public async Task CommitAsync()
        {
            try
            {
                await _ssoDbContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException != null && (ex.InnerException.Message.Contains("DELETE") ||
                    ex.InnerException.Message.Contains("REFERENCE")))
                {
                    throw new ImpossibleDeleteException();
                }
                throw new DbInvalidOperationException();
            }
        }
    }
}
