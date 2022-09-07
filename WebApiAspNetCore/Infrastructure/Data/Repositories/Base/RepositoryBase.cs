using Microsoft.EntityFrameworkCore;
using WebApiAspNetCore.Domain.Entities.Base;
using WebApiAspNetCore.Domain.Interfaces.Repositories.Base;
using WebApiAspNetCore.Infrastructure.Data.Commom;

namespace WebApiAspNetCore.Infrastructure.Data.Repositories.Base
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : BaseModel
    {
        protected readonly RegisterContext _context;
        public RepositoryBase(RegisterContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public void Delete(Guid id)
        {
            _context.Set<T>().Remove(Get(id));
            _context.SaveChanges();
        }

        public async Task DeleteAsync(Guid id)
        {
            _context.Set<T>().Remove(await GetAsync(id));
            await _context.SaveChangesAsync();
        }

        public T Get(Guid id)
        {
            var keyValue = new object[] { id };
            return _context.Set<T>().Find(keyValue);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().AsNoTracking().AsEnumerable();
        }

        public IAsyncEnumerable<T> GetAllAsync()
        {
            return _context.Set<T>().AsNoTracking().AsAsyncEnumerable();
        }

        public async Task<T> GetAsync(Guid id)
        {
            var keyValue = new object[] { id };
            return await _context.Set<T>().FindAsync(keyValue);
        }

        public void Include(string? child)
        {
            _context.Set<T>().Include(child);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
