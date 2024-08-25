using Microsoft.EntityFrameworkCore;

namespace Base.Lib.Repository
{
    public interface IRepository<T> where T : class
    {
        T GetById(object id);
        T Insert(T entity);
        T Update(T entity);
        T Delete(T entity);
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

        public virtual T Delete(T entity)
        {
            return _entities.Remove(entity).Entity;
        }

        public virtual T GetById(object id)
        {
            return _entities.Find(id);
        }

        public virtual T Insert(T entity)
        {
            return _entities.Add(entity).Entity;
        }

        public virtual T Update(T entity)
        {
            return _entities.Update(entity).Entity;
        }
    }
}
