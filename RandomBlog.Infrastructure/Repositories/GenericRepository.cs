namespace RandomBlog.Infrastructure.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using RandomBlog.Application.Interfaces.Repositories;
    using RandomBlog.Domain.Common;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    internal class GenericRepository<T> : IGenericRepository<T> where T : BaseAuditableEntity
    {
        private readonly RandomBlogDbContext _dbContext;

        public GenericRepository(RandomBlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<T> Entities => _dbContext.Set<T>();

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            return entity;
        }

        public Task UpdateAsync(T entity)
        {
            T exist = _dbContext.Set<T>().Find(entity.Id);
            _dbContext.Entry(exist).CurrentValues.SetValues(entity);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<List<T>> GetAllAsync() => await _dbContext.Set<T>().ToListAsync();

        public async Task<T> GetByIdAsync(int id) => await _dbContext.Set<T>().FindAsync(id);

    }
}