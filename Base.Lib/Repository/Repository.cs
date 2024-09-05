using Microsoft.EntityFrameworkCore;

namespace TD.Lib.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(object id);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
        IQueryable<T> AsNoTracking { get; }
    }

    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;
        private DbSet<T> _entities;

        public Repository(DbContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }

        public virtual IQueryable<T> AsNoTracking => _entities.AsNoTracking();

        public virtual async Task<T> GetByIdAsync(object id)
        {
            return await _entities.FindAsync(id);
        }

        public virtual async Task<T> CreateAsync(T entity)
        {
            return (await _entities.AddAsync(entity)).Entity;
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            return _entities.Update(entity).Entity;
        }

        public virtual async Task<T> DeleteAsync(T entity)
        {
            return _entities.Remove(entity).Entity;
        }
    }
}
