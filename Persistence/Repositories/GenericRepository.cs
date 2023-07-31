using Microsoft.EntityFrameworkCore;
using Persistence.Repository.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<T> _entitySet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _entitySet = context.Set<T>();
        }
        public async Task<T?> FindAsync(Guid id)
        {
            return await _entitySet.FindAsync(id);
        }
        public void Add(T entity)
        {
            _context.Add(entity);
        }

        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _context.AddAsync(entity, cancellationToken);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _context.AddRange(entities);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            await _context.AddRangeAsync(entities, cancellationToken);
        }

        public T? Get(Expression<Func<T, bool>> predicate)
        {
            return _entitySet.FirstOrDefault(predicate);
        }

        public IEnumerable<T>? GetAll()
        {
            return _entitySet.AsEnumerable();
        }

        public IEnumerable<T>? GetAll(Expression<Func<T, bool>> predicate)
        {
            return _entitySet.Where(predicate).AsEnumerable();
        }

        public async Task<IEnumerable<T>?> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _entitySet.ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<T>?> GetAllAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await _entitySet.Where(predicate).ToListAsync(cancellationToken);
        }

        public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await _entitySet.FirstOrDefaultAsync(predicate, cancellationToken);
        }

        public void Remove(T entity)
        {
            _context.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _context.Update(entity);
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            _context.UpdateRange(entities);
        }


        public IQueryable<T>? FindAll()
        {
            return _entitySet.AsQueryable().AsNoTracking();
        }

        public IQueryable<T>? FindByCondition(Expression<Func<T, bool>> predicate)
        {
            return _entitySet.Where(predicate).AsNoTracking();
        }
    }
}
