using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD.Lib.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        public IRepository<T> GetRepository<T>() where T : class;
        public Task<int> SaveChangesAsync();
    }

    public class UnitOfWork : IUnitOfWork
    {
        DbContext _dbContext;
        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            return new Repository<T>(_dbContext);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            GC.Collect();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
