using EmployeeManagement.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Database.Employee.Persistence.EFCore.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;
        private readonly DbSet<TEntity> _entities;
        public Repository(DbContext context)
        {
            Context = context;
            _entities = Context.Set<TEntity>();
        }
        public async Task<TEntity> GetAsync(Guid uid) => await _entities.FindAsync(uid);
        public async Task<IEnumerable<TEntity>> GetAllAsync() => await _entities.ToListAsync();
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate) => _entities.Where(predicate);
        public async Task AddAsync(TEntity entity) => await _entities.AddAsync(entity);
        public async Task AddRangeAsync(IEnumerable<TEntity> entities) => await _entities.AddRangeAsync(entities);
        public void Remove(TEntity entity) => _entities.Remove(entity);
        public void RemoveRange(IEnumerable<TEntity> entities) => _entities.RemoveRange(entities);
    }
}
